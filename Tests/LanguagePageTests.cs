using AventStack.ExtentReports;
using Project_Mars_NUnit.Drivers;
using Project_Mars_NUnit.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars_NUnit.Tests
{
    [TestFixture]
    public class LanguagePageTests : CommonDriver
    {
        private LanguagePage _languagePage;
        private ExtentTest test;

        [SetUp]
        public void Setup()
        {

            driver = CommonDriver.InitDriver();

            test = TestHooks.extent.CreateTest(TestContext.CurrentContext.Test.Name);

            LoginPage loginPageObj = new LoginPage(driver);
            loginPageObj.Login("test@test.com", "123123");

            _languagePage = new LanguagePage(driver);
            _languagePage.DeleteAllLanguages();

        }

    }
}
