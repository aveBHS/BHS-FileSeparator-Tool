using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace BHS_FileSeparator_Tool
{
    [Serializable]
    public class Part : IDisposable
    {
        private int size;
        //private string md5Hash;
        private string fileName;

        public Part(){ }

        public Part(int size, string fileName)
        {
            this.size = size;
            this.fileName = fileName;
            //md5Hash = PartMD5(bytes);
        }

        public void WriteByte(string file, byte[] byteForWrite)
        {
            FileStream partFile = new FileStream(file, FileMode.Append);
            partFile.Write(byteForWrite, 0, byteForWrite.Length);
            partFile.Close();
        }

        public void Build(string file, byte[] bytes)
        {
            FileStream partFile = new FileStream(file, FileMode.Append);
            partFile.Write(bytes, 0, size);
            partFile.Close();
        }


        public void Dispose() { }

        /*public string MD5Hash
        {
            get
            {
                return md5Hash;
            }
            set { md5Hash = value; }
        }*/

        public string FileName { get { return fileName; } set { fileName = value; } }
        public int Size { get { return size; } set { size = value; } }

        private string PartMD5(byte[] bytes)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(Encoding.Default.GetString(bytes).ToCharArray()));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}
