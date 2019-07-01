namespace TestMazzudioCardReader
{
    partial class MainForm
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
            this.systemStatusRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // systemStatusRichTextBox
            // 
            this.systemStatusRichTextBox.Location = new System.Drawing.Point(12, 12);
            this.systemStatusRichTextBox.Name = "systemStatusRichTextBox";
            this.systemStatusRichTextBox.Size = new System.Drawing.Size(631, 328);
            this.systemStatusRichTextBox.TabIndex = 0;
            this.systemStatusRichTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 352);
            this.Controls.Add(this.systemStatusRichTextBox);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox systemStatusRichTextBox;
    }
}

