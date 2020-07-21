﻿using BookswagonAutomation.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookswagonAutomation.Base
{
    class TestCases:BaseClass
    {
        [Test]
        public void BookswagonAutomationTest()
        {
            Login login = new Login(driver);
            login.LoginPage();

            SearchBook search = new SearchBook(driver);
            search.SearchBookPage();

            Cart cart = new Cart(driver);
            cart.CartPage();
        }
    }
}
