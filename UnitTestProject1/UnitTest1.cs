using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parcer;
using Parcer.Library;
using System.Net;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CookieContainer cookie = Parcer.Library.Parcer.EnterSite();
            Brand brand_Mercedes = new Brand("683", "Mercedes");
            Model model_Eclass = new Model("5884", "E-class");
            Generation gen_W211 = new Generation("4556", "W211");
            Query query_W211 = new Query() { BrandID = brand_Mercedes.ID, ModelID = model_Eclass.ID, GenerationID = gen_W211.ID };


            int countPages = 13;
            var countPagesActual = Parcer.Library.Parcer.GetCountPage(query_W211, cookie);

            Assert.AreEqual(countPages, countPagesActual);
        }
    }
}
