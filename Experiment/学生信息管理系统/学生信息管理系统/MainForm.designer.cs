using System.Windows.Forms;
namespace 学生信息管理系统
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("计算机-142");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("计算机系", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("信管");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("法学");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("体育");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("绍兴文理学院", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.studentTree = new System.Windows.Forms.TreeView();
            this.addFaculty = new System.Windows.Forms.Button();
            this.change = new System.Windows.Forms.Button();
            this.searchStudent = new System.Windows.Forms.Button();
            this.comboBoxFaculty = new System.Windows.Forms.ComboBox();
            this.labFaculty = new System.Windows.Forms.Label();
            this.del = new System.Windows.Forms.Button();
            this.addStudent = new System.Windows.Forms.Button();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.textID = new System.Windows.Forms.TextBox();
            this.labAddress = new System.Windows.Forms.Label();
            this.radioWomen = new System.Windows.Forms.RadioButton();
            this.radioMan = new System.Windows.Forms.RadioButton();
            this.labSex = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.labID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.studentTree);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.addFaculty);
            this.splitContainer.Panel2.Controls.Add(this.change);
            this.splitContainer.Panel2.Controls.Add(this.searchStudent);
            this.splitContainer.Panel2.Controls.Add(this.comboBoxFaculty);
            this.splitContainer.Panel2.Controls.Add(this.labFaculty);
            this.splitContainer.Panel2.Controls.Add(this.del);
            this.splitContainer.Panel2.Controls.Add(this.addStudent);
            this.splitContainer.Panel2.Controls.Add(this.textDescription);
            this.splitContainer.Panel2.Controls.Add(this.textName);
            this.splitContainer.Panel2.Controls.Add(this.textID);
            this.splitContainer.Panel2.Controls.Add(this.labAddress);
            this.splitContainer.Panel2.Controls.Add(this.radioWomen);
            this.splitContainer.Panel2.Controls.Add(this.radioMan);
            this.splitContainer.Panel2.Controls.Add(this.labSex);
            this.splitContainer.Panel2.Controls.Add(this.labName);
            this.splitContainer.Panel2.Controls.Add(this.labID);
            this.splitContainer.Size = new System.Drawing.Size(567, 458);
            this.splitContainer.SplitterDistance = 167;
            this.splitContainer.TabIndex = 0;
            // 
            // studentTree
            // 
            this.studentTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentTree.Location = new System.Drawing.Point(0, 0);
            this.studentTree.Name = "studentTree";
            treeNode1.Name = "";
            treeNode1.Text = "计算机-142";
            treeNode2.Name = "title_0";
            treeNode2.Text = "计算机系";
            treeNode3.Name = "title_1";
            treeNode3.Text = "信管";
            treeNode4.Name = "title_2";
            treeNode4.Text = "法学";
            treeNode5.Name = "title_3";
            treeNode5.Text = "体育";
            treeNode6.Name = "title_Main";
            treeNode6.Text = "绍兴文理学院";
            this.studentTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.studentTree.Size = new System.Drawing.Size(167, 458);
            this.studentTree.TabIndex = 0;
            this.studentTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.studentTree_ItemDrag);
            this.studentTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.studentTree_AfterSelect);
            this.studentTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.studentTree_DragDrop);
            this.studentTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.studentTree_DragEnter);
            // 
            // addFaculty
            // 
            this.addFaculty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addFaculty.Location = new System.Drawing.Point(21, 412);
            this.addFaculty.Name = "addFaculty";
            this.addFaculty.Size = new System.Drawing.Size(67, 23);
            this.addFaculty.TabIndex = 26;
            this.addFaculty.Text = "添加系别";
            this.addFaculty.UseVisualStyleBackColor = true;
            this.addFaculty.Click += new System.EventHandler(this.addFaculty_Click);
            // 
            // change
            // 
            this.change.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.change.Location = new System.Drawing.Point(320, 412);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(52, 23);
            this.change.TabIndex = 25;
            this.change.Text = "修改";
            this.change.UseVisualStyleBackColor = true;
            this.change.Click += new System.EventHandler(this.change_Click);
            // 
            // searchStudent
            // 
            this.searchStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchStudent.Location = new System.Drawing.Point(253, 412);
            this.searchStudent.Name = "searchStudent";
            this.searchStudent.Size = new System.Drawing.Size(52, 23);
            this.searchStudent.TabIndex = 24;
            this.searchStudent.Text = "查找";
            this.searchStudent.UseVisualStyleBackColor = true;
            this.searchStudent.Click += new System.EventHandler(this.search_Click);
            // 
            // comboBoxFaculty
            // 
            this.comboBoxFaculty.FormattingEnabled = true;
            this.comboBoxFaculty.Location = new System.Drawing.Point(118, 140);
            this.comboBoxFaculty.Name = "comboBoxFaculty";
            this.comboBoxFaculty.Size = new System.Drawing.Size(155, 20);
            this.comboBoxFaculty.TabIndex = 23;
            this.comboBoxFaculty.Text = "选择您所在系别！";
            this.comboBoxFaculty.SelectedIndexChanged += new System.EventHandler(this.comboBoxFaculty_SelectedIndexChanged);
            // 
            // labFaculty
            // 
            this.labFaculty.AutoSize = true;
            this.labFaculty.Location = new System.Drawing.Point(59, 143);
            this.labFaculty.Name = "labFaculty";
            this.labFaculty.Size = new System.Drawing.Size(29, 12);
            this.labFaculty.TabIndex = 22;
            this.labFaculty.Text = "院系";
            // 
            // del
            // 
            this.del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.del.Location = new System.Drawing.Point(186, 412);
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(52, 23);
            this.del.TabIndex = 21;
            this.del.Text = "删除";
            this.del.UseVisualStyleBackColor = true;
            this.del.Click += new System.EventHandler(this.del_Click);
            // 
            // addStudent
            // 
            this.addStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addStudent.Location = new System.Drawing.Point(101, 412);
            this.addStudent.Name = "addStudent";
            this.addStudent.Size = new System.Drawing.Size(67, 23);
            this.addStudent.TabIndex = 20;
            this.addStudent.Text = "添加学生";
            this.addStudent.UseVisualStyleBackColor = true;
            this.addStudent.Click += new System.EventHandler(this.addStudent_Click);
            // 
            // textDescription
            // 
            this.textDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textDescription.Location = new System.Drawing.Point(118, 181);
            this.textDescription.Multiline = true;
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(229, 178);
            this.textDescription.TabIndex = 19;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(118, 64);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(155, 21);
            this.textName.TabIndex = 18;
            // 
            // textID
            // 
            this.textID.Location = new System.Drawing.Point(118, 25);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(155, 21);
            this.textID.TabIndex = 17;
            // 
            // labAddress
            // 
            this.labAddress.AutoSize = true;
            this.labAddress.Location = new System.Drawing.Point(35, 184);
            this.labAddress.Name = "labAddress";
            this.labAddress.Size = new System.Drawing.Size(53, 12);
            this.labAddress.TabIndex = 16;
            this.labAddress.Text = "个人描述";
            // 
            // radioWomen
            // 
            this.radioWomen.AutoSize = true;
            this.radioWomen.Location = new System.Drawing.Point(214, 104);
            this.radioWomen.Name = "radioWomen";
            this.radioWomen.Size = new System.Drawing.Size(35, 16);
            this.radioWomen.TabIndex = 15;
            this.radioWomen.TabStop = true;
            this.radioWomen.Text = "女";
            this.radioWomen.UseVisualStyleBackColor = true;
            // 
            // radioMan
            // 
            this.radioMan.AutoSize = true;
            this.radioMan.Checked = true;
            this.radioMan.Location = new System.Drawing.Point(133, 104);
            this.radioMan.Name = "radioMan";
            this.radioMan.Size = new System.Drawing.Size(35, 16);
            this.radioMan.TabIndex = 14;
            this.radioMan.TabStop = true;
            this.radioMan.Text = "男";
            this.radioMan.UseVisualStyleBackColor = true;
            // 
            // labSex
            // 
            this.labSex.AutoSize = true;
            this.labSex.Location = new System.Drawing.Point(59, 104);
            this.labSex.Name = "labSex";
            this.labSex.Size = new System.Drawing.Size(29, 12);
            this.labSex.TabIndex = 13;
            this.labSex.Text = "性别";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(59, 67);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(29, 12);
            this.labName.TabIndex = 12;
            this.labName.Text = "姓名";
            // 
            // labID
            // 
            this.labID.AutoSize = true;
            this.labID.Location = new System.Drawing.Point(59, 34);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(29, 12);
            this.labID.TabIndex = 11;
            this.labID.Text = "学号";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 458);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainForm";
            this.Text = "学生信息管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView studentTree;
        private Button del;
        private Button addStudent;
        private TextBox textDescription;
        private TextBox textName;
        private TextBox textID;
        private Label labAddress;
        private RadioButton radioWomen;
        private RadioButton radioMan;
        private Label labSex;
        private Label labName;
        private Label labID;
        private Label labFaculty;
        private ComboBox comboBoxFaculty;
        private Button change;
        private Button searchStudent;
        private Button addFaculty;
    }
}

