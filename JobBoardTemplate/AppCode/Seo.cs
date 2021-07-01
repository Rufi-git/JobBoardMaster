using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace JobBoardTemplate.AppCode
{
    public class Seo
    {
        public static string MakeTheFileName(string fileName)
        {
            string filePath = Path.GetFileNameWithoutExtension(fileName);
            string path = Path.GetExtension(fileName);
            return filePath + path;
        }
    }
}