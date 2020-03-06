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

        public void Build(string path)
        {

            string[] partsMassive = new string[partsCount];
            for (int i = 0; i < partsCount; i++)
            {
                partsMassive[i] = parts[i].FileName;
            }
            byte[] buffer = new byte[partSize];
            FileStream outFile = new FileStream(path + FileName, FileMode.Create);
            for (int i = 0; i < partsCount; i++)
            {
                /*if (!(i + 1 < partsCount))
                {
                    int lastPartSize = ((int)size - ((partsCount - 1) * partSize));
                    FileStream lastSource = new FileStream(path + partsMassive[i], FileMode.Open);
                    lastSource.Read(buffer, 0, lastPartSize);
                    outFile.Write(buffer, 0, buffer.Length);
                    lastSource.Close();
                    break;
                }*/

                FileStream source = new FileStream(path + partsMassive[i], FileMode.Open);
                source.Read(buffer, 0, (int)source.Length);
                Console.WriteLine("Readed " + (source.Length / 1024 / 1024) + " mb");
                outFile.Write(buffer, 0, (int)source.Length);
                source.Close();
            }
        }
    }
}
