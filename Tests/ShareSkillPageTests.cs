using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Project_Mars_NUnit.Drivers;
using Project_Mars_NUnit.Models;
using Project_Mars_NUnit.Pages;
using Project_Mars_NUnit.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars_NUnit.Tests
{
    [TestFixture]
    public class ShareSkillPageTests : CommonDriver
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private ShareSkillPage _shareskillpage;
        private ExtentTest test;
        private HomePage homePageObj;
        private ManageListings _manageListings;

        [SetUp]
        public void Setup()
        {

            driver = CommonDriver.InitDriver();

            test = TestHooks.extent.CreateTest(TestContext.CurrentContext.Test.Name);

            LoginPage loginPageObj = new LoginPage(driver);
            loginPageObj.Login("test@test.com", "123123");


            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToManageListings(driver);
            
            _manageListings = new ManageListings(driver);
            _manageListings.DeleteAllShareSkillListings(driver);


            homePageObj.NavigateToShareSkillPage(driver);
            _shareskillpage = new ShareSkillPage(driver);
        }
        [Test]

        public void ShareSkillAddNew_Test()


        {
            
            var shareSkillData = JsonReader.LoadJson<ShareSkillData>(@"TestData\AddNewShareSkill.json");

            _shareskillpage.AddTitle(shareSkillData.Title);
            _shareskillpage.AddDescription(shareSkillData.Description);
            _shareskillpage.AddCategory(shareSkillData.Category);
            _shareskillpage.AddSubcategory(shareSkillData.Subcategory);
            _shareskillpage.AddTags(shareSkillData.Tags);
            _shareskillpage.SelectServiceType("0");
            _shareskillpage.SelectLocationType("1");
            _shareskillpage.SelectCredit("false");
            _shareskillpage.AddCredit(shareSkillData.Credit);
            _shareskillpage.AddWorkSamples(shareSkillData.WorkSamplePath);
            _shareskillpage.SelectActive("true");
            _shareskillpage.ClickSave();

            Thread.Sleep(3000);

            string actualMessage = _shareskillpage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(shareSkillData.ExpectedMessage));


        }

        [Test]
        public void ShareSkillEmptyTitleField_Test()


        {
            var shareSkillData = JsonReader.LoadJson<ShareSkillData>(@"TestData\ShareSkillEmptyField.json");

            _shareskillpage.AddDescription(shareSkillData.Description);
            _shareskillpage.AddCategory(shareSkillData.Category);
            _shareskillpage.AddSubcategory(shareSkillData.Subcategory);
            _shareskillpage.AddTags(shareSkillData.Tags);
            _shareskillpage.SelectServiceType("0");
            _shareskillpage.SelectLocationType("1");
            _shareskillpage.SelectCredit("false");
            _shareskillpage.AddCredit(shareSkillData.Credit);
            _shareskillpage.AddWorkSamples(shareSkillData.WorkSamplePath);
            _shareskillpage.SelectActive("true");
            _shareskillpage.ClickSave();

            Thread.Sleep(3000);

            string actualMessage = _shareskillpage.GetFailureMessage();

            Assert.That(actualMessage, Is.EqualTo(shareSkillData.ExpectedMessage));


        }

        
        [Test]
        public void ShareSkillEmptyDescriptionField_Test()


        {
            var shareSkillData = JsonReader.LoadJson<ShareSkillData>(@"TestData\ShareSkillEmptyField.json");

            _shareskillpage.AddTitle(shareSkillData.Title);
            _shareskillpage.AddCategory(shareSkillData.Category);
            _shareskillpage.AddSubcategory(shareSkillData.Subcategory);
            _shareskillpage.AddTags(shareSkillData.Tags);
            _shareskillpage.SelectServiceType("0");
            _shareskillpage.SelectLocationType("1");
            _shareskillpage.SelectCredit("false");
            _shareskillpage.AddCredit(shareSkillData.Credit);
            _shareskillpage.AddWorkSamples(shareSkillData.WorkSamplePath);
            _shareskillpage.SelectActive("true");
            _shareskillpage.ClickSave();

            Thread.Sleep(3000);

            string actualMessage = _shareskillpage.GetFailureMessage();

            Assert.That(actualMessage, Is.EqualTo(shareSkillData.ExpectedMessage));


        }

        [Test]
        public void ShareSkillEmptyTags_Test()


        {
            var shareSkillData = JsonReader.LoadJson<ShareSkillData>(@"TestData\ShareSkillEmptyField.json");

            _shareskillpage.AddTitle(shareSkillData.Title);
            _shareskillpage.AddDescription(shareSkillData.Description);
            _shareskillpage.AddCategory(shareSkillData.Category);
            _shareskillpage.AddSubcategory(shareSkillData.Subcategory);
            _shareskillpage.SelectServiceType("0");
            _shareskillpage.SelectLocationType("1");
            _shareskillpage.SelectCredit("false");
            _shareskillpage.AddCredit(shareSkillData.Credit);
            _shareskillpage.AddWorkSamples(shareSkillData.WorkSamplePath);
            _shareskillpage.SelectActive("true");
            _shareskillpage.ClickSave();

            Thread.Sleep(3000);

            string actualMessage = _shareskillpage.GetFailureMessage();

            Assert.That(actualMessage, Is.EqualTo(shareSkillData.ExpectedMessage));


        }

        [Test]
        public void ShareSkillEmptyCategoryField_Test()


        {
            var shareSkillData = JsonReader.LoadJson<ShareSkillData>(@"TestData\ShareSkillEmptyField.json");

            _shareskillpage.AddTitle(shareSkillData.Title);
            _shareskillpage.AddDescription(shareSkillData.Description);
            _shareskillpage.AddTags(shareSkillData.Tags);
            _shareskillpage.SelectServiceType("0");
            _shareskillpage.SelectLocationType("1");
            _shareskillpage.SelectCredit("false");
            _shareskillpage.AddCredit(shareSkillData.Credit);
            _shareskillpage.AddWorkSamples(shareSkillData.WorkSamplePath);
            _shareskillpage.SelectActive("true");
            _shareskillpage.ClickSave();

            Thread.Sleep(3000);

            string actualMessage = _shareskillpage.GetFailureMessage();

            Assert.That(actualMessage, Is.EqualTo(shareSkillData.ExpectedMessage));


        }

        [Test]

        public void ShareSkillEmptySkillExchangeField_Test()


        {

            var shareSkillData = JsonReader.LoadJson<ShareSkillData>(@"TestData\ShareSkillEmptyField.json");

            _shareskillpage.AddTitle(shareSkillData.Title);
            _shareskillpage.AddDescription(shareSkillData.Description);
            _shareskillpage.AddCategory(shareSkillData.Category);
            _shareskillpage.AddSubcategory(shareSkillData.Subcategory);
            _shareskillpage.AddTags(shareSkillData.Tags);
            _shareskillpage.SelectServiceType("0");
            _shareskillpage.SelectLocationType("1");
            _shareskillpage.SelectSkillExchange("false");
            _shareskillpage.AddWorkSamples(shareSkillData.WorkSamplePath);
            _shareskillpage.SelectActive("true");
            _shareskillpage.ClickSave();

            Thread.Sleep(3000);

            string actualMessage = _shareskillpage.GetFailureMessage();

            Assert.That(actualMessage, Is.EqualTo(shareSkillData.ExpectedMessage));


        }

        [Test]

        public void ShareSkillTitleCharacters_Test()

        {
            string longTitle = new string('A', 150); // 150 characters

            _shareskillpage.AddTitle(longTitle);

            var actualTitle = _shareskillpage.GetTitle();

            Assert.That(actualTitle.Length, Is.EqualTo(100),
                "Title field should accept only 100 characters");



        }


        [Test]

        public void ShareSkillDescriptionCharacters_Test()

        {
            string longDescription = new string('A', 650); // 650 characters

            _shareskillpage.AddDescription(longDescription);

            var actualDescription = _shareskillpage.GetDescription();

            Assert.That(actualDescription.Length, Is.EqualTo(600),
                "Description field should accept only 100 characters"); }

        [Test]

        public void ShareSkillDuplicateTags_Test()
        {   
            string duplicateTag = "QA";

            _shareskillpage.AddTags (new List<string> {duplicateTag});
            _shareskillpage.AddTags(new List<string> {duplicateTag}); // Try adding duplicate

            var tags = _shareskillpage.GetTagsClean();
            Assert.That(tags, Does.Contain(duplicateTag), "Duplicate tag should not be added");

        }

        [Test]
        public void ShareSkillDuplicateSkillExchange_Test()
        {
            string duplicateSkill = "Software testing";

            _shareskillpage.AddSkillExchange(new List<string> { duplicateSkill });
            _shareskillpage.AddSkillExchange(new List<string> { duplicateSkill }); // Try adding duplicate

            var tags = _shareskillpage.GetSkillsClean();
            Assert.That(tags, Does.Contain(duplicateSkill), "Duplicate skill should not be added");

        }

        [Test]
        public void ShareSkillCredit_Test()
        {
            string credit = "13"; // two digits entered

            _shareskillpage.SelectCredit("false");
            _shareskillpage.AddCredit(credit);


            int actualCredit = _shareskillpage.GetCredit();

Assert.That(actualCredit, Is.LessThan(10),
    "Credit field should accept only one digit");


        }

        [Test]
        public void ShareSkillWorkSamplesUnsupported_Test()

        {
            var shareSkillData = JsonReader.LoadJson<ShareSkillData>(@"TestData\ShareSkillWorkSamplesUnsupported.json");
            _shareskillpage.AddWorkSamples(shareSkillData.WorkSamplePath);
            string actualMessage = _shareskillpage.GetFailureMessage();

            Assert.That(actualMessage, Is.EqualTo(shareSkillData.ExpectedMessage));
        }

        [Test]
        public void ShareSkillCancel_Test()

        {
            var shareSkillData = JsonReader.LoadJson<ShareSkillData>(@"TestData\AddNewShareSkill.json");

            _shareskillpage.AddTitle(shareSkillData.Title);
            _shareskillpage.AddDescription(shareSkillData.Description);
            _shareskillpage.AddCategory(shareSkillData.Category);
            _shareskillpage.AddSubcategory(shareSkillData.Subcategory);
            _shareskillpage.AddTags(shareSkillData.Tags);
            _shareskillpage.SelectServiceType("0");
            _shareskillpage.SelectLocationType("1");
            _shareskillpage.SelectCredit("false");
            _shareskillpage.AddCredit(shareSkillData.Credit);
            _shareskillpage.AddWorkSamples(shareSkillData.WorkSamplePath);
            _shareskillpage.SelectActive("true");
            _shareskillpage.ClickCancel();

            Assert.That(_shareskillpage.AreThereAnyShareSkillListings(),
    Is.False,
    "Expected no ShareSkill listings, but some were found");


        }


        [TearDown]
            public void Teardown()
            {
                var screenshotPath = ScreenshotHelper.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name);
                test.AddScreenCaptureFromPath(screenshotPath);

                _shareskillpage.NavigateToManageListings(driver);
                _manageListings.DeleteAllShareSkillListings(driver);

                driver = CommonDriver.QuitDriver();
            }

        }
}
