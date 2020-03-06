using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace BHS_FileSeparator_Tool
{
    [Serializable]
    public class Part
    {
        private long size;
        private string md5Hash;
        private string fileName;

        public Part(){ }

        public Part(long size, string fileName)
        {
            this.size = size;
            this.fileName = fileName;
        }

        public void WriteByte(string file, byte[] byteForWrite)
        {
            FileStream partFile = new FileStream(file, FileMode.Append);
            partFile.Write(byteForWrite, 0, byteForWrite.Length);
            partFile.Close();
        }

        public string MD5Hash { get { return md5Hash; } set { md5Hash = value; } }
        public string FileName { get { return fileName; } set { fileName = value; } }
        public long Size { get { return size; } }
    }
}
