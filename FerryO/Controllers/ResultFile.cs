using FerryO.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace FerryO.Controllers
{

    public class ResultFile
    {
        private const string Path = @"\Data\Results.json";

        private IHostingEnvironment _hostingEnvironment;

        public string FilePath { get; set; }

        public ResultFile(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            FilePath = _hostingEnvironment.ContentRootPath + Path;
        }

        public Results Read()
        {
            var json = string.Empty;
            
            using (StreamReader reader = new StreamReader(FilePath))
            {
                json = reader.ReadToEnd();
            }
     

            if (json.Length == 0)
                return null;

            return JsonConvert.DeserializeObject<Results>(json);
           
        }

        public void Write(Result result)
        {
            var json = string.Empty;
            Results results = null;
            using (StreamReader reader = new StreamReader(FilePath))
            {
                json = reader.ReadToEnd();
            }

            if (String.IsNullOrEmpty(json))
            {
                results = new Results();
                results.ResultsList = new List<Result>();
            }
            else
            {

                results = JsonConvert.DeserializeObject<Results>(json);
            }

            result.Id = GetNextEntryNumber(results);
            results.ResultsList.Add(result);
            string newJson = JsonConvert.SerializeObject(results);
            File.WriteAllText(FilePath, newJson);


        }

        public int GetNextEntryNumber(Results results)
        {
            return  (results == null)? 1: results.ResultsList.Max(r => r.Id) + 1;
        }

    }
}