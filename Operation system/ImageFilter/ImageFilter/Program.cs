using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilter
{
        
            static class Program
        {
            private static readonly string FileName = "input.bmp";
            private static int threadsCount;

        public static void Main(string[] args)
            {
                Console.WriteLine("Image filter\n");
                while (true)
                {
                Console.WriteLine($"Set image into folder, name it as '{FileName}' and press any button.");
                Console.ReadKey(true);

                    bool isImageExist = File.Exists(FileName);
                    if (isImageExist)
                        break;
                    Console.WriteLine("Please set image");
                
                }

                
            Console.WriteLine("Enter the number of threads (%2 = 0):");
            string inputString =  Console.ReadLine();
            threadsCount = Convert.ToInt32(inputString);


            Bitmap inputImage;
                var stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                inputImage = new Bitmap(stream);

                ClrConvertion converter = new ClrConvertion(threadsCount);
                Bitmap outputImage = converter.ApplyFilter(inputImage);
                String s = "output.bmp";
                outputImage.Save(s, ImageFormat.Bmp);
                Console.WriteLine("Complete. Get your image " + s + ".");
                Console.ReadKey(true);
            }
        }
        public class ClrConvertion
        {
            public int ThreadNums { get; private set; }

            private Bitmap[] m_BitmapParts;

            public ClrConvertion(int threadsCount)
            {
                ThreadNums = (int)threadsCount;
            }

            public Bitmap ApplyFilter(Bitmap target)
            {
                var outputBitmap = new Bitmap(target);

                m_BitmapParts = new Bitmap[ThreadNums];
                Thread[] threads = new Thread[ThreadNums];

                int widthPart = outputBitmap.Width / ThreadNums;

                int offset = 0;

                for (int i = 0; i < this.ThreadNums; i++)
                {
                    threads[i] = new Thread(Invertor);
                }

                Rectangle rectangle;
                for (int i = 0; i < this.ThreadNums; i++)
                {
                    rectangle = new Rectangle(offset, 0, widthPart, outputBitmap.Height);

                    m_BitmapParts[i] = outputBitmap.Clone(rectangle, target.PixelFormat);
                    threads[i].Start(m_BitmapParts[i]);

                    offset += widthPart;
                }

                foreach (Thread thread in threads)
                {
                    thread.Join();
                }

                using (Graphics graphics = Graphics.FromImage(outputBitmap))
                {
                    offset = 0;
                    foreach (Bitmap bitmap in m_BitmapParts)
                    {
                        graphics.DrawImage(bitmap, new Point(offset, 0));
                        offset += widthPart;
                    }
                }
                return outputBitmap;
            }
            public static void Invertor(object target)
            {
                Bitmap targ = (Bitmap)target;
                for (int x = 0; x < targ.Width; x++)
                {
                    for (int y = 0; y < targ.Height; y++)
                    {
                        Color pixel = targ.GetPixel(x, y);

                        targ.SetPixel(x, y, Color.FromArgb(
                            pixel.A,
                            Math.Max(0, pixel.R - 26),
                            Math.Max(0, pixel.G - 26),
                            Math.Max(0, pixel.B - 26)));
                    }
                }
            }
        }
    }
    

