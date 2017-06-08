using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace 学生信息管理系统
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        List<TreeNode> AllNodes = new List<TreeNode>();
        ErrorProvider errorInput = new ErrorProvider();

        private void MainForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            TreeNode mainNode = studentTree.Nodes[0];
            mainNode.ExpandAll();
            GetAllNodes(mainNode);
            InitComboBoxFaculty(mainNode);
            if (File.Exists("data.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream("data.dat", FileMode.Open, FileAccess.Read);
                TreeNode node = bf.Deserialize(fs) as TreeNode;
                studentTree.Nodes.Clear();
                studentTree.Nodes.Add(node);
                fs.Close();
            }
            studentTree.ExpandAll();
            studentTree.AllowDrop = true;
            errorInput.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            //errorInput.BlinkRate = 1000;
        }

        private void GetAllNodes(TreeNode mainNode)
        {
            foreach (TreeNode subNode in mainNode.Nodes)
            {
                if (subNode.Nodes.Count >= 0)
                {
                    AllNodes.Add(subNode);
                    GetAllNodes(subNode);
                }
            }

        }

        private void InitComboBoxFaculty(TreeNode mainNode)
        {
            foreach (TreeNode tempNode in AllNodes)
            {
                comboBoxFaculty.Items.Add(tempNode.Text);
            }
        }

        private void addStudent_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren() == true)
            {
                string id, name, sex, faculty = null, description;
                id = this.textID.Text.Trim();
                name = this.textName.Text.Trim();
                sex = this.radioMan.Checked ? "男" : "女";
                faculty = this.comboBoxFaculty.Text.Trim();
                description = this.textDescription.Text.Trim();
                Student student = new Student(id, name, sex, faculty, description);
                TreeNode node = new TreeNode();
                node.Text = name;
                node.Tag = student;
                studentTree.SelectedNode.Nodes.Add(node);
                studentTree.SelectedNode.Expand();
            }
        }

        private void del_Click(object sender, EventArgs e)
        {/
            SearchAndDel(studentTree.Nodes[0], textID.Text);
        }

        private void comboBoxFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreeNode insertNode = null;
            foreach (TreeNode tempNode in AllNodes)
            {
                if (tempNode.Text == comboBoxFaculty.Text)
                    insertNode = tempNode;
            }
            studentTree.SelectedNode = insertNode;
        }

        private void studentTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectNode = studentTree.SelectedNode;
            try
            {
                Student stu = selectNode.Tag as Student;
                this.textID.Text = stu.ID;
                this.textName.Text = stu.Name;
                this.textDescription.Text = stu.Description;
                if (stu.Sex == "男")
                    this.radioMan.Checked = true;
                else
                    this.radioWomen.Checked = true;

                this.comboBoxFaculty.Text = stu.Faculty;
            }
            catch
            {
                this.textID.Text = "";
                this.textName.Text = "";
                this.textDescription.Text = "";
            }

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("data.dat", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(fs, studentTree.Nodes[0]);
            fs.Close();
        }

        private void search_Click(object sender, EventArgs e)
        {
            Search(studentTree.Nodes[0], textID.Text);
        }

        public void Search(TreeNode nodeTree, string text)
        {
            foreach (TreeNode node in nodeTree.Nodes)
            {
                if (node.Nodes.Count >= 0)
                {
                    Student stu = node.Tag as Student;
                    if (stu != null && stu.ID == textID.Text)
                    {
                        textID.Text = stu.ID;
                        textName.Text = stu.Name;
                        if (stu.Sex == "男")
                            radioMan.Checked = true;
                        else
                            radioWomen.Checked = true;
                        comboBoxFaculty.Text = stu.Faculty;
                        textDescription.Text = stu.Description;
                    }
                    else
                    {
                        Search(node, text);
                    }
                }
            }
        }

        public void SearchAndDel(TreeNode nodeTree, string text)
        {
            foreach (TreeNode node in nodeTree.Nodes)
            {
                if (node.Nodes.Count >= 0)
                {
                    Student stu = node.Tag as Student;
                    if (stu != null && stu.ID == textID.Text)
                    {
                        node.Remove();
                        break;
                    }
                    else
                    {
                        SearchAndDel(node, text);
                    }
                }
            }
        }

        private void change_Click(object sender, EventArgs e)
        {
            string id, name, sex, faculty = null, description;
            id = this.textID.Text.Trim();
            name = this.textName.Text.Trim();
            sex = this.radioMan.Checked ? "男" : "女";
            if (this.comboBoxFaculty.SelectedIndex < 0)
                MessageBox.Show("请选择你所在系别！");
            else
                faculty = this.comboBoxFaculty.Text.Trim();
            description = this.textDescription.Text.Trim();

            MessageBox.Show(id + "\n" + name + "\n" + sex + "\n" + faculty + "\n" + description);

            Student newStudent = new Student(id, name, sex, faculty, description);
            TreeNode selectNode = studentTree.SelectedNode;

            selectNode.Tag = newStudent;
            selectNode.Text = name;

        }

        const byte CtrlMask = 8;
        private void studentTree_DragDrop(object sender, DragEventArgs e)
        {

            TreeNode OriginationNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pointXY = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pointXY);
                DestinationNode.Nodes.Add((TreeNode)OriginationNode.Clone());
                DestinationNode.Expand();
                if ((e.KeyState & CtrlMask) != CtrlMask)
                {
                    OriginationNode.Remove();
                }
                Student s = OriginationNode.Tag as Student;
                s.Faculty = DestinationNode.Text;
            }
        }

        private void studentTree_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode"))
            {

                if ((e.KeyState & CtrlMask) == CtrlMask)
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void studentTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                DoDragDrop(e.Item, DragDropEffects.Move | DragDropEffects.Copy);
        }

        public override bool ValidateChildren()
        {
            if (textID.Text == "")
            {
                errorInput.SetError(textID, "学号不能为空！");
                return false;
            }
            if (textName.Text == "")
            {
                errorInput.SetError(textName, "姓名不能为空！");
                return false;
            }
            if (comboBoxFaculty.SelectedIndex <= 0)
            {
                errorInput.SetError(comboBoxFaculty, "请选择院系！");
                return false;
            }
            errorInput.Clear();
            return true;
        }

        private void addFaculty_Click(object sender, EventArgs e)
        {
            string facultyName = "";
            AddFaculty newForm = new AddFaculty();
            DialogResult result = newForm.ShowDialog();
            if (result == DialogResult.OK)
                facultyName = newForm.AddFacultyName;
            if (facultyName.Length != 0)
            {
                TreeNode newNode = new TreeNode();
                newNode.Text = facultyName;
                TreeNode mainNode = studentTree.Nodes[0];
                studentTree.SelectedNode = mainNode;
                studentTree.SelectedNode.Nodes.Add(newNode);
            }

        }

    }
}


