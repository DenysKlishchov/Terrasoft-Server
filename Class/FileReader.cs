using ASPControl.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ASPControl.Class
{
    public class FileReader : ITextReader
    {
        private string _path;
        public event Action<char> CharRead;

        public FileReader(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException("File not exist", nameof(path));
            }
            _path = path;
        }


        public void Read()
        {
            using (FileStream fs = File.Open(_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    CharRead?.Invoke(Convert.ToChar(13));
                    foreach (char c in line)
                        CharRead?.Invoke(c);
                }


            }
        }
    }
}