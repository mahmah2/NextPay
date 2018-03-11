using NP.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NP.OutputPayment
{
    public class FileOutputPayment : IOutputPayment
    {
        private string _fileName = "";
        public bool Config(string fileName)
        {
            try
            {
                _fileName = fileName;
                var dir = Path.GetDirectoryName(fileName);
                Directory.CreateDirectory(dir);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Save(string data)
        {
            try
            {
                if (string.IsNullOrEmpty(_fileName))
                    return false;

                using (StreamWriter writer = System.IO.File.AppendText(_fileName))
                {
                    writer.WriteLine(data);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
