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
    public class LanguagePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public IWebDriver Driver => _driver;

        //Locators
        private readonly By AddNewButton = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div");
        private readonly By AddLanguageField = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input");
        private readonly By ProficiencyAddDropdown = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select");
        private readonly By AddButton = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]");
        private readonly By CancelButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[2]");
        private readonly By EditButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i");
        private readonly By UpdateButton = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]");
        private readonly By ProficiencyUpdateDropdown = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select");
        private readonly By UpdateLanguageField = By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input");
        private readonly By CancelButtonEditPage = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]");
        private readonly By DeleteButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i");
        public LanguagePage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }

        public void ClickAddNew()
        {
            var addNewButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(AddNewButton));
            addNewButtonElement.Click();
        }

        public void AddLanguage(string language)

        {
            var addLanguageElement = _wait.Until(ExpectedConditions.ElementToBeClickable(AddLanguageField));
            addLanguageElement.SendKeys(language);

        }

        public void ProficiencyAddLevel(string level)

        {
            var dropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(ProficiencyAddDropdown));
            var select = new SelectElement(dropdown);
            select.SelectByText(level);

        }

        public void ClickAdd()

        {
            var addButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(AddButton));
            addButtonElement.Click();
        }

        public void ClickCancel()

        {
            var cancelButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(CancelButton));
            cancelButtonElement.Click();
        }

        public bool IsLanguageInList(string language)
        {
            return Driver.FindElements(By.XPath($"//div[text()='{language}']")).Any();

        }
        public bool IsAddNewButtonVisible()
        {
            try
            {
                // Check if the element exists and is displayed
                return Driver.FindElements(AddNewButton).Any(e => e.Displayed);
            }
            catch (NoSuchElementException)
            {
                // If element is not in the DOM at all
                return false;
            }
        }

        public void ClickEdit()

        {
            var editButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(EditButton));
            editButtonElement.Click();
        }

        public void ClickUpdate()

        {
            var updateButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(UpdateButton));
            updateButtonElement.Click();
        }

        public void ProficiencyUpdateLevel(string level)

        {
            var dropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(ProficiencyUpdateDropdown));
            var select = new SelectElement(dropdown);
            select.SelectByText(level);

        }

        public void UpdateLanguage(string language)

        {
            var updateLanguageElement = _wait.Until(ExpectedConditions.ElementToBeClickable(UpdateLanguageField));
            updateLanguageElement.Clear();
            updateLanguageElement.SendKeys(language);

        }

        public string GetLanguage()
        {
            return _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
        }

        public string GetLevel()
        {
            return _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]")).Text;
        }

        public void ClickCancelinEditPage()

        {
            var cancelButtonEditPageElement = _wait.Until(ExpectedConditions.ElementToBeClickable(CancelButtonEditPage));
            cancelButtonEditPageElement.Click();
        }

        public void ClickDelete()

        {
            var deleteButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteButton));
            deleteButtonElement.Click();
        }

        public void DeleteAllLanguages()
        {
            // Repeatedly find delete icons and click them until none are left
            while (true)
            {
                var deleteButtonElement = _driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                if (deleteButtonElement.Count == 0)
                    break;


                deleteButtonElement[0].Click();



                Thread.Sleep(15000);

                Console.Write("All languages deleted");
            }

        }

        public string GetSuccessMessage()
        {
            return _driver.FindElement(By.XPath("/html/body/div[1]/div")).Text;
        }
    }
}
