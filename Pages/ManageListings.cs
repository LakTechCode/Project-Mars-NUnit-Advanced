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
    public class ManageListings
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public ManageListings(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }
        public void DeleteAllShareSkillListings(IWebDriver driver)
        {
            // Repeatedly find delete icons and click them until none are left
            while (true)
            {
                var deleteSkillListingsButtonElement = driver.FindElements(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));
                if (deleteSkillListingsButtonElement.Count == 0)
                    break;


                deleteSkillListingsButtonElement[0].Click();

                
                // Click YES
                var yesButton = _wait.Until(
                    ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/div/div[3]/button[2]")));
                yesButton.Click();

                Thread.Sleep(15000);

                Console.Write("All skill listings deleted");
            }

        }
    }
}
