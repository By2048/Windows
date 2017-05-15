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
        public static string[] GetAllImage(string folderPath)
        {
            string[] pictures = Directory.GetFiles(folderPath, "*.*").
                Where(tmp => tmp.EndsWith("jpg") ||
                tmp.EndsWith(".jpeg") ||
                tmp.EndsWith(".png")).
                ToArray();
            return pictures;
        }
    }
}
