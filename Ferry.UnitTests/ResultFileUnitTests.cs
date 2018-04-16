using FerryO.Controllers;
using Microsoft.AspNetCore.Hosting.Internal;
using NUnit.Framework;

namespace Ferry.UnitTests
{
    [TestFixture]
    public class ResultFileTests
    {
        [Test]
        [Ignore("I'm not ready to test")]
        public void Results_WhenCalled_HasTheFileLocation()
        {
            var controller = new ResultController(new HostingEnvironment());
            var env = controller._hostingEnvironment.ContentRootPath;

            Assert.That(env, Is.Not.Null);
        }
    }
}
