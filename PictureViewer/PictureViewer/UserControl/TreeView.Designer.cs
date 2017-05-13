namespace PictureViewer
{
    partial class TreeView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeView));
            this.treeViewImg = new System.Windows.Forms.TreeView();
            this.imageListIcon = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeViewImg
            // 
            this.treeViewImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewImg.Location = new System.Drawing.Point(0, 0);
            this.treeViewImg.Name = "treeViewImg";
            this.treeViewImg.Size = new System.Drawing.Size(333, 556);
            this.treeViewImg.TabIndex = 0;
            // 
            // imageListIcon
            // 
            this.imageListIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListIcon.ImageStream")));
            this.imageListIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListIcon.Images.SetKeyName(0, "pc.png");
            this.imageListIcon.Images.SetKeyName(1, "folder.png");
            this.imageListIcon.Images.SetKeyName(2, "folder-select.png");
            this.imageListIcon.Images.SetKeyName(3, "img.png");
            this.imageListIcon.Images.SetKeyName(4, "img-select.png");
            this.imageListIcon.Images.SetKeyName(5, "picture-viewer.png");
            // 
            // TreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewImg);
            this.Name = "TreeView";
            this.Size = new System.Drawing.Size(333, 556);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewImg;
        private System.Windows.Forms.ImageList imageListIcon;
    }
}
