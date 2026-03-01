using AventStack.ExtentReports;
using NUnit.Framework;
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
    public class SearchSkillsTests : CommonDriver
    {
        private ExtentTest test;
        private ShareSkillPage _shareskillpage;
        private HomePage homePageObj;
        private ManageListings _manageListings;
        private SearchSkillPage _searchskillpage;

        [SetUp]

        public void Setup()

        {
            driver = CommonDriver.InitDriver();

            test = TestHooks.extent.CreateTest(TestContext.CurrentContext.Test.Name);

            LoginPage loginPageObj = new LoginPage(driver);
            loginPageObj.Login("test@test.com", "123123");

            homePageObj = new HomePage();
            homePageObj.NavigateToManageListings(driver);

            _manageListings = new ManageListings(driver);
            _manageListings.DeleteAllShareSkillListings(driver);

            homePageObj.NavigateToShareSkillPage(driver);
            _shareskillpage = new ShareSkillPage(driver);



        }

        [Test]
        public void SearchSkills_AllCategories()
        {
            var shareSkillList = JsonReader.LoadJson<List<ShareSkillData>>(@"TestData\MultipleShareSkills.json");

            foreach (var shareSkillData in shareSkillList)

            {
               
                _shareskillpage.AddTitle(shareSkillData.Title);
                _shareskillpage.AddDescription(shareSkillData.Description);
                _shareskillpage.AddCategory(shareSkillData.Category);
                _shareskillpage.AddSubcategory(shareSkillData.Subcategory);
                _shareskillpage.AddTags(shareSkillData.Tags);
                _shareskillpage.SelectServiceType("0");
                _shareskillpage.SelectLocationType("1");
                _shareskillpage.SelectCredit("false");
                _shareskillpage.AddCredit(shareSkillData.Credit);
                _shareskillpage.SelectActive("true");
                _shareskillpage.ClickSave();
                Thread.Sleep(3000);

                homePageObj.NavigateToShareSkillPage(driver);
            }


            _searchskillpage = new SearchSkillPage(driver);
            _searchskillpage.ClickSearchSkills();
            _searchskillpage.ClickAllCategories();

            // Get all displayed skill titles after clicking "All Categories"
            var displayedTitles = _searchskillpage.GetDisplayedSkillTitles();

            for (int i = 0; i < shareSkillList.Count; i++)
            {
                // Compare expected vs actual using Assert.That
                Assert.That(displayedTitles[i], Is.EqualTo(shareSkillList[i].Title), $"Title mismatch at index {i}");
            }





        }

        [Test]
        public void SearchSkills_ByCategory()
        {
            var shareSkillData = JsonReader.LoadJson<ShareSkillData>(@"TestData\AddNewShareSkill.json");

            {

                _shareskillpage.AddTitle(shareSkillData.Title);
                _shareskillpage.AddDescription(shareSkillData.Description);
                _shareskillpage.AddCategory(shareSkillData.Category);
                _shareskillpage.AddSubcategory(shareSkillData.Subcategory);
                _shareskillpage.AddTags(shareSkillData.Tags);
                _shareskillpage.SelectServiceType("0");
                _shareskillpage.SelectLocationType("1");
                _shareskillpage.SelectCredit("false");
                _shareskillpage.AddCredit(shareSkillData.Credit);
                _shareskillpage.SelectActive("true");
                _shareskillpage.ClickSave();
                Thread.Sleep(3000);

                homePageObj.NavigateToShareSkillPage(driver);
            }


            _searchskillpage = new SearchSkillPage(driver);
            _searchskillpage.ClickSearchSkills();
            _searchskillpage.ClickTestAutomation();

            // Get all displayed skill titles after clicking "All Categories"
            var displayedTitles = _searchskillpage.GetDisplayedSkillTitles();

            Assert.That(displayedTitles[0], Is.EqualTo(shareSkillData.Title), "Title mismatch");

        }

        [Test]
        public void SearchSkills_BySubcategory()
        {
            var shareSkillData = JsonReader.LoadJson<ShareSkillData>(@"TestData\AddNewShareSkill.json");

            {

                _shareskillpage.AddTitle(shareSkillData.Title);
                _shareskillpage.AddDescription(shareSkillData.Description);
                _shareskillpage.AddCategory(shareSkillData.Category);
                _shareskillpage.AddSubcategory(shareSkillData.Subcategory);
                _shareskillpage.AddTags(shareSkillData.Tags);
                _shareskillpage.SelectServiceType("0");
                _shareskillpage.SelectLocationType("1");
                _shareskillpage.SelectCredit("false");
                _shareskillpage.AddCredit(shareSkillData.Credit);
                _shareskillpage.SelectActive("true");
                _shareskillpage.ClickSave();
                Thread.Sleep(3000);

                homePageObj.NavigateToShareSkillPage(driver);
            }


            _searchskillpage = new SearchSkillPage(driver);
            _searchskillpage.ClickSearchSkills();
            _searchskillpage.ClickTestAutomation();
            _searchskillpage.ClickSelenium();

            // Get all displayed skill titles after clicking "All Categories"
            var displayedTitles = _searchskillpage.GetDisplayedSkillTitles();

            Assert.That(displayedTitles[0], Is.EqualTo(shareSkillData.Title), "Title mismatch");

        }

        [Test]
        public void SearchSkills_ByFilterOnline()
        {
            
            var shareSkillData = JsonReader.LoadJson<ShareSkillData>(@"TestData\AddNewShareSkill.json");

            {
                _shareskillpage.AddTitle(shareSkillData.Title);
                _shareskillpage.AddDescription(shareSkillData.Description);
                _shareskillpage.AddCategory(shareSkillData.Category);
                _shareskillpage.AddSubcategory(shareSkillData.Subcategory);
                _shareskillpage.AddTags(shareSkillData.Tags);
                _shareskillpage.SelectServiceType("0");
                _shareskillpage.SelectLocationType("1");
                _shareskillpage.SelectCredit("false");
                _shareskillpage.AddCredit(shareSkillData.Credit);
                _shareskillpage.SelectActive("true");
                _shareskillpage.ClickSave();
                Thread.Sleep(3000);

                homePageObj.NavigateToShareSkillPage(driver);
            }


            _searchskillpage = new SearchSkillPage(driver);
            _searchskillpage.ClickSearchSkills();
            _searchskillpage.ClickOnline();
            Thread.Sleep(3000);

            // Get all actual skill cards after test actions
            var skillCards = driver.FindElements(By.CssSelector(".content"))
                                   .Where(card => card.FindElements(By.CssSelector(".service-info")).Any())
                                   .ToList();

            // Assert there is exactly 1 skill card (your newly added skill)
            Assert.That(skillCards.Count, Is.EqualTo(1), "Unexpected number of skills displayed");

            // Assert the skill title exists
            var displayedTitles = skillCards.Select(card => card.FindElement(By.CssSelector(".service-info p")).Text).ToList();
            Assert.That(displayedTitles.Contains(shareSkillData.Title), Is.True, $"Expected skill '{shareSkillData.Title}' not found");
        }

        [Test]
        public void SearchSkills_ByFilterOnsite()
        {

            var shareSkillData = JsonReader.LoadJson<ShareSkillData>(@"TestData\AddNewShareSkill.json");

            {
                _shareskillpage.AddTitle(shareSkillData.Title);
                _shareskillpage.AddDescription(shareSkillData.Description);
                _shareskillpage.AddCategory(shareSkillData.Category);
                _shareskillpage.AddSubcategory(shareSkillData.Subcategory);
                _shareskillpage.AddTags(shareSkillData.Tags);
                _shareskillpage.SelectServiceType("0");
                _shareskillpage.SelectLocationType("0");
                _shareskillpage.SelectCredit("false");
                _shareskillpage.AddCredit(shareSkillData.Credit);
                _shareskillpage.SelectActive("true");
                _shareskillpage.ClickSave();
                Thread.Sleep(3000);

                homePageObj.NavigateToShareSkillPage(driver);
            }


            _searchskillpage = new SearchSkillPage(driver);
            _searchskillpage.ClickSearchSkills();
            _searchskillpage.ClickOnsite();
            Thread.Sleep(3000);

            // Get all actual skill cards after test actions
            var skillCards = driver.FindElements(By.CssSelector(".content"))
                                   .Where(card => card.FindElements(By.CssSelector(".service-info")).Any())
                                   .ToList();

            // Assert there is exactly 1 skill card (your newly added skill)
            Assert.That(skillCards.Count, Is.EqualTo(1), "Unexpected number of skills displayed");

            // Assert the skill title exists
            var displayedTitles = skillCards.Select(card => card.FindElement(By.CssSelector(".service-info p")).Text).ToList();
            Assert.That(displayedTitles.Contains(shareSkillData.Title), Is.True, $"Expected skill '{shareSkillData.Title}' not found");
        }
        [Test]
        public void SearchSkills_ByFilterShowAll()
        {
            var shareSkillList = JsonReader.LoadJson<List<ShareSkillData>>(@"TestData\MultipleShareSkills.json");

            for (int i = 0; i < shareSkillList.Count; i++)
            {
                var shareSkillData = shareSkillList[i];

                _shareskillpage.AddTitle(shareSkillData.Title);
                _shareskillpage.AddDescription(shareSkillData.Description);
                _shareskillpage.AddCategory(shareSkillData.Category);
                _shareskillpage.AddSubcategory(shareSkillData.Subcategory);
                _shareskillpage.AddTags(shareSkillData.Tags);
                _shareskillpage.SelectServiceType("0");
                // Set location type: 1 for first, 0 for second and others
                string locationType = (i == 0) ? "1" : "0";
                _shareskillpage.SelectLocationType(locationType);
                _shareskillpage.SelectCredit("false");
                _shareskillpage.AddCredit(shareSkillData.Credit);
                _shareskillpage.SelectActive("true");
                _shareskillpage.ClickSave();
                Thread.Sleep(3000);

                homePageObj.NavigateToShareSkillPage(driver);
            }



            _searchskillpage = new SearchSkillPage(driver);
            _searchskillpage.ClickSearchSkills();
            _searchskillpage.ClickOnsite();
            Thread.Sleep(3000);

            // Get all actual skill cards after test actions
            var skillCards = driver.FindElements(By.CssSelector(".content"))
                                   .Where(card => card.FindElements(By.CssSelector(".service-info")).Any())
                                   .ToList();

            // Assert there is exactly 1 skill card (your newly added skill)
            Assert.That(skillCards.Count, Is.EqualTo(1), "Unexpected number of skills displayed");

            
        }

        [TearDown]

        public void Teardown()
        {
            var screenshotPath = ScreenshotHelper.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name);
            test.AddScreenCaptureFromPath(screenshotPath);


            _searchskillpage.NavigateToManageListings(driver);
            _manageListings.DeleteAllShareSkillListings(driver);

            driver = CommonDriver.QuitDriver();
        }
    }
}
