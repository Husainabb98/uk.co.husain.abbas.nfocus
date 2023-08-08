using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace uk.co.husain.abbas.nfocus.Utilities
{
    internal class TestBaseClass
    {
        private protected static IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            string Browser = Environment.GetEnvironmentVariable("BROWSER");

            switch (Browser)
            {
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    break;
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                case "remotechrome":
                    ChromeOptions options = new ChromeOptions();
                    driver = new RemoteWebDriver(new Uri("http://172.30.190.244:4444/wd/hub"), options);
                    break;
                default:
                    Console.WriteLine("No browser set - launching chrome");
                    driver = new ChromeDriver();
                    break;
            };



            driver.Manage().Window.Maximize();
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";

            driver.FindElement(By.CssSelector("body > p > a")).Click();
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
