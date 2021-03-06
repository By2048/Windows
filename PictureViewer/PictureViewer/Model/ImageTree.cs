﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureViewer
{
    public class ImageTree
    {
        public string Name;
        public string FullPath;
        public NodeType NodeType;
        public ImageTree(string name, string fullPath, NodeType nodeType)
        {
            Name = name;
            FullPath = fullPath;
            NodeType = nodeType;
        }
        public override string ToString()
        {
            return Name + "\n" + FullPath + "\n" + NodeType.ToString();
        }
    }
}
