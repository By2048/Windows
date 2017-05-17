namespace WinFormTest
{
    partial class Form09
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form09));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点4");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点5");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点2", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("节点3");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4,
            treeNode5});
            this.imageListIcon = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
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
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(54, 34);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(215, 531);
            this.treeView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(65, 595);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(449, 63);
            this.treeView2.Name = "treeView2";
            treeNode1.Name = "节点1";
            treeNode1.Text = "节点1";
            treeNode2.Name = "节点4";
            treeNode2.Text = "节点4";
            treeNode3.Name = "节点5";
            treeNode3.Text = "节点5";
            treeNode4.Name = "节点2";
            treeNode4.Text = "节点2";
            treeNode5.Name = "节点3";
            treeNode5.Text = "节点3";
            treeNode6.Name = "节点0";
            treeNode6.Text = "节点0";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.treeView2.Size = new System.Drawing.Size(281, 385);
            this.treeView2.TabIndex = 2;
            // 
            // Form09
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 651);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Name = "Form09";
            this.Text = "Form9";
            this.Load += new System.EventHandler(this.Form9_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageListIcon;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView treeView2;
    }
}