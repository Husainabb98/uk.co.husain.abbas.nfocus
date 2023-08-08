using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.husain.abbas.nfocus.TestCases
{
    internal class Order : Utilities.TestBaseClass
    {
        [Test]
        public void MyOrder() 
        {
            Login login1 = new Login();
            login1.login();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            
            driver.FindElement(By.LinkText("Shop")).Click();
            driver.FindElement(By.XPath("//*[@id=\"main\"]/ul/li[3]/a[1]/img")).Click();
            driver.FindElement(By.XPath("//*[@id=\"product-29\"]/div[2]/form/button")).Click();
            driver.FindElement(By.XPath("//*[@id=\"site-header-cart\"]/li[1]/a")).Click();
            driver.FindElement(By.Id("coupon_code")).SendKeys("edgewords");
            driver.FindElement(By.XPath("//*[@id=\"post-5\"]/div/div/form/table/tbody/tr[2]/td/div/button")).Click();
            Thread.Sleep(2000);
            js.ExecuteScript("window.scrollBy(0,1450)", "");
            driver.FindElement(By.XPath("//*[@id=\"post-5\"]/div/div/div[2]/div/div/a")).Click();
            IWebElement fname = driver.FindElement(By.Id("billing_first_name"));
            IWebElement lname = driver.FindElement(By.Id("billing_last_name"));
            IWebElement address = driver.FindElement(By.Id("billing_address_1"));
            IWebElement city = driver.FindElement(By.Id("billing_city"));
            IWebElement postcode = driver.FindElement(By.Id("billing_postcode"));
            IWebElement phone = driver.FindElement(By.Id("billing_phone"));
            fname.Clear();
            fname.SendKeys("gogog");
            lname.Clear();
            lname.SendKeys("gg");
            address.Clear();
            address.SendKeys("gogogo street");
            city.Clear();
            city.SendKeys("gogogog city");
            postcode.Clear();
            postcode.SendKeys("SW15 4JQ");
            phone.Clear();
            phone.SendKeys("07777777777");
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//*[@id=\"place_order\"]")).Click();
            Thread.Sleep(1000);

            Screenshot screenshot = driver.TakeScreenshot();
            screenshot.SaveAsFile("C:\\Users\\HusainAbbas\\source\\repos\\Screenshot\\order.png");
            String order = driver.FindElement(By.XPath("//*[@id=\"post-6\"]/div/div/div/ul/li[1]/strong")).Text;

            driver.FindElement(By.XPath("//*[@id=\"menu-item-46\"]/a")).Click();
            driver.FindElement(By.XPath("//*[@id=\"post-7\"]/div/div/nav/ul/li[2]/a")).Click();

            String order2 = driver.FindElement(By.XPath("//*[@id=\"post-7\"]/div/div/div/table/tbody/tr[1]/td[1]/a")).Text;

            driver.FindElement(By.XPath("//*[@id=\"menu-item-46\"]/a")).Click();
            driver.FindElement(By.XPath("//*[@id=\"post-7\"]/div/div/div/p[1]/a")).Click();


            order2 = order2.Replace("#", "");
            bool correctOrder = false;

            if(order2 == order)
            {
                correctOrder = true;
            }
            Assert.IsTrue(correctOrder);


        }
    }
}
