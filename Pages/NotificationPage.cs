using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Project_Mars_NUnit.Drivers;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars_NUnit.Pages
{
    public class NotificationPage : CommonDriver
    {
        private readonly WebDriverWait _wait;
        private NotificationPage notificationPage;

        //locators
        private readonly By Dashboardbutton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[1]");
        private readonly By LoadMoreElement = By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[6]/div/center/a");
        private readonly By ShowLessElement = By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[7]/div[1]/center/a");
        private readonly By ManageListingsElement = By.XPath("//*[@id=\"notification-section\"]/section[1]/div/a[3]");
        private readonly By ShareSkillDashboardButton = By.XPath("//*[@id=\"service-listing-section\"]/section[1]/div/a[1]");
        private readonly By MarkAllasRead = By.XPath("//*[@id=\"service-listing-section\"]/div[1]/div[2]/div/div/div[2]/span/div/div[1]/div[1]");
        private readonly By NotificationDropdown = By.XPath("//*[@id=\"service-listing-section\"]/div[1]/div[2]/div/div");
        private readonly By Checkbox = By.XPath("//div[@id='notification-section']//input[@type='checkbox']");
        private readonly By MarkSelectionasRead = By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[4]");
        private readonly By SelectAllButton = By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[1]");
        private readonly By UnselectAllButton = By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[2]");

        public NotificationPage(IWebDriver driver)
        {
            driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }

        public void OpenNotifications()
        {
            var notificationdropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(Dashboardbutton));
            notificationdropdown.Click();

        }


        public void ClickLoadMore()
        {
            var loadMoreElement = _wait.Until(ExpectedConditions.ElementToBeClickable(LoadMoreElement));
            loadMoreElement.Click();
        }

   
        public int GetNotificationCount()
        {
            return driver.FindElements(By.XPath("//input[@type='checkbox']")).Count;
        }

        public void ClickShowLess()
        {
            var showLessElement = _wait.Until(ExpectedConditions.ElementToBeClickable(ShowLessElement));
            showLessElement.Click();
        }
        public void ClearAllNotifications()


        {
           

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            while (true)
            {
                // Step 1: Get all visible checkboxes
                var checkboxes = driver.FindElements(By.XPath("//div[@id='notification-section']//input[@type='checkbox']"));

                if (checkboxes.Count == 0)
                {
                    Console.WriteLine("All notifications cleared.");
                    break;
                }

                // Step 2: Select all checkboxes
                foreach (var checkbox in checkboxes)
                {
                    if (checkbox.Displayed && checkbox.Enabled && !checkbox.Selected)
                    {
                        checkbox.Click();
                    }
                }

                // Step 3: Click Delete
                var deleteButton = wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath("//div[@id='notification-section']//i[contains(@class,'trash') or contains(@class,'delete')]")
                ));

                deleteButton.Click();
                Console.WriteLine($"Deleted {checkboxes.Count} notifications");

                // Step 4: Wait until those checkboxes are gone (important!)
                wait.Until(driver =>
                {
                    var remaining = driver.FindElements(By.XPath("//div[@id='notification-section']//input[@type='checkbox']"));
                    return remaining.Count < checkboxes.Count;
                });

            }
        }

        public void NavigateToManageListings()

        {
            var manageListingsElement = _wait.Until(ExpectedConditions.ElementToBeClickable(ManageListingsElement));
            manageListingsElement.Click();

        }

        public void OpenNotificationsServiceListing()
        {
            var notificationServiceListingdropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(ShareSkillDashboardButton));
            notificationServiceListingdropdown.Click();

        }

        public void MarkAllAsRead()

        {
            var markAllasReadElement = _wait.Until(ExpectedConditions.ElementToBeClickable(MarkAllasRead));
            markAllasReadElement.Click();

        }
        public void AssertBlueLabelNotPresent()
        {
            var elements = driver.FindElements(
                By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div/div[1]")
            );

            if (elements.Count > 0)
            {
                throw new Exception("Blue notification label is still present");
            }
        }

        public void ClickNotifications()

        {
            var notificationDropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(NotificationDropdown));
            notificationDropdown.Click();

        }

        public void ClickCheckbox()

        {
            var checkbox = _wait.Until(ExpectedConditions.ElementToBeClickable(Checkbox));
            checkbox.Click();

        }

        public void MarkSelectionAsRead()

        {
            var markSelectionasReadElement = _wait.Until(ExpectedConditions.ElementToBeClickable(MarkSelectionasRead));
            markSelectionasReadElement.Click();

        }

        public bool AreAllCheckboxesSelected()
        {
            var checkboxes = driver.FindElements(By.XPath("//input[@type='checkbox']"));

            return checkboxes.All(cb => cb.Selected);
        }

        public void ClickSelectAll()

        {
            var selectAllButton = _wait.Until(ExpectedConditions.ElementToBeClickable(SelectAllButton));
            selectAllButton.Click();

        }

        public void ClickUnselectAll()

        {
            var unselectAllButton = _wait.Until(ExpectedConditions.ElementToBeClickable(UnselectAllButton));
            unselectAllButton.Click();

        }

    }


    }

