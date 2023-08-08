using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.husain.abbas.nfocus.TestCases
{
    internal class ProductSearch : Utilities.TestBaseClass
    {
        

        [Test, Category("Functional")]
        public void SearchItem()
        {
            
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            Console.WriteLine(driver.Url);
            driver.FindElement(By.Id("woocommerce-product-search-field-0")).SendKeys("Cap");
            driver.FindElement(By.Id("woocommerce-product-search-field-0")).SendKeys(Keys.Enter);
            Console.WriteLine(driver.Url);
            Screenshot screenshot = driver.TakeScreenshot();
            screenshot.SaveAsFile("C:\\Users\\HusainAbbas\\source\\repos\\Screenshot\\Fullpage.png");
           // Assert.That(driver.Url, Is.EqualTo("https://www.edgewordstraining.co.uk/demo-site/product/cap/"));
        }
    }
}
