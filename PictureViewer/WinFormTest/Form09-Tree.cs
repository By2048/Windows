using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTest
{
    public partial class Form09 : Form
    {
        public Form09()
        {
            InitializeComponent();
            AllowDrop = true;

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            CenterToScreen();

            //TreeNode node1 = new TreeNode("node1");
            //treeView1.Nodes.Add(node1);


            //TreeNode node2 = new TreeNode("node2");
            //node1.Nodes.Add(node2);

            //TreeNode node21 = new TreeNode("node21");
            //node2.Nodes.Add(node21);

            //TreeNode node3 = new TreeNode("node3");
            //node1.Nodes.Add(node3);


            //TreeNode node4 = new TreeNode("node4");
            //node1.Nodes.Add(node4);

            TreeNode node1 = new TreeNode("node1");
            treeView1.Nodes.Add(node1);


            TreeNode node2 = new TreeNode("node2");
            treeView1.Nodes.Add(node2);

            TreeNode node21 = new TreeNode("node21");
            treeView1.Nodes.Add(node21);

            TreeNode node3 = new TreeNode("node3");
            treeView1.Nodes.Add(node3);


            TreeNode node4 = new TreeNode("node4");
            treeView1.Nodes.Add(node4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetNode("node2").Text.ToString());
            treeView1.Nodes.Remove(GetNode("node3"));
        }

        public TreeNode GetNode(string nodeText, TreeNode rootNode)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (node.Text.Equals(nodeText))
                    return node;
                TreeNode next = GetNode(nodeText, node);
                if (next != null)
                    return next;
            }
            return null;
        }

        public TreeNode GetNode(string nodeText)
        {
            TreeNode itemNode = null;
            foreach (TreeNode node in treeView1.Nodes)
            {
                if (node.Text.Equals(nodeText))
                    return node;
                itemNode = GetNode(nodeText, node);
                if (itemNode != null)
                    break;
            }
            return itemNode;
        }


    }
}
