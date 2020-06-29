using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace decrypt
{
    class Program
    {
        private static List<string> keyList = new List<String>();
        private static List<string> txtList = new List<String>();

        static void Main(string[] args)
        {
            genKey generator = new genKey();
            keyList = generator.GetList();

            Console.WriteLine(keyList.Count);

            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Arnaud RIGAUT\Desktop\exia\projet dev\txt");
            foreach (var fi in di.GetFiles())
            {
                Console.WriteLine(fi.Name);
                txtList.Add(fi.Name);
            }

            XorCracker x = new XorCracker(keyList);

            Parallel.ForEach(txtList, (currentFile) =>
            {
                string filename = Path.GetFileName(currentFile);
                string filecontent = File.ReadAllText($"C:\\Users\\Arnaud RIGAUT\\Desktop\\exia\\projet dev\\txt\\{currentFile}");
                x.test(filecontent);
            });
        }
    }
}
