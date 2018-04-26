using System;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using FerryO.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Newtonsoft.Json;

namespace FerryO.Models
{
    public class File : IFile
    {
        private const string _path = @"\Data\Results.json";
        private readonly IHostingEnvironment _hostingEnvironment;
        public string FilePath { get; set; }

        public File(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            FilePath = hostingEnvironment.ContentRootPath + _path;
        }

        public string Read()
        {
            string json;
            try
            {
                using (var reader = new StreamReader(FilePath))
                {
                    json = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new FileNotFoundException();
            }
            
            return json;
        }

        public void Write(string json)
        {
            System.IO.File.WriteAllText(FilePath, json);
        }
    }
}
