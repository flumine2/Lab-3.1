using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _2nd_Block
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex("^((bmp)|(gif)|(tiff?)|(jpe?g)|(png))$", RegexOptions.IgnoreCase);
            string[] strings = Directory.GetFiles(Directory.GetCurrentDirectory());
            foreach (String fileName in strings)
            {
                try
                {
                    Bitmap image = new Bitmap(fileName);
                    Bitmap mirrored = new Bitmap(image.Width, image.Height);
                    for (int i = 0; i < image.Width; i++)
                    {
                        for (int j = 0; j < image.Height; j++)
                        {
                            Color color = image.GetPixel(i, j);
                            mirrored.SetPixel(image.Width - i - 1, j, color);
                        }
                    }
                    mirrored.Save($"{fileName.Substring(0, fileName.Length - Path.GetExtension(fileName).Length)}-mirrored.gif", System.Drawing.Imaging.ImageFormat.Gif);
                }
                catch (Exception)
                {
                    if (regex.IsMatch(Path.GetExtension(fileName)))
                       MessageBox.Show($"File {fileName} - is not a image.");
                }
            }
        }
    }
}
