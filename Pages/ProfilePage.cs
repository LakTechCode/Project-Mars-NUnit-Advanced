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
    public class ProfilePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        //locators
        private readonly By EditAvailability = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i");
        private readonly By AvailabilityDropDown = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select");
        private readonly By EditHours = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i");
        private readonly By HoursDropDown = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select");
        private readonly By EditEarnTarget = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i");
        private readonly By EarnTargetDropDown = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select");
        public ProfilePage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }

        public void ClickEditAvailability()

        {
            var editAvailabilityElement = _wait.Until(ExpectedConditions.ElementToBeClickable(EditAvailability));
            editAvailabilityElement.Click();

        }

        public void SelectAvailability(string availability)

        {
            var dropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(AvailabilityDropDown));
            var select = new SelectElement(dropdown);
            select.SelectByText(availability);

        }

        public string GetSuccessMessage()
        {
            return _driver.FindElement(By.XPath("/html/body/div[1]/div")).Text;
        }

        public void ClickEditHours()

        {
            var editHoursElement = _wait.Until(ExpectedConditions.ElementToBeClickable(EditHours));
            editHoursElement.Click();

        }

        public void SelectHours(string hours)

        {
            var dropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(HoursDropDown));
            var select = new SelectElement(dropdown);
            select.SelectByText(hours);

        }

        public string GetCurrentAvailability()
        {
            // Wait until the dropdown is clickable / visible
            var dropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(AvailabilityDropDown));

            // Wrap it in a SelectElement (works for <select> elements)
            var select = new SelectElement(dropdown);

            // Return the currently selected option's text
            return select.SelectedOption.Text.Trim();
        }

        public string GetCurrentHours()
        {
            // Wait until the dropdown is clickable / visible
            var dropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(HoursDropDown));

            // Wrap it in a SelectElement (works for <select> elements)
            var select = new SelectElement(dropdown);

            // Return the currently selected option's text
            return select.SelectedOption.Text.Trim();
        }

        public void ClickEditEarnTarget()

        {
            var editEarnTargetElement = _wait.Until(ExpectedConditions.ElementToBeClickable(EditEarnTarget));
            editEarnTargetElement.Click();

        }

        public void SelectEarnTarget(string target)

        {
            var dropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(EarnTargetDropDown));
            var select = new SelectElement(dropdown);
            select.SelectByText(target);

        }

        public string GetCurrentEarnTarget()
        {
            // Wait until the dropdown is clickable / visible
            var dropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(EarnTargetDropDown));

            // Wrap it in a SelectElement (works for <select> elements)
            var select = new SelectElement(dropdown);

            // Return the currently selected option's text
            return select.SelectedOption.Text.Trim();
        }

    }
}
