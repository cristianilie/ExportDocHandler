namespace ExportDocHandles
{
    partial class MissingDocumentsForm
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
            this.MissingDocumentsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CopyButton = new System.Windows.Forms.Button();
            this.MissingDocumentsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MissingDocumentsRichTextBox
            // 
            this.MissingDocumentsRichTextBox.Location = new System.Drawing.Point(12, 33);
            this.MissingDocumentsRichTextBox.Name = "MissingDocumentsRichTextBox";
            this.MissingDocumentsRichTextBox.Size = new System.Drawing.Size(440, 214);
            this.MissingDocumentsRichTextBox.TabIndex = 28;
            this.MissingDocumentsRichTextBox.Text = "";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(296, 253);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 29;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CopyButton
            // 
            this.CopyButton.Location = new System.Drawing.Point(377, 253);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(75, 23);
            this.CopyButton.TabIndex = 30;
            this.CopyButton.Text = "Copy";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // MissingDocumentsLabel
            // 
            this.MissingDocumentsLabel.AutoSize = true;
            this.MissingDocumentsLabel.Location = new System.Drawing.Point(13, 14);
            this.MissingDocumentsLabel.Name = "MissingDocumentsLabel";
            this.MissingDocumentsLabel.Size = new System.Drawing.Size(128, 16);
            this.MissingDocumentsLabel.TabIndex = 31;
            this.MissingDocumentsLabel.Text = "Missing Documents:";
            // 
            // MissingDocumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(463, 284);
            this.Controls.Add(this.MissingDocumentsLabel);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.MissingDocumentsRichTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DodgerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MissingDocumentsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MissingDocumentsForm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox MissingDocumentsRichTextBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Label MissingDocumentsLabel;
    }
}