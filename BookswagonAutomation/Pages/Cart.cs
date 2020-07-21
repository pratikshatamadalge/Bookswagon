using BookswagonAutomation.Data;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BookswagonAutomation.Pages
{
    class Cart
    {
        IWebDriver driver;

        public Cart(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "btn-red")]
        IWebElement continueBtn;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_txtNewRecipientName")]
        IWebElement receipientName;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_txtNewAddress")]
        IWebElement address;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_ddlNewState")]
        IWebElement state;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_txtNewCity")]
        IWebElement city;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_txtNewPincode")]
        IWebElement pinCode;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_txtNewMobile")]
        IWebElement mobileNo;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_imgSaveNew")]
        IWebElement saveAndContinueBtn;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_ShoppingCart_lvCart_txtGiftMessage")]
        IWebElement giftMessage;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_ShoppingCart_lvCart_savecontinue")]
        IWebElement saveAndContinueBtn1;

        [FindsBy(How = How.Id, Using = "checkout-header")]
        IWebElement header;

        [FindsBy(How = How.CssSelector, Using = "#ctl00_lnkbtnLogout")]
        IWebElement logoutBtn;

        public void CartPage()
        {
            JsonReader reader = new JsonReader();
            continueBtn.Click();
            receipientName.SendKeys(reader.receipentName);
            address.SendKeys(reader.address);
            state.SendKeys(reader.state);
            city.SendKeys(reader.city);
            pinCode.SendKeys(reader.pincode);
            mobileNo.SendKeys(reader.mobileno);
            saveAndContinueBtn.Click();
            giftMessage.SendKeys(reader.giftmessage);
            saveAndContinueBtn1.Click();
            logoutBtn.Click();
            Thread.Sleep(2000);
        }
    }
}
