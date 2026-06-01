using AventStack.ExtentReports;
using Microsoft.Testing.Platform.Requests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Project_Mars_NUnit.Drivers;
using Project_Mars_NUnit.Models;
using Project_Mars_NUnit.Pages;
using Project_Mars_NUnit.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars_NUnit.Tests
{
    [TestFixture]
    public class NotificationPageTests : CommonDriver
    {
        private ExtentTest test;
        private ShareSkillPage _shareskillpage;
        private ManageListings _manageListings;
        private NotificationPage notificationPage;
        private SearchSkillPage _searchskillpage;
        private SkillDetailsPage skillDetailsPage;
       

        [SetUp]

        public void Setup()

        {
            driver = CommonDriver.InitDriver();

            test = TestHooks.extent.CreateTest(TestContext.CurrentContext.Test.Name);

            LoginPage loginPageObj = new LoginPage(driver);
            loginPageObj.Login("test@test.com", "123123");

            notificationPage = new NotificationPage(driver);
            notificationPage.OpenNotifications();
            notificationPage.ClearAllNotifications();
            notificationPage.NavigateToManageListings();

            _manageListings = new ManageListings(driver);
            _manageListings.DeleteAllShareSkillListings(driver);

            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToShareSkillPage(driver);
            _shareskillpage = new ShareSkillPage(driver);

            var shareSkillData = JsonReader.LoadJson<ShareSkillData>(@"TestData\AddNewShareSkill.json");
            _shareskillpage = new ShareSkillPage(driver);
            _shareskillpage.CreateSkill(shareSkillData);

        }

        [Test]

        public void NotificationShowLessLoadMore()

        {
            // Create second driver for trigger user
            IWebDriver triggerDriver = CommonDriver.InitDriver();
            LoginPage triggerLogin = new LoginPage(triggerDriver);
            triggerLogin.Login("lakshmi.v@gmail.com", "123123");

            // Navigate to the main user's skill and trigger notifications
            HomePage triggerHome = new HomePage();
            triggerHome.NavigateToProfileShareSkillPage(triggerDriver);

            SkillDetailsPage triggerSearch = new SkillDetailsPage(triggerDriver);

            // Loop 6 times to generate 6 notifications
            for (int i = 0; i < 6; i++)
            {
                _searchskillpage = new SearchSkillPage(triggerDriver);
                _searchskillpage.ClickSearchSkills();
                _searchskillpage.ClickSkills();

                if (i % 2 == 0)
                {
                 

                    // Request → auto accepted
                    triggerSearch.EnterMessage($"I'm interested - Notification {i + 1}");
                    triggerSearch.AddHours();
                    triggerSearch.ClickRequest();
                    triggerSearch.ClickYes();
                }
                else
                {
                    Thread.Sleep(3000);
                    // Withdraw
                    triggerSearch.ClickWithdraw();
                   
                }

                // Optional: small wait for server processing
                Thread.Sleep(1000);

                // Go back to search page to repeat
                triggerHome.NavigateToServiceShareSkillPage(triggerDriver);
            }


            triggerDriver.Quit();
            Thread.Sleep(3000);
            driver.Navigate().GoToUrl(driver.Url);
            notificationPage = new NotificationPage(driver);

            notificationPage.OpenNotificationsServiceListing();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));


            //If Load More appears, click it

            notificationPage.ClickLoadMore();
            Thread.Sleep(3000);
                Assert.That(notificationPage.GetNotificationCount(), Is.GreaterThan(5));
           

            //Click Show Less
            notificationPage.ClickShowLess();
            //Verify collapsed back to 1
            Assert.That(notificationPage.GetNotificationCount(), Is.EqualTo(1));

        }
        [Test]
        public void NotificationMarkAllAsRead()

        {
            // Create second driver for trigger user
            IWebDriver triggerDriver = CommonDriver.InitDriver();
            LoginPage triggerLogin = new LoginPage(triggerDriver);
            triggerLogin.Login("lakshmi.v@gmail.com", "123123");

            // Navigate to the main user's skill and trigger notifications
            HomePage triggerHome = new HomePage();
            triggerHome.NavigateToProfileShareSkillPage(triggerDriver);

            SkillDetailsPage triggerSearch = new SkillDetailsPage(triggerDriver);

            // Loop 6 times to generate 6 notifications
            for (int i = 0; i < 6; i++)
            {
                _searchskillpage = new SearchSkillPage(triggerDriver);
                _searchskillpage.ClickSearchSkills();
                _searchskillpage.ClickSkills();

                if (i % 2 == 0)
                {


                    // Request → auto accepted
                    triggerSearch.EnterMessage($"I'm interested - Notification {i + 1}");
                    triggerSearch.AddHours();
                    triggerSearch.ClickRequest();
                    triggerSearch.ClickYes();
                }
                else
                {
                    Thread.Sleep(3000);
                    _searchskillpage.ClickSearchSkills();
                    _searchskillpage.ClickSkills();
                    // Withdraw
                    triggerSearch.ClickWithdraw();

                }

                // Optional: small wait for server processing
                Thread.Sleep(1000);

                // Go back to search page to repeat
                triggerHome.NavigateToServiceShareSkillPage(triggerDriver);
            }
            triggerDriver.Quit();
            Thread.Sleep(3000);
            driver.Navigate().GoToUrl(driver.Url);
            notificationPage = new NotificationPage(driver);
            notificationPage.ClickNotifications();
            notificationPage.MarkAllAsRead();
            notificationPage.AssertBlueLabelNotPresent();
            notificationPage.OpenNotificationsServiceListing();

        }

        [Test]
        public void NotificationMarkSelectionAsRead()

        {
            // Create second driver for trigger user
            IWebDriver triggerDriver = CommonDriver.InitDriver();
            LoginPage triggerLogin = new LoginPage(triggerDriver);
            triggerLogin.Login("lakshmi.v@gmail.com", "123123");

            // Navigate to the main user's skill and trigger notifications
            HomePage triggerHome = new HomePage();
            triggerHome.NavigateToProfileShareSkillPage(triggerDriver);

            SkillDetailsPage triggerSearch = new SkillDetailsPage(triggerDriver);

            
                _searchskillpage = new SearchSkillPage(triggerDriver);
                _searchskillpage.ClickSearchSkills();
                _searchskillpage.ClickSkills();

              
                    triggerSearch.EnterMessage($"I'm interested - Notification");
                    triggerSearch.AddHours();
                    triggerSearch.ClickRequest();
                    triggerSearch.ClickYes();
          
                // Optional: small wait for server processing
                Thread.Sleep(3000);


            triggerDriver.Quit();
            Thread.Sleep(3000);
            driver.Navigate().GoToUrl(driver.Url);
            notificationPage = new NotificationPage(driver);
            notificationPage.OpenNotificationsServiceListing();
            notificationPage.ClickCheckbox();
            notificationPage.MarkSelectionAsRead();
            notificationPage.AssertBlueLabelNotPresent();
            

        }

        [Test]
        public void NotificationSelectandUnselect()

        {
            // Create second driver for trigger user
            IWebDriver triggerDriver = CommonDriver.InitDriver();
            LoginPage triggerLogin = new LoginPage(triggerDriver);
            triggerLogin.Login("lakshmi.v@gmail.com", "123123");

            // Navigate to the main user's skill and trigger notifications
            HomePage triggerHome = new HomePage();
            triggerHome.NavigateToProfileShareSkillPage(triggerDriver);

            SkillDetailsPage triggerSearch = new SkillDetailsPage(triggerDriver);


            _searchskillpage = new SearchSkillPage(triggerDriver);
            _searchskillpage.ClickSearchSkills();
            _searchskillpage.ClickSkills();


            triggerSearch.EnterMessage($"I'm interested - Notification");
            triggerSearch.AddHours();
            triggerSearch.ClickRequest();
            triggerSearch.ClickYes();

            // Optional: small wait for server processing
            Thread.Sleep(1000);
         
            triggerSearch.ClickWithdraw();

            triggerDriver.Quit();
            Thread.Sleep(3000);
            driver.Navigate().GoToUrl(driver.Url);
            notificationPage = new NotificationPage(driver);
            notificationPage.OpenNotificationsServiceListing();
            notificationPage.ClickCheckbox();
            notificationPage.ClickSelectAll();
            Assert.That(notificationPage.AreAllCheckboxesSelected(), Is.True);
            notificationPage.ClickUnselectAll();
            Assert.That(notificationPage.AreAllCheckboxesSelected(), Is.False);



        }

        [TearDown]

        public void Teardown()
        {
            var screenshotPath = ScreenshotHelper.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name);
            test.AddScreenCaptureFromPath(screenshotPath);

            notificationPage.ClearAllNotifications();
            notificationPage.NavigateToManageListings();
            _manageListings.DeleteAllShareSkillListings(driver);

            driver = CommonDriver.QuitDriver();
        }
    }
}
