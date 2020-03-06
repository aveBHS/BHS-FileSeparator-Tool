using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Builder
{
    [Serializable]
    public class FileBuilder
    {
        private string fileName;
        private List<Part> parts;
        private long size;
        private int partsCount;
        private string md5Hash = String.Empty;
        private long partSize;

        public FileBuilder() { }

        public FileBuilder(List<Part> parts, string fileName, long size, int partCount, long partSize)
        {
            this.parts = parts;
            this.fileName = fileName;
            this.size = size;
            this.PartsCount = partCount;
            this.partSize = partSize;
        }

        public FileBuilder(string fileName, long size, long partSize)
        {
            this.parts = new List<Part>();
            this.fileName = fileName;
            this.size = size;
            this.PartsCount = 0;
            this.partSize = partSize;
        }

        public string FileName { get { return fileName; } set { fileName = value; } }
        public string MD5Hash { get { return md5Hash; } set { md5Hash = value; } }
        public int PartsCount { get => partsCount; set => partsCount = value; }
        public long PartSize { get => partSize; set { partSize = value; } }
        public long FileSize { get { return size; } set { size = value; } }
        public List<Part> Parts { get { return parts; } set { parts = value; } }

        public static string CalcMD5(string path)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public void AddPart(Part part)
        {
            parts.Add(part);
            PartsCount++;
        }

        public void Build(string path, int ramRange)
        {
            string[] partsMassive = new string[partsCount];

            for (int i = 0; i < partsCount; i++)
            {
                partsMassive[i] = parts[i].FileName;
            }

            byte[] buffer = null;
            FileStream outFile = new FileStream(FileName, FileMode.Create);
            for (int i = 0; i < partsCount; i++)
            {
                FileStream source = new FileStream(partsMassive[i], FileMode.Open);
                if (ramRange < source.Length)
                {
                    buffer = new byte[ramRange];
                    for (int j = 0; j < source.Length; j += ramRange)
                    {
                        if (j + ramRange >= source.Length)
                        {
                            source.Read(buffer, 0, (int)source.Length - j);
                            outFile.Write(buffer, 0, (int)source.Length - j);
                            break;
                        }
                        source.Read(buffer, 0, ramRange);
                        outFile.Write(buffer, 0, (int)source.Length);
                    }
                }
                else
                {
                    buffer = new byte[source.Length];
                    source.Read(buffer, 0, (int)source.Length);
                    outFile.Write(buffer, 0, (int)source.Length);
                }
                Console.WriteLine($"-- Writed part #{i + 1} {source.Length} bytes");
                source.Close();
            }
        }
    }
}
