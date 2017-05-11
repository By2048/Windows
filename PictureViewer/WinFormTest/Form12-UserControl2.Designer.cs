namespace WinFormTest
{
    partial class Form12
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
            this.panelShowImage = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelShowImage
            // 
            this.panelShowImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShowImage.Location = new System.Drawing.Point(0, 0);
            this.panelShowImage.Name = "panelShowImage";
            this.panelShowImage.Size = new System.Drawing.Size(607, 579);
            this.panelShowImage.TabIndex = 0;
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 579);
            this.Controls.Add(this.panelShowImage);
            this.Name = "Form12";
            this.Text = "Form12";
            this.Load += new System.EventHandler(this.Form12_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelShowImage;
    }
}