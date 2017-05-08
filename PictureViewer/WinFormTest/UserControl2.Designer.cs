namespace WinFormTest
{
    partial class UserControl2
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLargeImage = new System.Windows.Forms.Panel();
            this.panelSmallImage = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelLargeImage
            // 
            this.panelLargeImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLargeImage.Location = new System.Drawing.Point(0, 0);
            this.panelLargeImage.Name = "panelLargeImage";
            this.panelLargeImage.Size = new System.Drawing.Size(380, 272);
            this.panelLargeImage.TabIndex = 0;
            // 
            // panelSmallImage
            // 
            this.panelSmallImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSmallImage.Location = new System.Drawing.Point(0, 278);
            this.panelSmallImage.Name = "panelSmallImage";
            this.panelSmallImage.Size = new System.Drawing.Size(380, 78);
            this.panelSmallImage.TabIndex = 1;
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSmallImage);
            this.Controls.Add(this.panelLargeImage);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(380, 356);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLargeImage;
        private System.Windows.Forms.Panel panelSmallImage;
    }
}
