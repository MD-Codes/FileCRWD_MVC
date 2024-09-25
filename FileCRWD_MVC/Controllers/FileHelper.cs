using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Runtime.CompilerServices;

namespace FileCRWD_MVC.Controllers
{

    public class FileHelper
    {
        public List<string> Files { get; set; }
        private string myPath = @"C:\Users\matda\Desktop\Projects2024\ASP_Bootstrap_Loyaut\FileCRWD_MVC\FileCRWD_MVC\UserFiles\";
        public FileHelper() 
        {            
        }
        public FileInfo[] ListOfFiles()
        {            
                DirectoryInfo di = new DirectoryInfo(myPath);
                FileInfo[] fileInfos = di.GetFiles();                
                return fileInfos;
        }

        [HttpPost]
        public void CreateFile(string fileName)
        {
            string filepath = Path.Combine(myPath, fileName);
            if (!File.Exists(fileName))
            {
                using (StreamWriter sw = new StreamWriter(filepath))
                {
                    sw.WriteLine($"Data: {DateTime.Now}");
                }
            }
        }
        public string OpenFile(string fileName)
        {
            string content = File.ReadAllText(myPath+fileName);
            return content;
        }
        public void DeleteFileName(string fileName)
        {
            if (File.Exists(myPath+fileName))
            {
                File.Delete(myPath+fileName);
            }
        }
        public void SaveFile(string content, string fileName)
        {
            string filepath = Path.Combine(myPath, fileName);
            if (!File.Exists(filepath)) 
            {
                File.WriteAllText(filepath, content);
            }
            else
            {
                File.WriteAllText(filepath, content);
            }
        }
    }
}
