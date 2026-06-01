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
    public class SkillDetailsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public IWebDriver Driver => _driver;
        //locators
        private readonly By MessageField = By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[1]/textarea");
        private readonly By RequestButton = By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[3]");
        private readonly By YesButton = By.XPath("/html/body/div[4]/div/div[3]/button[1]");
        private readonly By WithdrawElement = By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[2]");


        public SkillDetailsPage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }
        public void EnterMessage(string message)

        {
            var messageElement = _wait.Until(ExpectedConditions.ElementToBeClickable(MessageField));
            messageElement.SendKeys(message);

        }

        public void AddHours()
        {
            IWebElement hoursTextbox = _driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[2]/div[1]/input"));

            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", hoursTextbox);

            hoursTextbox.SendKeys("1");
        }

        public void ClickRequest()
        {
            var requestElement = _wait.Until(ExpectedConditions.ElementToBeClickable(RequestButton));
            requestElement.Click();
        }

        public void ClickYes()
        {
            var yesElement = _wait.Until(ExpectedConditions.ElementToBeClickable(YesButton));
            yesElement.Click();
        }

        public void ClickWithdraw()
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var element = _wait.Until(SeleniumExtras.WaitHelpers
                        .ExpectedConditions.ElementToBeClickable(WithdrawElement));

                    element.Click();
                    return;
                }
                catch (StaleElementReferenceException)
                {
                    Thread.Sleep(300); // wait briefly and retry
                }
            }

            throw new Exception("Withdraw button kept going stale.");
        }

       

    }
}
