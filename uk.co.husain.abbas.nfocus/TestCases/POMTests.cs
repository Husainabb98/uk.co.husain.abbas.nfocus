using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.husain.abbas.nfocus.POMPages;
using uk.co.husain.abbas.nfocus.Utilities;

namespace uk.co.husain.abbas.nfocus.TestCases
{
    internal class POMTests : TestBaseClass
    {
        [Test]
        //[Ignore("ignore this test")]

        public void LoginUnsingThePOM()
        {
            
            

            
            LoginPagePOM login = new LoginPagePOM(driver);
            
            bool wasLoginSuccessful = login.LoginWithValidCredentials("hee@test.co.uk", "Testing123456!");
            
            Assert.That(wasLoginSuccessful, Is.True);
        }

        [Test]
        //[Ignore("ignore this test")]
        public void InvalidLoginsSHouldFail()
        {
            
            
            LoginPagePOM login = new LoginPagePOM(driver);
            bool didLoginFail = login.AttemptLoginWithInvalidDetails("asdfhasdf", "zsdfhszfdh");
            Assert.That(didLoginFail, Is.True);
        }
        [Test]
        //[Ignore("ignore this test")]

        public void vaildCoupon()
        {
            

            LoginPagePOM login = new LoginPagePOM(driver);
            bool wasLoginSuccessful = login.LoginWithValidCredentials("hee@test.co.uk", "Testing123456!");

            MyAccountPOM myAccount = new MyAccountPOM(driver);

            myAccount.shop();
            Thread.Sleep(500);
            
            ShopPOM shop = new ShopPOM(driver);
            shop.addAndViewCart();
            Thread.Sleep(5000);
            CartPOM cart = new CartPOM(driver);
            cart.enterAndApplyCoupon();
            Thread.Sleep(5000);
            decimal expectedTotal =cart.retrieveExpectedTotal();
            decimal actualTotal = cart.retrieveTotal();
            Assert.That(expectedTotal, Is.EqualTo(actualTotal), 
                "Didn't get the expected total");

        }
        [Test]
        //[Ignore("ignore this test")]
        public void orderNumber() 
        {
            LoginPagePOM login = new LoginPagePOM(driver);
            bool wasLoginSuccessful = login.LoginWithValidCredentials("hee@test.co.uk", "Testing123456!");

            MyAccountPOM myAccount = new MyAccountPOM(driver);

            myAccount.shop();
            

            ShopPOM shop = new ShopPOM(driver);
            shop.addAndViewCart();
            
            CartPOM cart = new CartPOM(driver);
            cart.enterAndApplyCoupon();
            cart.proceedToCheckOut();
            
            CheckOutPOM check = new CheckOutPOM(driver);
            check.enterInformation();
            
            OrderPOM order = new OrderPOM(driver);
            string actualOrderNumber = order.orderNumber();
            order.myAccount();
            

            string expectedOrderNumber =myAccount.expectedOrderNumber();
            
            Thread.Sleep(1000);
            Assert.That(expectedOrderNumber, Is.EqualTo(actualOrderNumber),
               "Didn't get the expected order number");



        }
    }
}