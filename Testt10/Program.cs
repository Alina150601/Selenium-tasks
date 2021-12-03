using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

// 1.	Navigate to http://webdriveruniversity.com/To-Do-List/index.html
// 2.	Add 2 new items in to-do list
// 3.	Remove one item
// 4.	Assert items count is 4

namespace Test10
{
    public static class Test10
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            Actions actions = new Actions(driver);
            driver.Navigate().GoToUrl("http://webdriveruniversity.com/To-Do-List/index.html");
            var inputToEnterNewItem = driver.FindElement(By.XPath("//input[contains(@placeholder,'Add new todo')]"));
            inputToEnterNewItem.SendKeys("Learn XPath");
            inputToEnterNewItem.SendKeys(Keys.Enter);
            inputToEnterNewItem.SendKeys("Conjure snow");
            inputToEnterNewItem.SendKeys(Keys.Enter);
            var elementToDelete = driver.FindElement(By.XPath("//*[@id='container']/ul/li[1]"));
            actions.MoveToElement(elementToDelete).Build().Perform();
            driver.FindElement(By.XPath("//*[@id='container']/ul/li[1]/span/i")).Click();
            var allItemsCount = driver.FindElements(By.XPath("//*[@id='container']/ul/li")).Count;
            wait.Until(d => d.FindElement(By.XPath("//*[@id='container']/ul/li[1]")).Displayed);
            //not displayed
            Assert.IsTrue(allItemsCount==4);
            driver.Quit();
        }
    }
}
