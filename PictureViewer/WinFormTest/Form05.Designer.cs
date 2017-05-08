namespace WinFormTest
{
    partial class Form05
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
            this.panPicShow = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panPicShow
            // 
            this.panPicShow.AutoScroll = true;
            this.panPicShow.BackColor = System.Drawing.SystemColors.Control;
            this.panPicShow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panPicShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPicShow.Location = new System.Drawing.Point(0, 0);
            this.panPicShow.Name = "panPicShow";
            this.panPicShow.Size = new System.Drawing.Size(659, 718);
            this.panPicShow.TabIndex = 7;
            // 
            // Form05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 718);
            this.Controls.Add(this.panPicShow);
            this.Name = "Form05";
            this.Text = "Form5";

            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panPicShow;
    }
}