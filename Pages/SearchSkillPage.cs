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
    public class SearchSkillPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public IWebDriver Driver => _driver;
        //locators
        private readonly By SearchSkillIcon = By.XPath("//*[@id=\"service-listing-section\"]/div[1]/div[1]/i");
        private readonly By AllCategories = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[1]");
        private readonly By ManageListingsButton = By.XPath("//*[@id=\"service-search-section\"]/section[1]/div/a[3]");
        private readonly By TestAutomationCategory = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[4]");
        private readonly By SeleniumSubcategory = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[5]");
        private readonly By OnlineButton = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[5]/button[1]\r\n");
        private readonly By OnsiteButton = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[5]/button[2]");

        public SearchSkillPage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }

        public void ClickSearchSkills()
        {
            var searchSkillElement = _wait.Until(ExpectedConditions.ElementToBeClickable(SearchSkillIcon));
            searchSkillElement.Click();
        }

        public void ClickAllCategories()
        {
            var allCategoriesElement = _wait.Until(ExpectedConditions.ElementToBeClickable(AllCategories));
            allCategoriesElement.Click();
        }

        public List<string> GetDisplayedSkillTitles()
        {
            List<string> titles = new List<string>();

            // First XPath for one kind of page
            var titleElements1 = _driver.FindElements(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[2]/p"));
            titles.AddRange(titleElements1.Select(t => t.Text));

            // Second XPath for another kind of page
            var titleElements2 = _driver.FindElements(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[2]/div[1]/a[2]/p"));
            titles.AddRange(titleElements2.Select(t => t.Text));

            return titles;
        }

        public void NavigateToManageListings(IWebDriver driver)


        {
            var manageListingsElement = _wait.Until(ExpectedConditions.ElementToBeClickable(ManageListingsButton));
            manageListingsElement.Click();

        }

        public void ClickTestAutomation()
        {
            var testAutomationCategoryElement = _wait.Until(ExpectedConditions.ElementToBeClickable(TestAutomationCategory));
            testAutomationCategoryElement.Click();
        }
        public void ClickSelenium()
        {
            var seleniumSubCategoryElement = _wait.Until(ExpectedConditions.ElementToBeClickable(SeleniumSubcategory));
            seleniumSubCategoryElement.Click();
        }

        public void ClickOnline()
        {
            var onlineButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(OnlineButton));
            onlineButtonElement.Click();
        }

        public void ClickOnsite()
        {
            var onsiteButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(OnsiteButton));
            onsiteButtonElement.Click();
        }

    }
}
