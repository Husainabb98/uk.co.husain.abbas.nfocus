using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.husain.abbas.nfocus.TestCases
{
    internal class Login : Utilities.TestBaseClass
    {
        [Test]
        public void login()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";
            driver.FindElement(By.Id("username")).SendKeys("hee@test.co.uk");
            driver.FindElement(By.Id("password")).SendKeys("Testing123456!");
            driver.FindElement(By.Id("password")).SendKeys(Keys.Enter);



        }
      


    }
}
