using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.husain.abbas.nfocus.TestCases
{
    internal class HelloWebDriver
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
        public void FirstTest()
        {


            Console.WriteLine("Start Test");
            driver.Url = "https://www.edgewordstraining.co.uk/webdriver2";
            driver.FindElement(By.LinkText("Login To Restricted Area")).Click();
            string headingText = driver.FindElement(By.CssSelector("#right-column > h1:nth-child(1)")).Text;
            Console.WriteLine(headingText);
            driver.FindElement(By.CssSelector("#password")).SendKeys("edgewords123");
            driver.FindElement(By.CssSelector("#username")).SendKeys("edgewords");
            driver.FindElement(By.LinkText("Submit")).Click();
            Console.WriteLine("End Test");
        }

        [Test]
        public void DragDropTest()
        {



        }
    }
}
