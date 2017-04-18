using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Test
{
    public class Image
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public Image(string name, int size)
        {
            this.Name = name;
            this.Size = size;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            #region 数组操作
            //int[,] cous = new int[10, 4];
            //for (int i = 0; i < 10; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //        cous[i, j] = i * j;
            //}
            //Console.WriteLine(cous.Length);
            //for (int i = 0; i < 10; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        Console.Write(cous[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
            #endregion

            #region List操作

            List<Image> images = new List<Image>();

            images.Add(new Image("name1", 1));
            images.Add(new Image("name2", 2));
            images.Add(new Image("name3", 3));
            images.Add(new Image("name4", 4));
            images.Add(new Image("name5", 5));

            Console.WriteLine(images[1].Name);

            images.Insert(0, new Image("name0", 0));


            foreach (Image image in images)
            {
                Console.WriteLine("name " + image.Name + "  size " + image.Size);
            }


            #endregion

        }
    }
}
