namespace WinFormTest
{
    partial class ImgLargeView
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelLargeImage = new System.Windows.Forms.Panel();
            this.panelSmallImage = new System.Windows.Forms.Panel();
            this.pictureBoxLarge = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelLargeImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLarge)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelLargeImage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelSmallImage);
            this.splitContainer1.Size = new System.Drawing.Size(518, 505);
            this.splitContainer1.SplitterDistance = 327;
            this.splitContainer1.TabIndex = 2;
            // 
            // panelLargeImage
            // 
            this.panelLargeImage.Controls.Add(this.pictureBoxLarge);
            this.panelLargeImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLargeImage.Location = new System.Drawing.Point(0, 0);
            this.panelLargeImage.Name = "panelLargeImage";
            this.panelLargeImage.Size = new System.Drawing.Size(518, 327);
            this.panelLargeImage.TabIndex = 1;
            // 
            // panelSmallImage
            // 
            this.panelSmallImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSmallImage.Location = new System.Drawing.Point(0, 0);
            this.panelSmallImage.Name = "panelSmallImage";
            this.panelSmallImage.Size = new System.Drawing.Size(518, 174);
            this.panelSmallImage.TabIndex = 2;
            // 
            // pictureBoxLarge
            // 
            this.pictureBoxLarge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLarge.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLarge.Name = "pictureBoxLarge";
            this.pictureBoxLarge.Size = new System.Drawing.Size(518, 327);
            this.pictureBoxLarge.TabIndex = 0;
            this.pictureBoxLarge.TabStop = false;
            // 
            // ImgLargeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ImgLargeView";
            this.Size = new System.Drawing.Size(518, 505);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelLargeImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLarge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelLargeImage;
        private System.Windows.Forms.Panel panelSmallImage;
        private System.Windows.Forms.PictureBox pictureBoxLarge;
    }
}
