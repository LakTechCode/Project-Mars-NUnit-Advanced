using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Project_Mars_NUnit.Models;
using Project_Mars_NUnit.Utilities;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project_Mars_NUnit.Pages
{
    public class ShareSkillPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private ShareSkillPage _shareskillpage;
        public IWebDriver Driver => _driver;

        //locators
        private readonly By ShareSkillButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[2]/a");
        private readonly By AddTitleField = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input");
        private readonly By AddDescriptionField = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea");
        private readonly By CategoryDropdown = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div[1]/select");
        private readonly By SubcategoryDropdown = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select");
        private readonly By AddTagsField = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div[1]/div/div/div/input");
        private readonly By AddCreditField = By.XPath("//input[@name='charge']");
        private readonly By WorkSampleUploadInput = By.Id("selectFile");
        private readonly By SaveButton = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]");
        private readonly By ManageListingsButton = By.XPath("//*[@id=\"listing-management-section\"]/section[1]/div/a[3]");
        private readonly By TagsContainer = By.XPath("//div[contains(@class,'ReactTags__selected')]//span[contains(@class,'ReactTags__tag')]");
        private readonly By AddSkillExchangeField = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div[1]/div/div/div/div/input");
        private readonly By SkillsContainer = By.XPath("//div[contains(@class,'ReactTags__selected')]//span[contains(@class,'ReactTags__tag')]");
        private readonly By CancelButton = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[2]");
        public ShareSkillPage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }



        public void ClickShareSkill()
        {
            var shareSkillElement = _wait.Until(ExpectedConditions.ElementToBeClickable(ShareSkillButton));
            shareSkillElement.Click();
        }

        public void AddTitle(string title)

        {
            var addTitleElement = _wait.Until(ExpectedConditions.ElementToBeClickable(AddTitleField));
            addTitleElement.SendKeys(title);

        }

        public void AddDescription(string description)

        {
            var addDescriptionElement = _wait.Until(ExpectedConditions.ElementToBeClickable(AddDescriptionField));
            addDescriptionElement.SendKeys(description);

        }

        public void AddCategory(string category)
        {
        var dropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(CategoryDropdown));
        var select = new SelectElement(dropdown);
        select.SelectByText(category);

        }

        public void AddSubcategory(string subcategory)
        {
            var dropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(SubcategoryDropdown));
            var select = new SelectElement(dropdown);
            select.SelectByText(subcategory);

        }

        public void AddTags(List<string> tags)
        {
            var tagInput = _wait.Until(
                ExpectedConditions.ElementToBeClickable(AddTagsField)
            );

            foreach (var tag in tags)
            {
                tagInput.SendKeys(tag);
                tagInput.SendKeys(Keys.Enter);
            }
        }

        public void AddSkillExchange(List<string> skills)
        {
            var tagInput = _wait.Until(
                ExpectedConditions.ElementToBeClickable(AddSkillExchangeField)
            );

            foreach (var skill in skills)
            {
                tagInput.SendKeys(skill);
                tagInput.SendKeys(Keys.Enter);
            }
        }

        public string GetDirectTagText(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            return (string)js.ExecuteScript("return arguments[0].childNodes[0].nodeValue.trim();", element);
        }

        public string GetDirectSkillText(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            return (string)js.ExecuteScript("return arguments[0].childNodes[0].nodeValue.trim();", element);
        }

        public List<string> GetTagsClean()
        {
            var tagElements = _driver.FindElements(TagsContainer);
            return tagElements.Select(e => GetDirectTagText(e)).ToList();
        }

        public List<string> GetSkillsClean()
        {
            var skillElements = _driver.FindElements(SkillsContainer);
            return skillElements.Select(e => GetDirectSkillText(e)).ToList();
        }

        public void SelectServiceType(string serviceType)
        {
            string value = "0";
            var serviceTypeInput = _driver.FindElement(By.XPath($"//input[@name='serviceType' and @value='{value}']"));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", serviceTypeInput);

        }

        public void SelectLocationType(string LocationType)
        {

            var locationInput = _driver.FindElement(By.XPath($"//input[@name='locationType' and @value='{LocationType}']"));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", locationInput);

        }

        public void SelectCredit(string credit)
        {
            string value = "false";
            var skillTradeInput = _driver.FindElement(By.XPath($"//input[@name='skillTrades' and @value='{value}']"));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", skillTradeInput);

        }

        public void SelectSkillExchange(string skillexchange)
        {
            string value = "true";
            var skillTradeInput = _driver.FindElement(By.XPath($"//input[@name='skillTrades' and @value='{value}']"));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", skillTradeInput);

        }

        public void AddCredit(string credit)

        {
            var addCreditElement = _wait.Until(ExpectedConditions.ElementToBeClickable(AddCreditField));
            addCreditElement.Click();
            addCreditElement.Clear();
            addCreditElement.SendKeys(credit);

        }


        public void AddWorkSamples(string relativePath)
        {
            
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath); // absolute path

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"File not found: {fullPath}");

            var uploadInput = _wait.Until(driver => driver.FindElement(WorkSampleUploadInput));
            uploadInput.SendKeys(fullPath);

                    }

        public void SelectActive(string active)
        {
            string value = "true";
            var activeInput = _driver.FindElement(By.XPath($"//input[@name='isActive' and @value='{value}']"));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", activeInput);

        }

        public void ClickSave()
        {
            var option = _wait.Until(ExpectedConditions.ElementToBeClickable(SaveButton));

            option.Click();
        }

        public void NavigateToManageListings(IWebDriver driver)


        {
            var manageListingsElement = _wait.Until(ExpectedConditions.ElementToBeClickable(ManageListingsButton));
            manageListingsElement.Click();

        }

        public string GetSuccessMessage()
        {
            return _driver.FindElement(By.XPath("/html/body/div[2]/div")).Text;
        }

        public string GetFailureMessage()
        {
            return _driver.FindElement(By.XPath("/html/body/div[1]/div")).Text;
        }

        public string GetTitle()
        {
            return _driver.FindElement(AddTitleField).GetAttribute("value");
        }

        public string GetDescription()
        {
            return _driver.FindElement(AddDescriptionField).GetAttribute("value");
        }

        public int GetCredit()
        {
            string creditValue = _driver.FindElement(AddCreditField).GetAttribute("value");
            return int.Parse(creditValue);
        }

        public void ClickCancel()
        {
            var option = _wait.Until(ExpectedConditions.ElementToBeClickable(CancelButton));

            option.Click();
        }

        public bool AreThereAnyShareSkillListings()
        {
            var deleteButtons = _driver.FindElements(
                By.XPath("/html/body/div[2]/div/div[3]/button[2]")
            );

            return deleteButtons.Count > 0;
        }
        public void CreateSkill(ShareSkillData shareSkillData)
        {
            AddTitle(shareSkillData.Title);
            AddDescription(shareSkillData.Description);
            AddCategory(shareSkillData.Category);
            AddSubcategory(shareSkillData.Subcategory);
            AddTags(shareSkillData.Tags);
            SelectServiceType("0");
            SelectLocationType("1");
            SelectCredit("false");
            AddCredit(shareSkillData.Credit);
            AddWorkSamples(shareSkillData.WorkSamplePath);
            SelectActive("true");
            ClickSave();

            
        }
    }
}

