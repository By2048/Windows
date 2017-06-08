namespace Test_3_Command_DataReader
{
    partial class Form31
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.inputData = new System.Windows.Forms.GroupBox();
            this.textScore = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.textID = new System.Windows.Forms.TextBox();
            this.labScore = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.labID = new System.Windows.Forms.Label();
            this.operateData = new System.Windows.Forms.GroupBox();
            this.create = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.del = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.show = new System.Windows.Forms.Button();
            this.showData = new System.Windows.Forms.GroupBox();
            this.listScore = new System.Windows.Forms.ListBox();
            this.listName = new System.Windows.Forms.ListBox();
            this.listID = new System.Windows.Forms.ListBox();
            this.inputData.SuspendLayout();
            this.operateData.SuspendLayout();
            this.showData.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputData
            // 
            this.inputData.Controls.Add(this.textScore);
            this.inputData.Controls.Add(this.textName);
            this.inputData.Controls.Add(this.textID);
            this.inputData.Controls.Add(this.labScore);
            this.inputData.Controls.Add(this.labName);
            this.inputData.Controls.Add(this.labID);
            this.inputData.Location = new System.Drawing.Point(12, 12);
            this.inputData.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.inputData.Name = "inputData";
            this.inputData.Size = new System.Drawing.Size(520, 72);
            this.inputData.TabIndex = 0;
            this.inputData.TabStop = false;
            this.inputData.Text = "输入数据";
            // 
            // textScore
            // 
            this.textScore.Location = new System.Drawing.Point(404, 27);
            this.textScore.Name = "textScore";
            this.textScore.Size = new System.Drawing.Size(100, 21);
            this.textScore.TabIndex = 5;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(228, 27);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(100, 21);
            this.textName.TabIndex = 4;
            // 
            // textID
            // 
            this.textID.Location = new System.Drawing.Point(52, 27);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(100, 21);
            this.textID.TabIndex = 3;
            // 
            // labScore
            // 
            this.labScore.AutoSize = true;
            this.labScore.Location = new System.Drawing.Point(369, 30);
            this.labScore.Name = "labScore";
            this.labScore.Size = new System.Drawing.Size(29, 12);
            this.labScore.TabIndex = 2;
            this.labScore.Text = "成绩";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(193, 30);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(29, 12);
            this.labName.TabIndex = 1;
            this.labName.Text = "姓名";
            // 
            // labID
            // 
            this.labID.AutoSize = true;
            this.labID.Location = new System.Drawing.Point(17, 30);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(29, 12);
            this.labID.TabIndex = 0;
            this.labID.Text = "学号";
            // 
            // operateData
            // 
            this.operateData.Controls.Add(this.create);
            this.operateData.Controls.Add(this.exit);
            this.operateData.Controls.Add(this.del);
            this.operateData.Controls.Add(this.add);
            this.operateData.Controls.Add(this.show);
            this.operateData.Location = new System.Drawing.Point(12, 100);
            this.operateData.Name = "operateData";
            this.operateData.Size = new System.Drawing.Size(520, 78);
            this.operateData.TabIndex = 1;
            this.operateData.TabStop = false;
            this.operateData.Text = "数据操作";
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(324, 29);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(75, 23);
            this.create.TabIndex = 4;
            this.create.Text = "建表";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(430, 29);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 3;
            this.exit.Text = "退出";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // del
            // 
            this.del.Location = new System.Drawing.Point(221, 29);
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(75, 23);
            this.del.TabIndex = 2;
            this.del.Text = "删除";
            this.del.UseVisualStyleBackColor = true;
            this.del.Click += new System.EventHandler(this.del_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(116, 29);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 1;
            this.add.Text = "添加";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // show
            // 
            this.show.Location = new System.Drawing.Point(24, 29);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(75, 23);
            this.show.TabIndex = 0;
            this.show.Text = "显示";
            this.show.UseVisualStyleBackColor = true;
            this.show.Click += new System.EventHandler(this.show_Click);
            // 
            // showData
            // 
            this.showData.Controls.Add(this.listScore);
            this.showData.Controls.Add(this.listName);
            this.showData.Controls.Add(this.listID);
            this.showData.Location = new System.Drawing.Point(12, 194);
            this.showData.Name = "showData";
            this.showData.Size = new System.Drawing.Size(520, 203);
            this.showData.TabIndex = 2;
            this.showData.TabStop = false;
            this.showData.Text = "数据显示";
            // 
            // listScore
            // 
            this.listScore.FormattingEnabled = true;
            this.listScore.ItemHeight = 12;
            this.listScore.Location = new System.Drawing.Point(369, 35);
            this.listScore.Name = "listScore";
            this.listScore.Size = new System.Drawing.Size(120, 136);
            this.listScore.TabIndex = 2;
            // 
            // listName
            // 
            this.listName.FormattingEnabled = true;
            this.listName.ItemHeight = 12;
            this.listName.Location = new System.Drawing.Point(201, 35);
            this.listName.Name = "listName";
            this.listName.Size = new System.Drawing.Size(120, 136);
            this.listName.TabIndex = 1;
            // 
            // listID
            // 
            this.listID.FormattingEnabled = true;
            this.listID.ItemHeight = 12;
            this.listID.Location = new System.Drawing.Point(33, 35);
            this.listID.Name = "listID";
            this.listID.Size = new System.Drawing.Size(120, 136);
            this.listID.TabIndex = 0;
            // 
            // Form31
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 413);
            this.Controls.Add(this.showData);
            this.Controls.Add(this.operateData);
            this.Controls.Add(this.inputData);
            this.Name = "Form31";
            this.Text = "实验 3 连接环境下数据操作";
            this.Load += new System.EventHandler(this.Form31_Load);
            this.inputData.ResumeLayout(false);
            this.inputData.PerformLayout();
            this.operateData.ResumeLayout(false);
            this.showData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox inputData;
        private System.Windows.Forms.TextBox textScore;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.Label labScore;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labID;
        private System.Windows.Forms.GroupBox operateData;
        private System.Windows.Forms.GroupBox showData;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button del;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button show;
        private System.Windows.Forms.ListBox listScore;
        private System.Windows.Forms.ListBox listName;
        private System.Windows.Forms.ListBox listID;
    }
}

