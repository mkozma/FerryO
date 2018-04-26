using FerryO.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.AspNetCore.Hosting.Internal;

namespace FerryO.Controllers
{

    public class ResultFile
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IFile _file;

        public ResultFile(IHostingEnvironment hostingEnvironment,IFile file = null)
        {
            _hostingEnvironment = hostingEnvironment;
            _file = file ?? new File(_hostingEnvironment);
        }

        public Results Read()
        {
            var json = _file.Read();
            return json.Length == 0 ? 
                null : JsonConvert.DeserializeObject<Results>(json);
        }

        public void Write(Result result)
        {
            var results = Read();
            var json = ParseResult(result, results);
            _file.Write(json);
        }

        public static string ParseResult(Result result, Results results)
        {
            result.Id = ResultFile.GetNextEntryNumber(results);
            results.ResultsList.Add(result);
            var newJson = JsonConvert.SerializeObject(results);
            return newJson;
        }

        public static int GetNextEntryNumber(Results results)
        {
            return results?.ResultsList.Max(r => r.Id) + 1 ?? 1;
        }
    }
}