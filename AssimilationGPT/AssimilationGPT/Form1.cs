using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextGeneration
{
    public partial class Form1 : Form
    {
        private string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

        public Form1()
        {
            InitializeComponent();
            InputTextBox.KeyDown += InputTextBox_KeyDown;
            ConversationRichTextBox.ReadOnly = true;

        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;  // prevent the beep sound
                SendButton.PerformClick();
            }
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            string userMessage = InputTextBox.Text;
            AppendText(ConversationRichTextBox, Color.LightBlue, "User: " + userMessage + "\n\n");

            InputTextBox.Clear();
            InputTextBox.Enabled = false;
            SendButton.Enabled = false;

            await Task.Delay(1000);  // simulate typing delay

            string botMessage = await GetGpt4Response(userMessage);
            AppendText(ConversationRichTextBox, Color.LightGray, "Bot: " + botMessage + "\n\n");

            InputTextBox.Enabled = true;
            SendButton.Enabled = true;

            ConversationRichTextBox.SelectionStart = ConversationRichTextBox.Text.Length;
            ConversationRichTextBox.ScrollToCaret();  // auto-scroll to bottom
        }

        private void AppendText(RichTextBox box, Color color, string text)
        {
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;

            box.Select(start, end - start);
            {
                box.SelectionColor = color;
            }
            box.SelectionLength = 0; // clear

            box.SelectionStart = box.Text.Length;
            box.ScrollToCaret();  // auto-scroll to bottom
        }

        private async Task<string> GetGpt4Response(string message)
        {
            string url = "https://api.openai.com/v1/chat/completions";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

            JObject jsonContent = new JObject
            {
                ["model"] = "gpt-4-1106-preview",
                ["messages"] = new JArray(
                    new JObject
                    {
                        ["role"] = "system",
                        ["content"] = "You are a helpful assistant."
                    },
                    new JObject
                    {
                        ["role"] = "user",
                        ["content"] = message
                    }
                )
            };

            HttpContent content = new StringContent(jsonContent.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                return $"Error: Received status code {response.StatusCode}";
            }

            string responseString = await response.Content.ReadAsStringAsync();
            JObject jsonResponse = JObject.Parse(responseString);

            if (jsonResponse == null)
            {
                return "Error: Failed to parse JSON response";
            }

            string botMessage = jsonResponse["choices"][0]["message"]["content"].ToString();

            return botMessage;
        }

        private void buttonSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;  // make the image scale proportionally
                pictureBox1.BackgroundImageLayout = ImageLayout.Center;  // center the image in the PictureBox
            }
        }

        private async void buttonAnalyzeImage_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                byte[] imageBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    imageBytes = ms.ToArray();
                }

                string analysis = await CallOpenAI(imageBytes);
                AppendText(ConversationRichTextBox, Color.LightGray, "Image Analysis: " + analysis + "\n\n");

                ConversationRichTextBox.SelectionStart = ConversationRichTextBox.Text.Length;
                ConversationRichTextBox.ScrollToCaret();  // auto-scroll to bottom
            }
        }

        private async Task<string> CallOpenAI(byte[] imageBytes)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                string imageString = Convert.ToBase64String(imageBytes);

                var payload = new
                {
                    model = "gpt-4-vision-preview",
                    messages = new[]
                    {
                        new
                        {
                            role = "user",
                            content = new object[]
                            {
                                new
                                {
                                    type = "text",
                                    text = "What’s in this image?"
                                },
                                new
                                {
                                    type = "image_url",
                                    image_url = new
                                    {
                                        url = $"data:image/jpeg;base64,{imageString}"
                                    }
                                }
                            }
                        }
                    },
                    max_tokens = 300
                };

                string payloadJson = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
                var content = new StringContent(payloadJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
                MessageBox.Show($"Response status code: {response.StatusCode}\nResponse message: {response.ReasonPhrase}");

                string responseString = await response.Content.ReadAsStringAsync();

                string analysis;
                try
                {
                    analysis = ProcessResponse(responseString);
                }
                catch (Exception e)
                {
                    analysis = $"Error processing API response: {e.Message}";
                }

                return analysis;
            }
        }

        private string ProcessResponse(string responseString)
        {
            JObject responseJson = JObject.Parse(responseString);
            JToken choices;
            if (responseJson.TryGetValue("choices", out choices) && choices.HasValues)
            {
                JToken message = choices[0]["message"];
                if (message != null && message.HasValues)
                {
                    JToken content = message["content"];
                    if (content != null)
                    {
                        return (string)content;
                    }
                }
            }

            throw new Exception("Unexpected API response structure");
        }
    }
}
