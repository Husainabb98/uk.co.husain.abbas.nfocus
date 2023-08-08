using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.husain.abbas.nfocus.TestCases
{
    internal class CSS
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void SearchItem()
        {

            driver.Url = "https://flukeout.github.io/";
            
        }

    }
}
