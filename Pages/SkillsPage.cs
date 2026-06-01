using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars_NUnit.Pages
{
    public class SkillsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public IWebDriver Driver => _driver;

        //locators
        private readonly By SkillsButton = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]");
        private readonly By AddNewonSkillsButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div");
        private readonly By AddSkillField = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input");
        private readonly By AddSkillDropdown = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select");
        private readonly By AddonSkillsButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]");
        private readonly By CancelSkillsButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[2]");
        private readonly By EditSkillsButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i");
        private readonly By UpdateSkillField = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input");
        private readonly By UpdateSkillsButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]");
        private readonly By UpdateSkillDropdown = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select");
        private readonly By CancelEditSkillsButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]");
        private readonly By DeleteSkillsButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i");
        public SkillsPage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }
        public void ClickSkills()
        {
            var skillsButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(SkillsButton));
            skillsButtonElement.Click();
        }

        public void ClickAddNewonSkills()
        {
            var addNewonSkillsButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(AddNewonSkillsButton));
            addNewonSkillsButtonElement.Click();
        }

        public void AddSkill(string skill)

        {
            var addSkillElement = _wait.Until(ExpectedConditions.ElementToBeClickable(AddSkillField));
            addSkillElement.SendKeys(skill);

        }

        public void AddSkillLevel(string level)

        {
            var dropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(AddSkillDropdown));
            var select = new SelectElement(dropdown);
            select.SelectByText(level);

        }

        public void ClickAddonSkills()

        {
            var addonSkillsButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(AddonSkillsButton));
            addonSkillsButtonElement.Click();
        }

        public void ClickCancelonSkills()
        {
            var cancelSkillsButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(CancelSkillsButton));
            cancelSkillsButtonElement.Click();
        }

        public bool IsSkillInList(string skill)
        {
            return Driver.FindElements(By.XPath($"//div[text()='{skill}']")).Any();

        }
        public void ClickEditonSkills()
        {
            var editSkillsButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(EditSkillsButton));
            editSkillsButtonElement.Click();
        }

        public void UpdateSkill(string skill)

        {
            var updateSkillElement = _wait.Until(ExpectedConditions.ElementToBeClickable(UpdateSkillField));
            updateSkillElement.Clear();
            updateSkillElement.SendKeys(skill);

        }

        public void ClickUpdateonSkills()
        {
            var updateSkillsButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(UpdateSkillsButton));
            updateSkillsButtonElement.Click();
        }

        public void UpdateSkillLevel(string level)

        {
            var dropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(UpdateSkillDropdown));
            var select = new SelectElement(dropdown);
            select.SelectByText(level);

        }

        public void ClickCancelinEditPageforSkills()
        {
            var cancelEditSkillsButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(CancelEditSkillsButton));
            cancelEditSkillsButtonElement.Click();
        }

        public string GetSkill()
        {
            return _driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
        }

        public string GetLevel()
        {
            return _driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]")).Text;
        }

        public void ClickDeleteonSkills()
        {
            var deleteSkillsButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteSkillsButton));
            deleteSkillsButtonElement.Click();
        }

        public void DeleteAllSkills()
        {
            // Repeatedly find delete icons and click them until none are left
            while (true)
            {
                var deleteSkillsButtonElement = _driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                if (deleteSkillsButtonElement.Count == 0)
                    break;


                deleteSkillsButtonElement[0].Click();



                Thread.Sleep(15000);

                Console.Write("All skills deleted");
            }

        }

        public string GetSuccessMessage()
        {
            return _driver.FindElement(By.XPath("/html/body/div[1]/div")).Text;
        }
    }
}
