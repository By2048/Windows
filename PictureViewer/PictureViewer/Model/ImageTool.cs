using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO; // 删除到回收站引用

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
        /// <param name="folderPath">文件夹路径</param>
        public static void DelFolder(string folderPath)
        {
            FileSystem.DeleteDirectory(folderPath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
        }

        /// <summary>
        /// 删除文件到回收站
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public static void DelFile(string filePath)
        {
            FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
        }

    }
}
