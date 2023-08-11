using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JpgToBitmapConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Folder to Convert!");
            string FolderToConvert = Console.ReadLine();
            Console.WriteLine("Select Output Folder");
            string OutputFolder = Console.ReadLine();
            Console.WriteLine(ConvertFolderContent(FolderToConvert, OutputFolder));
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
        public static string ConvertFolderContent(string FolderToConvert, string OutputFolder)
        {
            int i = 0;
            List<string> FilesToConvertJPG = new List<string>();
            List<string> FilesToConvertJPEG = new List<string>();
            DirectoryInfo Paths = new DirectoryInfo(FolderToConvert);
            List<FileInfo> FilesJPG = new List<FileInfo>();
            List<FileInfo> FilesJPEG = new List<FileInfo>();
            FilesJPG.AddRange(Paths.GetFiles("*.jpg").ToList());
            FilesJPEG.AddRange(Paths.GetFiles("*.jpeg").ToList());

            foreach (FileInfo File in FilesJPG)
            {
                FilesToConvertJPG.Add(FolderToConvert + "\\" + File.ToString());
            }

            foreach (FileInfo File in FilesJPEG)
            {
                FilesToConvertJPEG.Add(FolderToConvert + "\\" + File.ToString());
            }

            foreach (string File in FilesToConvertJPG)
            {
                using (Stream bmpStream = System.IO.File.Open(File, System.IO.FileMode.Open))
                {
                    Image image = Image.FromStream(bmpStream);
                    var bitmap = new Bitmap(image);
                    bitmap.Save(OutputFolder + "\\" + FilesJPG[i].ToString().Replace(".jpg", ".bmp"));
                    i++;
                }
            }
            i = 0;
            
            foreach (string File in FilesToConvertJPEG)
            {
                using (Stream bmpStream = System.IO.File.Open(File, System.IO.FileMode.Open))
                {
                    Image image = Image.FromStream(bmpStream);
                    var bitmap = new Bitmap(image);
                    bitmap.Save(OutputFolder + "\\" + FilesJPEG[i].ToString().Replace(".jpeg", ".bmp"));
                    i++;
                }
            }

            return "Sucess";
        }
    }
}
