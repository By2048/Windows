﻿namespace WinFormTest
{
    partial class Form13
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
            this.panelImageShow = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelImageShow
            // 
            this.panelImageShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImageShow.Location = new System.Drawing.Point(0, 0);
            this.panelImageShow.Name = "panelImageShow";
            this.panelImageShow.Size = new System.Drawing.Size(679, 639);
            this.panelImageShow.TabIndex = 0;
            // 
            // Form13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 639);
            this.Controls.Add(this.panelImageShow);
            this.Name = "Form13";
            this.Text = "Form13";
            this.Load += new System.EventHandler(this.Form13_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelImageShow;
    }
}