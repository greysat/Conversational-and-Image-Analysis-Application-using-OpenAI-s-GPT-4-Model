namespace TextGeneration
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConversationRichTextBox = new System.Windows.Forms.RichTextBox();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonSelectImage = new System.Windows.Forms.Button();
            this.buttonAnalyzeImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ConversationRichTextBox
            // 
            this.ConversationRichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ConversationRichTextBox.ForeColor = System.Drawing.Color.LightGray;
            this.ConversationRichTextBox.Location = new System.Drawing.Point(12, 12);
            this.ConversationRichTextBox.Name = "ConversationRichTextBox";
            this.ConversationRichTextBox.Size = new System.Drawing.Size(776, 396);
            this.ConversationRichTextBox.TabIndex = 0;
            this.ConversationRichTextBox.Text = "";
            // 
            // InputTextBox
            // 
            this.InputTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.InputTextBox.ForeColor = System.Drawing.Color.LightGray;
            this.InputTextBox.Location = new System.Drawing.Point(12, 414);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(688, 20);
            this.InputTextBox.TabIndex = 1;
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SendButton.ForeColor = System.Drawing.Color.LightGray;
            this.SendButton.Location = new System.Drawing.Point(706, 412);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(82, 23);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pictureBox1.Location = new System.Drawing.Point(794, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(232, 396);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // buttonSelectImage
            // 
            this.buttonSelectImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonSelectImage.ForeColor = System.Drawing.Color.LightGray;
            this.buttonSelectImage.Location = new System.Drawing.Point(794, 414);
            this.buttonSelectImage.Name = "buttonSelectImage";
            this.buttonSelectImage.Size = new System.Drawing.Size(115, 23);
            this.buttonSelectImage.TabIndex = 4;
            this.buttonSelectImage.Text = "Select Image";
            this.buttonSelectImage.UseVisualStyleBackColor = true;
            this.buttonSelectImage.Click += new System.EventHandler(this.buttonSelectImage_Click);
            // 
            // buttonAnalyzeImage
            // 
            this.buttonAnalyzeImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonAnalyzeImage.ForeColor = System.Drawing.Color.LightGray;
            this.buttonAnalyzeImage.Location = new System.Drawing.Point(915, 414);
            this.buttonAnalyzeImage.Name = "buttonAnalyzeImage";
            this.buttonAnalyzeImage.Size = new System.Drawing.Size(111, 23);
            this.buttonAnalyzeImage.TabIndex = 5;
            this.buttonAnalyzeImage.Text = "Analyze Image";
            this.buttonAnalyzeImage.UseVisualStyleBackColor = true;
            this.buttonAnalyzeImage.Click += new System.EventHandler(this.buttonAnalyzeImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1038, 447);
            this.Controls.Add(this.buttonAnalyzeImage);
            this.Controls.Add(this.buttonSelectImage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.ConversationRichTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RichTextBox ConversationRichTextBox;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonSelectImage;
        private System.Windows.Forms.Button buttonAnalyzeImage;
    }
}
