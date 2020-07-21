using BookswagonAutomation.Data;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BookswagonAutomation.Pages
{
    class SearchBook
    {
        IWebDriver driver;

        public SearchBook(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        [FindsBy(How = How.Id, Using = "ctl00_TopSearch1_txtSearch")]
        IWebElement searchBox;

        [FindsBy(How=How.Id, Using = "ctl00_TopSearch1_Button1")]
        IWebElement searchBtn;

        [FindsBy(How = How.XPath, Using = "//div[1]//div[4]//div[5]//a[1]//input[1]")]
        IWebElement buyBtn;

        [FindsBy(How = How.XPath, Using = "//iframe[@class='cboxIframe']")]
        public IWebElement placeOrderFrame;

        [FindsBy(How = How.Id, Using = "BookCart_lvCart_imgPayment")]
        public IWebElement placeorder;

        public void SearchBookPage()
        {
            JsonReader reader = new JsonReader();
            searchBox.SendKeys(reader.search);
            searchBtn.Click();
            Thread.Sleep(1000);
            buyBtn.Click();
            driver.SwitchTo().Frame(placeOrderFrame);
            placeorder.Click();
            Thread.Sleep(1000);
        }
    }
}
