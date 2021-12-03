using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

//TASK
// 1.	Navigate to http://webdriveruniversity.com/Login-Portal/fail.html
// 2.	Enter login “Admin”
// 3.	Enter password “Admin”
// 4.	Click “Login” button
// 5.	Assert text on alert is “validation failed”
// 6.	Accept alert
namespace Selenium_tasks
{
    public static class Test1
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://webdriveruniversity.com/Login-Portal/fail.html");
            var loginInput = driver.FindElement(By.XPath("//*[@id='text']"));
            loginInput.SendKeys("Admin");
            var passwordInput = driver.FindElement(By.XPath("//*[@id='password']"));
            passwordInput.SendKeys("Admin");
            driver.FindElement(By.XPath("//*[@id='login-button']")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(IsAlertShown);
            var gotMessage = driver.SwitchTo().Alert().Text;
            Assert.IsTrue(gotMessage == "validation failed");
            driver.SwitchTo().Alert().Accept();
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
