using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

//Task
// 1.	Navigate to http://webdriveruniversity.com/Ajax-Loader/index.html
// 2.	Wait for loader disappear
// 3.	Click on green button
// 4.	Get alert title
// 5.	Assert it contains “Well Done” phrase
// 6.	Close alert

namespace Test5
{
    public static class Test5
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://webdriveruniversity.com/Ajax-Loader/index.html");
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until((d) => !d.FindElement(By.XPath("//*[@id='loader']")).Displayed);
            driver.FindElement(By.Id("button1")).Click();
            Thread.Sleep(2000);
            var alertTitle = driver.FindElement(By.ClassName("modal-title")).Text;
            var check = alertTitle.ToLower().Contains("well done");
            Assert.IsTrue(check);
            driver.FindElement(By.CssSelector(".modal-footer > button")).Click();
            driver.Quit();
        }
    }
}
