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
    public class SkillPageTests : CommonDriver
    {
        private SkillsPage _skillsPage;
        private ExtentTest test;

        [SetUp]
        public void Setup()
        {

            driver = CommonDriver.InitDriver();

            test = TestHooks.extent.CreateTest(TestContext.CurrentContext.Test.Name);

            LoginPage loginPageObj = new LoginPage(driver);
            loginPageObj.Login("test@test.com", "123123");

            //Homepage objection initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToSkillsPage(driver);

            _skillsPage = new SkillsPage(driver);
            _skillsPage.DeleteAllSkills();

        }


        [Test]

        public void AddSkill_Test()

        {
            var skillsData = JsonReader.LoadJson<SkillData>(@"TestData\AddSkill.json");
            _skillsPage.ClickAddNewonSkills();
            _skillsPage.AddSkill(skillsData.Skill);
            _skillsPage.AddSkillLevel(skillsData.SkillLevel);
            _skillsPage.ClickAddonSkills();
            Thread.Sleep(3000);

            string actualMessage = _skillsPage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(skillsData.ExpectedMessage));

        }

        [Test]
        public void CancelSkill_Test()

        {
            var skillsData = JsonReader.LoadJson<SkillData>(@"TestData\AddSkill.json");
            _skillsPage.ClickAddNewonSkills();
            _skillsPage.AddSkill(skillsData.Skill);
            _skillsPage.AddSkillLevel(skillsData.SkillLevel);
            _skillsPage.ClickCancelonSkills();
            Assert.That(_skillsPage.IsSkillInList(skillsData.Skill), Is.False, $"'{skillsData.Skill}' should not be added after cancel.");

        }
        [Test]

        public void DuplicateSkill_Test()

        {
            var skillsData = JsonReader.LoadJson<SkillData>(@"TestData\DuplicateSkill.json");
            _skillsPage.ClickAddNewonSkills();
            _skillsPage.AddSkill(skillsData.Skill);
            _skillsPage.AddSkillLevel(skillsData.SkillLevel);
            _skillsPage.ClickAddonSkills();
            _skillsPage.ClickAddNewonSkills();
            _skillsPage.AddSkill(skillsData.Skill);
            _skillsPage.AddSkillLevel(skillsData.SkillLevel);
            _skillsPage.ClickAddonSkills();
            Thread.Sleep(3000);

            string actualMessage = _skillsPage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(skillsData.ExpectedMessage));


        }


        [Test]
        public void EmptySkillField_Test()

        {
            var skillsData = JsonReader.LoadJson<SkillData>(@"TestData\EmptySkillField.json");
            _skillsPage.ClickAddNewonSkills();
            _skillsPage.AddSkillLevel(skillsData.SkillLevel);
            _skillsPage.ClickAddonSkills();

            string actualMessage = _skillsPage.GetSuccessMessage();
            Assert.That(actualMessage, Is.EqualTo(skillsData.ExpectedMessage));

        }

        [Test]
        public void EditSkills_Test()
        {
            var skillsData = JsonReader.LoadJson<SkillData>(@"TestData\EditSkill.json");
            _skillsPage.ClickAddNewonSkills();
            _skillsPage.AddSkill(skillsData.Skill);
            _skillsPage.AddSkillLevel(skillsData.SkillLevel);
            _skillsPage.ClickAddonSkills();
            _skillsPage.ClickEditonSkills();
            _skillsPage.UpdateSkill(skillsData.EditSkill);
            _skillsPage.ClickUpdateonSkills();
            Thread.Sleep(3000);

            string actualMessage = _skillsPage.GetSuccessMessage();
            Assert.That(actualMessage, Is.EqualTo(skillsData.ExpectedMessage));


        }

        [Test]
        public void EditSkillLevel_Test()
        {
            var skillsData = JsonReader.LoadJson<SkillData>(@"TestData\EditSkillLevel.json");
            _skillsPage.ClickAddNewonSkills();
            _skillsPage.AddSkill(skillsData.Skill);
            _skillsPage.AddSkillLevel(skillsData.SkillLevel);
            _skillsPage.ClickAddonSkills();
            _skillsPage.ClickEditonSkills();
            _skillsPage.UpdateSkillLevel(skillsData.EditSkillLevel);
            _skillsPage.ClickUpdateonSkills();
            Thread.Sleep(3000);

            string actualMessage = _skillsPage.GetSuccessMessage();
            Assert.That(actualMessage, Is.EqualTo(skillsData.ExpectedMessage));


        }

        [Test]
        public void CancelEditedSkill_Test()
        {
            var skillsData = JsonReader.LoadJson<SkillData>(@"TestData\EditSkill.json");
            _skillsPage.ClickAddNewonSkills();
            _skillsPage.AddSkill(skillsData.Skill);
            _skillsPage.AddSkillLevel(skillsData.SkillLevel);
            _skillsPage.ClickAddonSkills();
            _skillsPage.ClickEditonSkills();
            _skillsPage.UpdateSkill(skillsData.EditSkill);
            _skillsPage.ClickCancelinEditPageforSkills();

            var actualLanguage = _skillsPage.GetSkill();
            var actualLevel = _skillsPage.GetLevel();

            Assert.That(actualLanguage, Is.EqualTo(skillsData.Skill));
            Assert.That(actualLevel, Is.EqualTo(skillsData.SkillLevel));

        }
        [Test]
        public void DeleteSkill_Test()

        {
            var skillsData = JsonReader.LoadJson<SkillData>(@"TestData\AddSkill.json");
            _skillsPage.ClickAddNewonSkills();
            _skillsPage.AddSkill(skillsData.Skill);
            _skillsPage.AddSkillLevel(skillsData.SkillLevel);
            _skillsPage.ClickAddonSkills();
            _skillsPage.ClickDeleteonSkills();

            Assert.That(_skillsPage.IsSkillInList(skillsData.Skill), Is.False, $"'{skillsData.Skill}' should not exist in the list after deletion.");


        }

        [TearDown]
        public void Teardown()
        {
            var screenshotPath = ScreenshotHelper.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name);
            test.AddScreenCaptureFromPath(screenshotPath);

            _skillsPage.DeleteAllSkills();

            driver = CommonDriver.QuitDriver();
        }


    }
}
