﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.husain.abbas.nfocus.POMPages
{
    internal class CartPOM
    {
        private IWebDriver _driver;

        public CartPOM(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement _coupon => _driver.FindElement(By.Id("coupon_code"));
        private IWebElement _applyCoupon => _driver.FindElement(By.CssSelector("#post-5 > div > div > form > table > tbody > tr:nth-child(2) > td > div > button"));
        private IWebElement _total => _driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.order-total > td > strong > span > bdi"));
        private IWebElement _subTotal => _driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.cart-subtotal > td > span > bdi"));
        private IWebElement _proceedToCheckout => _driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > div > a"));
        public void enterAndApplyCoupon()
        {
            _coupon.SendKeys("edgewords");
            _applyCoupon.Click();
        }

        public decimal retrieveExpectedTotal()
        {
            string total = _total.Text;
            total = total.Replace("£", "");
            string subTotal = _subTotal.Text;
            subTotal = subTotal.Replace("£", "");
            decimal total1 = Convert.ToDecimal(total);
            decimal subTotal1 = Convert.ToDecimal(subTotal);
            decimal expectedTotal = subTotal1 *0.85m + 3.95m;
            return expectedTotal;
        }
        public decimal retrieveTotal() 
        {
            string total = _total.Text;
            total = total.Replace("£", "");
            decimal total1 = Convert.ToDecimal(total);
            return total1;


        }
        public void proceedToCheckOut()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollBy(0,1450)", "");
            _proceedToCheckout.Click();
        }
    }
}
