using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           


            using (Process p = new Process())
            {
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = "ffmpeg.exe";
                p.StartInfo.Arguments = "-loop 1 -i image1.jpg -t 1 -s 384x288 -y sample1.avi";
                p.Start();
                p.WaitForExit();
          


                p.StartInfo.FileName = "ffmpeg.exe";
                p.StartInfo.Arguments = "-loop 1 -i image2.jpg -t 1 -s 384x288 -y sample2.avi";
                p.Start();
                p.WaitForExit();


                p.StartInfo.FileName = "ffmpeg.exe";
                p.StartInfo.Arguments = "-loop 1 -i image3.jpg -t 1 -s 384x288 -y sample3.avi";
                p.Start();
                p.WaitForExit();

                p.StartInfo.FileName = "ffmpeg.exe";
                p.StartInfo.Arguments = "-i sample1.avi -i sample2.avi -i sample3.avi -filter_complex [0:v:0][1:v:0]concat=n=3:v=1[outv] -map [outv] -y output.avi";
                p.Start();
                p.WaitForExit();
            }

            //Console.ReadKey();
        }



    }
}
