using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO; // 删除到回收站引用
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

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
        /// 使用文件流创建BitMap加载图片
        /// </summary>
        /// <param name="path">图片的路径</param>
        /// <returns></returns>
        public static Bitmap GetImage(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            Bitmap bm = new Bitmap(fs);
            fs.Dispose();
            return bm;
        }            


        /// <summary>
        /// 根据指定的图片路径生成图片缩略图
        /// </summary>
        /// <param name="imgPath">图片的路径</param>
        /// <param name="imgSize">需要生成缩略图的大小 长，宽</param>
        /// <returns></returns>
        public static Bitmap GetThumbnailsImage(string imgPath, Size imgSize)
        {
            Bitmap bitMap = null;
            try
            {
                Bitmap loBMP = new Bitmap(imgPath);
                ImageFormat loFormat = loBMP.RawFormat;

                decimal lnRatio;
                int lnNewWidth = 0;
                int lnNewHeight = 0;

                //如果图像小于缩略图直接返回原图，因为upfront
                if (loBMP.Width < imgSize.Width && loBMP.Height < imgSize.Height)
                    return loBMP;

                if (loBMP.Width > loBMP.Height)
                {
                    lnRatio = (decimal)imgSize.Width / loBMP.Width;
                    lnNewWidth = imgSize.Width;
                    decimal lnTemp = loBMP.Height * lnRatio;
                    lnNewHeight = (int)lnTemp;
                }
                else
                {
                    lnRatio = (decimal)imgSize.Height / loBMP.Height;
                    lnNewHeight = imgSize.Height;
                    decimal lnTemp = loBMP.Width * lnRatio;
                    lnNewWidth = (int)lnTemp;
                }
                bitMap = new Bitmap(lnNewWidth, lnNewHeight);
                Graphics g = Graphics.FromImage(bitMap);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);
                g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);

                loBMP.Dispose();
            }
            catch
            {
                return null;
            }

            return bitMap;
        }

        /// <summary>
        /// 删除文件夹到回收站
        /// </summary>
        /// <param name="path">文件夹路径</param>
        public static void DeleteFile(string path)
        {
            if (File.Exists(path)) // file
                FileSystem.DeleteFile(path, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            else if (Directory.Exists(path)) // folder
                FileSystem.DeleteDirectory(path, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            else
                return;
        }

        /// <summary>
        /// 在 pictureBox 上的图片上创建 ContextMenuStrip (添加到收藏，从收藏删除)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static ContextMenuStrip CreateContextMenuStrip(string path)
        {
            ContextMenuStrip contextMenuStrip;
            ToolStripMenuItem deleteColl;
            ToolStripMenuItem addColl;
            ToolStripMenuItem deleteFile;

            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Name = "contextMenuStrip";

            addColl = new ToolStripMenuItem();
            addColl.Name = "AddCollection";
            addColl.Text = "添加收藏";
            addColl.Click += new EventHandler(addColl_click);
            addColl.Tag = path;

            contextMenuStrip.Items.Add(addColl);


            if (CollectionTool.FindByPath(path) == true)
            {
                deleteColl = new ToolStripMenuItem();
                deleteColl.Name = "DelCollection";
                deleteColl.Text = "删除收藏";
                deleteColl.Click += new EventHandler(deleteColl_click);
                deleteColl.Tag = path;
                contextMenuStrip.Items.Add(deleteColl);
            }


            deleteFile = new ToolStripMenuItem();
            deleteFile.Name = "Collection";
            deleteFile.Text = "删除文件";
            deleteFile.Click += new EventHandler(deleteFile_click);
            deleteFile.Tag = path;


            return contextMenuStrip;
        }

        private static void deleteFile_click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string path = item.Tag.ToString();
            DeleteFile(path);
        }

        private static void deleteColl_click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string path = item.Tag.ToString();
            CollectionTool.RemoveByPath(path);
        }

        private static void addColl_click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string path = item.Tag.ToString();
            Collection coll = new Collection()
            {
                Type = "Image",
                Path = path,
                Date = DateTime.Now.ToString()
            };
            CollectionTool.Add(coll);
        }

    }

}

