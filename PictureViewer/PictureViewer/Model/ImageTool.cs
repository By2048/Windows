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
        public static Bitmap LoadImage(string path)
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
        public static Bitmap GetThumbnailsImg(string imgPath, Size imgSize)
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
