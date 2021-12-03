using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

// 1.	Navigate to http://webdriveruniversity.com/Popup-Alerts/index.html
// 2.	Click “JavaScript Alert” “Click Me!” button
// 3.	Accept alert
// 4.	Click “Modal Popup” “Click Me!” button
// 5.	Close modal popup
// 6.	Click “JavaScript Confirm Box” “Click Me!”
// 7.	Accept alert
// 8.	Click “JavaScript Confirm Box” “Click Me!”
// 9.	Cancel alert
// 10.	Assert “You pressed Cancel!” label appear

namespace Test7
{
    public static class Test6
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://webdriveruniversity.com/Popup-Alerts/index.html");
            driver.FindElement(By.XPath("//*[@id='button1']/p")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(IsAlertShown);
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.XPath("//*[@id='button2']/p")).Click();
            wait.Until(d => d.FindElement(By.XPath("//*[@id='myModal']/div/div/div[1]/h4")).Displayed);
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#myModal > div > div > div.modal-footer > button")).Click();
            driver.FindElement(By.XPath("//*[@id='button4']/p")).Click();
            wait.Until(IsAlertShown);
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.XPath("//*[@id='button4']/p")).Click();
            wait.Until(IsAlertShown);
            driver.SwitchTo().Alert().Dismiss();
            Assert.AreEqual(driver.FindElement(By.Id("confirm-alert-text")).Text, "You pressed Cancel!");
            driver.Quit();

            bool IsAlertShown(IWebDriver d)
            {
                try
                {
                    d.SwitchTo().Alert();
                }
                catch (NoAlertPresentException e)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
