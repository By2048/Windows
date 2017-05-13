using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormTest
{
    public class ImageTree
    {
        public string Name;
        public string FullPath;
        public bool IsFolder;
        public ImageTree(string name, string fullPath,bool isFolder)
        {
            Name = name;
            FullPath = fullPath;
            IsFolder = isFolder;
        }
        public  override string ToString()
        {
            return Name + "\n" + FullPath + "\n" + IsFolder.ToString();
        }
    }
}
