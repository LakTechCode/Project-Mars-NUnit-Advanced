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
    public class HomePage ()
    {
        
        public void NavigateToSkillsPage(IWebDriver driver)


        {
            IWebElement skills = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skills.Click();
        }

        public void NavigateToShareSkillPage(IWebDriver driver)


        {
            IWebElement shareskill = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/section[1]/div/div[2]/a"));
            shareskill.Click();
        }

        public void NavigateToManageListings(IWebDriver driver)


        {
            IWebElement shareskill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
            shareskill.Click();

        }

        public void NavigateToProfileShareSkillPage(IWebDriver driver)


        {
            IWebElement shareskill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[2]/a"));
            shareskill.Click();
        }

        public void NavigateToServiceShareSkillPage(IWebDriver driver)


        {
            IWebElement shareskill = driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/section[1]/div/div[2]/a"));
            shareskill.Click();
        }

    }
}
