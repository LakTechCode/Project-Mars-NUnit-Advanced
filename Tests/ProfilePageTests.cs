using AventStack.ExtentReports;
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
    public class ProfilePageTests : CommonDriver
    {
        private ProfilePage _profilePage;
        private ExtentTest test;

        [SetUp]
        public void Setup()
        {

            driver = CommonDriver.InitDriver();

            test = TestHooks.extent.CreateTest(TestContext.CurrentContext.Test.Name);

            LoginPage loginPageObj = new LoginPage(driver);
            loginPageObj.Login("test@test.com", "123123");

            _profilePage = new ProfilePage(driver);
        }


        [Test]

       

        public void UpdateAvailability_Test()
        {
            _profilePage.ClickEditAvailability();

            var profileData = JsonReader.LoadJson<ProfileData>(@"TestData\Profile.json");

            string currentAvailability = _profilePage.GetCurrentAvailability();

            if (currentAvailability.Equals(profileData.Availability) == false)
            {
                _profilePage.SelectAvailability(profileData.Availability);
                string actualMessage = _profilePage.GetSuccessMessage();
                Assert.That(actualMessage, Is.EqualTo(profileData.ExpectedMessage));
            }
            else
            {
                Assert.Pass("Availability already set. No update required.");
            }
        }


        [Test]
        public void UpdateHours_Test()
        {
            _profilePage.ClickEditHours();

            var profileData = JsonReader.LoadJson<ProfileData>(@"TestData\Profile.json");
            string currentHours = _profilePage.GetCurrentHours();

            if (currentHours.Equals(profileData.Hours) == false)
            {
                _profilePage.SelectHours(profileData.Hours);
                string actualMessage = _profilePage.GetSuccessMessage();
                Assert.That(actualMessage, Is.EqualTo(profileData.ExpectedMessage));
            }
            else
            {
                Assert.Pass("Availability already set. No update required.");
            }



        }

        [Test]
        public void UpdateEarnTarget_Test()
        {
            _profilePage.ClickEditEarnTarget();

            var profileData = JsonReader.LoadJson<ProfileData>(@"TestData\Profile.json");
            string currentEarnTarget = _profilePage.GetCurrentEarnTarget();

            if (currentEarnTarget.Equals(profileData.EarnTarget) == false)
            {
                _profilePage.SelectEarnTarget(profileData.EarnTarget);
                string actualMessage = _profilePage.GetSuccessMessage();
                Assert.That(actualMessage, Is.EqualTo(profileData.ExpectedMessage));
            }
            else
            {
                Assert.Pass("Availability already set. No update required.");
            }



        }

        [TearDown]
        public void Teardown()
        {
            var screenshotPath = ScreenshotHelper.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name);
            test.AddScreenCaptureFromPath(screenshotPath);


            driver = CommonDriver.QuitDriver();
        }

    }
}
