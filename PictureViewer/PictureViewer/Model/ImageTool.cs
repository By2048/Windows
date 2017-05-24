using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static FileInfo[] GetFilesByPath(string filePath)
        {
            DirectoryInfo info = new DirectoryInfo(filePath);
            FileInfo[] imgs = info.GetFiles("*.*").
                              Where(tmp => tmp.Name.EndsWith("jpg") ||
                              tmp.Name.EndsWith(".jpeg") ||
                              tmp.Name.EndsWith(".png")).
                              ToArray();
            return imgs;
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

    }
}
