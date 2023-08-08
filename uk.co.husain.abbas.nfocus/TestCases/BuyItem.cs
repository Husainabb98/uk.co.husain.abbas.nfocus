using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.husain.abbas.nfocus.TestCases
{
    internal class BuyItem : Utilities.TestBaseClass
    {
        [Test]
        public void item()
        {
            Login login = new Login();
            login.login();
            driver.FindElement(By.LinkText("Shop")).Click();
            driver.FindElement(By.XPath("//*[@id=\"main\"]/ul/li[3]/a[1]/img")).Click();
            driver.FindElement(By.XPath("//*[@id=\"product-29\"]/div[2]/form/button")).Click();
            driver.FindElement(By.XPath("//*[@id=\"site-header-cart\"]/li[1]/a")).Click();
            driver.FindElement(By.Id("coupon_code")).SendKeys("edgewords");
            driver.FindElement(By.XPath("//*[@id=\"post-5\"]/div/div/form/table/tbody/tr[2]/td/div/button")).Click();

            String price = driver.FindElement(By.XPath("//*[@id=\"post-5\"]/div/div/div[2]/div/table/tbody/tr[1]/td/span/bdi")).Text;
            String total = driver.FindElement(By.XPath("//*[@id=\"post-5\"]/div/div/div[2]/div/table/tbody/tr[4]/td/strong/span/bdi")).Text;
            price = price.Replace("£", "");
            //driver.FindElement(By.XPath("//*[@id=\"search-2\"]/form/label/input")).SendKeys(price);
            total = total.Replace("£", "");
            driver.FindElement(By.XPath("//*[@id=\"search-2\"]/form/label/input")).SendKeys(total);
            double price1 = Convert.ToDouble(price);
            double total2 = Convert.ToDouble(total);
            driver.FindElement(By.XPath("//*[@id=\"menu-item-46\"]/a")).Click();
            driver.FindElement(By.XPath("//*[@id=\"post-7\"]/div/div/div/p[1]/a")).Click();




            bool totalPrice = false;
            if (price1*0.85 + 3.95 == total2)
            {
                totalPrice = true;
            }
            Assert.IsTrue(totalPrice);
        }
    }
}
