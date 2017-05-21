using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpTest
{
    class Program
    {
        static void Main()
        {
            List<string> pp = new List<string>();
            for (int i = 0; i < 5; i++)
                pp.Add(i.ToString());
            foreach (string p in pp)
                Console.WriteLine(p);
            Console.WriteLine("--------");
            Console.WriteLine(pp.Count.ToString());
        }

    }
}
