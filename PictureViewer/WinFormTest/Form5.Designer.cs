namespace WinFormTest
{
    partial class Form5
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
            this.btnOk = new System.Windows.Forms.Button();
            this.txtWay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panPicShow
            // 
            this.panPicShow.AutoScroll = true;
            this.panPicShow.BackColor = System.Drawing.SystemColors.Control;
            this.panPicShow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panPicShow.Location = new System.Drawing.Point(25, 117);
            this.panPicShow.Name = "panPicShow";
            this.panPicShow.Size = new System.Drawing.Size(633, 308);
            this.panPicShow.TabIndex = 7;
            this.panPicShow.Paint += new System.Windows.Forms.PaintEventHandler(this.panPicShow_Paint);
            this.panPicShow.DoubleClick += new System.EventHandler(this.panPicShow_DoubleClick);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(547, 22);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(57, 21);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "请选择";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtWay
            // 
            this.txtWay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtWay.Location = new System.Drawing.Point(96, 23);
            this.txtWay.Name = "txtWay";
            this.txtWay.Size = new System.Drawing.Size(445, 21);
            this.txtWay.TabIndex = 5;
            this.txtWay.Text = "  请选择图片所在的路径......";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "路径";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 694);
            this.Controls.Add(this.panPicShow);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtWay);
            this.Controls.Add(this.label1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panPicShow;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtWay;
        private System.Windows.Forms.Label label1;

    }
}