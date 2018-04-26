using System.IO;
using System.Reflection;
using FerryO.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Moq;
using NUnit.Framework;
using File = FerryO.Models.File;

namespace Ferry.UnitTests
{
    [TestFixture]
    public class FileUnitTests
    {

        [Test]
        public void FilePath_ReturnsCorrectFilePath()
        {
            var file = new FerryO.Models.File(new HostingEnvironment());

            var result = file.FilePath;

            Assert.That(result,Contains.Substring(@"\Data\Results.json"));

        }
       

    }
}
