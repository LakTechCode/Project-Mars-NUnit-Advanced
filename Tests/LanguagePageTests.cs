using AventStack.ExtentReports;
using Project_Mars_NUnit.Drivers;
using Project_Mars_NUnit.Pages;
using Project_Mars_NUnit.Models;
using Project_Mars_NUnit.Utilities;
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
        [Test]
        public void AddLanguage_Test()

        {
            var languageData = JsonReader.LoadJson<LanguageData>(@"TestData\AddLanguage.json");
            _languagePage.ClickAddNew();
            _languagePage.AddLanguage(languageData.Language);
            _languagePage.ProficiencyAddLevel(languageData.LanguageLevel);
            _languagePage.ClickAdd();
            Thread.Sleep(3000);

            string actualMessage = _languagePage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(languageData.ExpectedMessage));

        }
        [Test]
        public void CancelLanguage_Test()

        {
            var languageData = JsonReader.LoadJson<LanguageData>(@"TestData\AddLanguage.json");
            _languagePage.ClickAddNew();
            _languagePage.AddLanguage(languageData.Language);
            _languagePage.ProficiencyAddLevel(languageData.LanguageLevel);
            _languagePage.ClickCancel();
            Assert.That(_languagePage.IsLanguageInList(languageData.Language), Is.False, $"'{languageData.Language}' should not be added after cancel.");


        }

        [Test]

        public void DuplicateLanguage_Test()

        {
            var languageData = JsonReader.LoadJson<LanguageData>(@"TestData\DuplicateLanguage.json");
            _languagePage.ClickAddNew();
            _languagePage.AddLanguage(languageData.Language);
            _languagePage.ProficiencyAddLevel(languageData.LanguageLevel);
            _languagePage.ClickAdd();
            _languagePage.ClickAddNew();
            _languagePage.AddLanguage(languageData.Language);
            _languagePage.ProficiencyAddLevel(languageData.LanguageLevel);
            _languagePage.ClickAdd();
            Thread.Sleep(3000);

            string actualMessage = _languagePage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(languageData.ExpectedMessage));


        }

        [Test]
        public void EmptyLanguageField_Test()

        {
            var languageData = JsonReader.LoadJson<LanguageData>(@"TestData\EmptyLanguageField.json");
            _languagePage.ClickAddNew();
            _languagePage.ProficiencyAddLevel(languageData.LanguageLevel);
            _languagePage.ClickAdd();

            string actualMessage = _languagePage.GetSuccessMessage();
            Assert.That(actualMessage, Is.EqualTo(languageData.ExpectedMessage));


        }

        [Test]
        public void EditLanguageLevel_Test()
        {
            var languageData = JsonReader.LoadJson<LanguageData>(@"TestData\EditLanguageLevel.json");
            _languagePage.ClickAddNew();
            _languagePage.AddLanguage(languageData.Language);
            _languagePage.ProficiencyAddLevel(languageData.LanguageLevel);
            _languagePage.ClickAdd();
            _languagePage.ClickEdit();
            _languagePage.ProficiencyUpdateLevel(languageData.EditLanguageLevel);
            _languagePage.ClickUpdate();
            Thread.Sleep(3000);

            string actualMessage = _languagePage.GetSuccessMessage();
            Assert.That(actualMessage, Is.EqualTo(languageData.ExpectedMessage));


        }

        [Test]
        public void EditLanguage_Test()
        {
            var languageData = JsonReader.LoadJson<LanguageData>(@"TestData\EditLanguage.json");
            _languagePage.ClickAddNew();
            _languagePage.AddLanguage(languageData.Language);
            _languagePage.ProficiencyAddLevel(languageData.LanguageLevel);
            _languagePage.ClickAdd();
            _languagePage.ClickEdit();
            _languagePage.UpdateLanguage(languageData.EditLanguage);
            _languagePage.ClickUpdate();
            Thread.Sleep(3000);

            string actualMessage = _languagePage.GetSuccessMessage();
            Assert.That(actualMessage, Is.EqualTo(languageData.ExpectedMessage));


        }

        [Test]
        public void CancelEditedLanguage_Test()
        {
            var languageData = JsonReader.LoadJson<LanguageData>(@"TestData\EditLanguage.json");
            _languagePage.ClickAddNew();
            _languagePage.AddLanguage(languageData.Language);
            _languagePage.ProficiencyAddLevel(languageData.LanguageLevel);
            _languagePage.ClickAdd();
            _languagePage.ClickEdit();
            _languagePage.UpdateLanguage(languageData.EditLanguage);
            _languagePage.ClickCancelinEditPage();
            
                var actualLanguage = _languagePage.GetLanguage();
                var actualLevel = _languagePage.GetLevel();

                Assert.That(actualLanguage, Is.EqualTo(languageData.Language));
            Assert.That(actualLevel, Is.EqualTo(languageData.LanguageLevel));

        }

        [Test]
        public void DeleteLanguage_Test()

        {
            var languageData = JsonReader.LoadJson<LanguageData>(@"TestData\AddLanguage.json");
            _languagePage.ClickAddNew();
            _languagePage.AddLanguage(languageData.Language);
            _languagePage.ProficiencyAddLevel(languageData.LanguageLevel);
            _languagePage.ClickAdd();
            _languagePage.ClickDelete();

            Assert.That(_languagePage.IsLanguageInList(languageData.Language), Is.False, $"'{languageData.Language}' should not exist in the list after deletion.");


        }

        [Test]
        public void NumberofLanguages_Test()

        {
            var languageList = JsonReader.LoadJson<List<LanguageData>>("TestData\\NumberOfLanguages.json");

            foreach (var data in languageList)
            {
                _languagePage.ClickAddNew();
                _languagePage.AddLanguage(data.Language);
                _languagePage.ProficiencyAddLevel(data.LanguageLevel);
                _languagePage.ClickAdd();
            }
            Thread.Sleep(3000);

            {
                Assert.That(_languagePage.IsAddNewButtonVisible(), Is.False, "'Add New' button should not be visible.");
            }
        }

        [TearDown]
        public void Teardown()
        {
            var screenshotPath = ScreenshotHelper.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name);
            test.AddScreenCaptureFromPath(screenshotPath);

            _languagePage.DeleteAllLanguages();

            driver = CommonDriver.QuitDriver();
        }
    }
}
