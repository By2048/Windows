using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO; // 删除到回收站引用
using System.Windows.Forms;

namespace PictureViewer
{
    public static class ImageTool
    {
        public static string[] GetAllImagePath(string folderPath)
        {
            string[] picturePaths = Directory.GetFiles(folderPath, "*.*").
                                Where(tmp => tmp.EndsWith("jpg") ||
                                tmp.EndsWith(".jpeg") ||
                                tmp.EndsWith(".png")).
                                ToArray();
            return picturePaths;
        }

        public static FileInfo[] GetFilesByDir(DirectoryInfo info)
        {
            FileInfo[] imgs = info.GetFiles("*.*").
                              Where(tmp => tmp.Name.EndsWith("jpg") ||
                              tmp.Name.EndsWith(".jpeg") ||
                              tmp.Name.EndsWith(".png")).
                              ToArray();
            return imgs;
        }

        /// <summary>
        /// 删除文件夹到回收站
        /// </summary>
        /// <param name="path">文件夹路径</param>
        public static void Delete(string path)
        {
            if (File.Exists(path)) // file
                FileSystem.DeleteFile(path, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            else if (Directory.Exists(path)) // folder
                FileSystem.DeleteDirectory(path, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            else
                return;
        }

        public static ContextMenuStrip CreateContextMenuStrip(string path)
        {
            ContextMenuStrip contextMenuStrip;
            ToolStripMenuItem delete;
            ToolStripMenuItem collection;

            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Name = "contextMenuStrip";

            delete = new ToolStripMenuItem();
            delete.Name = "Delete";
            delete.Text = "删除";
            delete.Click += new EventHandler(Delete_click);
            delete.Tag = path;

            collection = new ToolStripMenuItem();
            collection.Name = "Collection";
            collection.Text = "添加收藏";
            collection.Click += new EventHandler(Collection_click);
            collection.Tag = path;

            contextMenuStrip.Items.AddRange(
                new ToolStripItem[] {
                delete,
                collection,
            });
            return contextMenuStrip;
        }
        private static void Delete_click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string path = item.Tag.ToString();
            Delete(path);
        }
        private static void Collection_click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string path = item.Tag.ToString();
        }

    }
}
