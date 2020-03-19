using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.DataAccess.Utility
{
    public class FilePathConverter : IValueConverter<string, byte[]>
    {
        public byte[] Convert(string sourceMember, ResolutionContext context)
        {
            if (sourceMember != null)
            {
                byte[] data = File.ReadAllBytes(sourceMember);
                return data;
            }
            return null;
        }
    }
}
