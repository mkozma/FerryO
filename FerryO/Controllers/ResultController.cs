using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FerryO.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;

namespace FerryO.Controllers
{
    public class ResultController : Controller
    {
        public readonly IHostingEnvironment _hostingEnvironment;
        public ResultFile ResultFile { get; set;  }

        public ResultController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            ResultFile = new ResultFile(_hostingEnvironment);
        }
        public IActionResult Index()
        {            
            var results = ResultFile.Read();
            results.ResultsList = results.ResultsList
                .OrderByDescending(r => r.Score)
                .ThenByDescending(r => r.CourseTime).ToList();

            return View(results.ResultsList);
        }

        public IActionResult Create()
        {
            var result = new Result();
            return View(result);
        }
        [HttpPost]
        public IActionResult Create(Result model)
        {
            ResultFile.Write(model);
            return RedirectToAction("Index");
        }
    }
}