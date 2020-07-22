using BookswagonAutomation.Data;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookswagonAutomation.Pages
{
    class ShippingAddress
    {
        public IWebDriver driver;
        public ShippingAddress(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

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

        public void ShippingAddressPage()
        {
            JsonReader reader = new JsonReader();
            receipientName.SendKeys(reader.receipentName);
            address.SendKeys(reader.address);
            state.SendKeys(reader.state);
            city.SendKeys(reader.city);
            pinCode.SendKeys(reader.pincode);
            mobileNo.SendKeys(reader.mobileno);
            saveAndContinueBtn.Click();
        }
    }
}
