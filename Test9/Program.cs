using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

// 1.	Navigate to http://webdriveruniversity.com/File-Upload/index.html
// 2.	Upload any file
// 3.	Assert alert appear

namespace Test9
{
    public class Test9
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://webdriveruniversity.com/File-Upload/index.html");
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}whoWashTheDish.txt";
            driver.FindElement(By.Id("myFile")).SendKeys(path);
            driver.FindElement(By.Id("submit-button")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var alertAppear = wait.Until(IsAlertShown);
            Assert.IsTrue(alertAppear);
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
