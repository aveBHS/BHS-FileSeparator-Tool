using System;
using System.IO;
using System.Xml.Serialization;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"BHS FileSperator Tool. Crossplatform builder v.1.0 {Environment.NewLine}");
            if (!File.Exists(".build"))
            {
                Console.WriteLine($"Can't find build file (.build)!{Environment.NewLine}Press any key to exit.");
                Console.ReadKey();
                return;
            }
            StreamReader buildFile = new StreamReader(".build");
            XmlSerializer xml = new XmlSerializer(typeof(FileBuilder));
            FileBuilder builder = (FileBuilder) xml.Deserialize(buildFile);

            //Output file information
            Console.WriteLine($"Source file information:");
            Console.WriteLine($"-- File name: {builder.FileName}");
            Console.WriteLine($"-- File size: {builder.FileSize} bytes");
            Console.WriteLine($"-- Part size: {builder.PartSize} bytes");
            Console.WriteLine($"-- Parts count: {builder.PartsCount} bytes");
            if(string.IsNullOrWhiteSpace(builder.MD5Hash))
                Console.WriteLine($"-- MD5 Checksum: No");
            else
                Console.WriteLine($"-- MD5 Checksum: Yes");
            //End of information block

            Console.Write($"{Environment.NewLine}Continue building? [Y/n] >> ");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.Write($"{Environment.NewLine}Input RAM using range (standart - 128MB, don't be more 1GB) [bytes] >> ");
                string temp = Console.ReadLine();
                int ramRange = 0;

                if (int.TryParse(temp, out ramRange))
                {
                    if (ramRange > 1073741824)
                    {
                        Console.WriteLine($"Invalid input, will be used standart range (128 MB).");
                        ramRange = 134217728;
                    }
                }
                else if (string.IsNullOrWhiteSpace(temp))
                {
                    Console.WriteLine($"Empty input, will be used standart range (128 MB).");
                    ramRange = 134217728;
                }
                else
                {
                    Console.WriteLine($"Invalid input, will be used standart range (128 MB).");
                    ramRange = 134217728;
                }
                Console.WriteLine($"{Environment.NewLine}Starting building file...");
                builder.Build(builder.FileName, ramRange);

                Console.WriteLine($"Building successfully complated!{Environment.NewLine}Press any key to exit.");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine($"{Environment.NewLine}Aborted by user.{Environment.NewLine}Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
