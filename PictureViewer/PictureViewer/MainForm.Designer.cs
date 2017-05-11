using PictureViewer;
namespace PictureViewer
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
            this.components = new System.ComponentModel.Container();
            this.toolStripContainerImage = new System.Windows.Forms.ToolStripContainer();
            this.statusStripImage = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelImage = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelTree = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.tsbSmallView = new System.Windows.Forms.ToolStripButton();
            this.tsbLargeView = new System.Windows.Forms.ToolStripButton();
            this.tsbDetailView = new System.Windows.Forms.ToolStripButton();
            this.tsbListView = new System.Windows.Forms.ToolStripButton();
            this.tsvImageSize = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbSize10 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSize15 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSize20 = new System.Windows.Forms.ToolStripMenuItem();
            this.tslMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.显示多选框ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripContainerImage.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainerImage.ContentPanel.SuspendLayout();
            this.toolStripContainerImage.TopToolStripPanel.SuspendLayout();
            this.toolStripContainerImage.SuspendLayout();
            this.statusStripImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainerImage
            // 
            // 
            // toolStripContainerImage.BottomToolStripPanel
            // 
            this.toolStripContainerImage.BottomToolStripPanel.Controls.Add(this.statusStripImage);
            // 
            // toolStripContainerImage.ContentPanel
            // 
            this.toolStripContainerImage.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainerImage.ContentPanel.Size = new System.Drawing.Size(688, 444);
            this.toolStripContainerImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainerImage.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainerImage.Name = "toolStripContainerImage";
            this.toolStripContainerImage.Size = new System.Drawing.Size(688, 491);
            this.toolStripContainerImage.TabIndex = 0;
            this.toolStripContainerImage.Text = "toolStripContainer1";
            // 
            // toolStripContainerImage.TopToolStripPanel
            // 
            this.toolStripContainerImage.TopToolStripPanel.Controls.Add(this.toolStripMain);
            // 
            // statusStripImage
            // 
            this.statusStripImage.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStripImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelImage});
            this.statusStripImage.Location = new System.Drawing.Point(0, 0);
            this.statusStripImage.Name = "statusStripImage";
            this.statusStripImage.Size = new System.Drawing.Size(688, 22);
            this.statusStripImage.TabIndex = 0;
            // 
            // toolStripStatusLabelImage
            // 
            this.toolStripStatusLabelImage.Name = "toolStripStatusLabelImage";
            this.toolStripStatusLabelImage.Size = new System.Drawing.Size(161, 17);
            this.toolStripStatusLabelImage.Text = "toolStripStatusLabelImage";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelMain);
            this.splitContainer1.Size = new System.Drawing.Size(688, 444);
            this.splitContainer1.SplitterDistance = 141;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelTree
            // 
            this.panelTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTree.Location = new System.Drawing.Point(0, 0);
            this.panelTree.Name = "panelTree";
            this.panelTree.Size = new System.Drawing.Size(141, 444);
            this.panelTree.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(542, 444);
            this.panelMain.TabIndex = 0;
            // 
            // toolStripMain
            // 
            this.toolStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSmallView,
            this.tsbLargeView,
            this.tsbDetailView,
            this.tsbListView,
            this.tsvImageSize,
            this.tslMenu});
            this.toolStripMain.Location = new System.Drawing.Point(3, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(218, 25);
            this.toolStripMain.TabIndex = 0;
            // 
            // tsbSmallView
            // 
            this.tsbSmallView.CheckOnClick = true;
            this.tsbSmallView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSmallView.Image = global::AM.Windows.Forms.Properties.Resources._1;
            this.tsbSmallView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSmallView.Name = "tsbSmallView";
            this.tsbSmallView.Size = new System.Drawing.Size(23, 22);
            this.tsbSmallView.Text = "SmallView";
            this.tsbSmallView.Click += new System.EventHandler(this.tsbBtn_Click);
            // 
            // tsbLargeView
            // 
            this.tsbLargeView.CheckOnClick = true;
            this.tsbLargeView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLargeView.Image = global::AM.Windows.Forms.Properties.Resources._2;
            this.tsbLargeView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLargeView.Name = "tsbLargeView";
            this.tsbLargeView.Size = new System.Drawing.Size(23, 22);
            this.tsbLargeView.Text = "LargeView";
            this.tsbLargeView.Click += new System.EventHandler(this.tsbBtn_Click);
            // 
            // tsbDetailView
            // 
            this.tsbDetailView.CheckOnClick = true;
            this.tsbDetailView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDetailView.Image = global::AM.Windows.Forms.Properties.Resources._3;
            this.tsbDetailView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDetailView.Name = "tsbDetailView";
            this.tsbDetailView.Size = new System.Drawing.Size(23, 22);
            this.tsbDetailView.Text = "DetailView";
            this.tsbDetailView.Click += new System.EventHandler(this.tsbBtn_Click);
            // 
            // tsbListView
            // 
            this.tsbListView.CheckOnClick = true;
            this.tsbListView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbListView.Image = global::AM.Windows.Forms.Properties.Resources._4;
            this.tsbListView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbListView.Name = "tsbListView";
            this.tsbListView.Size = new System.Drawing.Size(23, 22);
            this.tsbListView.Text = "ListView";
            this.tsbListView.Click += new System.EventHandler(this.tsbBtn_Click);
            // 
            // tsvImageSize
            // 
            this.tsvImageSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSize10,
            this.tsbSize15,
            this.tsbSize20});
            this.tsvImageSize.Name = "tsvImageSize";
            this.tsvImageSize.Size = new System.Drawing.Size(69, 22);
            this.tsvImageSize.Text = "图片大小";
            // 
            // tsbSize10
            // 
            this.tsbSize10.Name = "tsbSize10";
            this.tsbSize10.Size = new System.Drawing.Size(134, 22);
            this.tsbSize10.Text = "160 X 90";
            this.tsbSize10.Click += new System.EventHandler(this.tsbSize_Click);
            // 
            // tsbSize15
            // 
            this.tsbSize15.Name = "tsbSize15";
            this.tsbSize15.Size = new System.Drawing.Size(134, 22);
            this.tsbSize15.Text = "240 X 135";
            this.tsbSize15.Click += new System.EventHandler(this.tsbSize_Click);
            // 
            // tsbSize20
            // 
            this.tsbSize20.Name = "tsbSize20";
            this.tsbSize20.Size = new System.Drawing.Size(134, 22);
            this.tsbSize20.Text = "320 X 180";
            this.tsbSize20.Click += new System.EventHandler(this.tsbSize_Click);
            // 
            // tslMenu
            // 
            this.tslMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示多选框ToolStripMenuItem});
            this.tslMenu.Name = "tslMenu";
            this.tslMenu.Size = new System.Drawing.Size(45, 22);
            this.tslMenu.Text = "菜单";
            // 
            // 显示多选框ToolStripMenuItem
            // 
            this.显示多选框ToolStripMenuItem.Name = "显示多选框ToolStripMenuItem";
            this.显示多选框ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.显示多选框ToolStripMenuItem.Text = "显示多选框";
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 491);
            this.Controls.Add(this.toolStripContainerImage);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStripContainerImage.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainerImage.BottomToolStripPanel.PerformLayout();
            this.toolStripContainerImage.ContentPanel.ResumeLayout(false);
            this.toolStripContainerImage.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainerImage.TopToolStripPanel.PerformLayout();
            this.toolStripContainerImage.ResumeLayout(false);
            this.toolStripContainerImage.PerformLayout();
            this.statusStripImage.ResumeLayout(false);
            this.statusStripImage.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripContainer toolStripContainerImage;
        private System.Windows.Forms.StatusStrip statusStripImage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelImage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton tsbSmallView;
        private System.Windows.Forms.ToolStripButton tsbLargeView;
        private System.Windows.Forms.ToolStripButton tsbDetailView;
        private System.Windows.Forms.ToolStripButton tsbListView;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripDropDownButton tsvImageSize;
        private System.Windows.Forms.ToolStripMenuItem tsbSize10;
        private System.Windows.Forms.ToolStripMenuItem tsbSize15;
        private System.Windows.Forms.ToolStripMenuItem tsbSize20;
        private System.Windows.Forms.ToolStripDropDownButton tslMenu;
        private System.Windows.Forms.ToolStripMenuItem 显示多选框ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTree;
    }
}