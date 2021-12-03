using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

// TASK
// 1.	Navigate to http://webdriveruniversity.com/Accordion/index.html
// 2.	Wait for “LOADING COMPLETE.” Label appear
// 3.	Expand “Keep Clicking” accordion
// 4.	Get text from expanded accordion
// 5.	Assert it is equal to “This text has appeared after 5 seconds!”
// 6.	Collapse expanded accordion

namespace Test3
{
    public static class Test3
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://webdriveruniversity.com/Accordion/index.html");
            var wait = new WebDriverWait(driver,new TimeSpan(0,0,10));
            driver.FindElement(By.XPath("//*[@id='click-accordion']")).Click();
            wait.Until(drv=>drv.FindElement(By.XPath("//*[@id='hidden-text'][contains(text(),'LOADING COMPLETE.')]")));
            var expandedText = driver.FindElement(By.XPath("//*[@id='timeout']")).Text;
            Assert.AreEqual("This text has appeared after 5 seconds!", expandedText);
            driver.Quit();
        }
    }
}
