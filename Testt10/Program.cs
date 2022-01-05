using System;
using System.Linq;
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
            const string conjureSnow = "Conjure snow";
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            Actions actions = new Actions(driver);
            driver.Navigate().GoToUrl("http://webdriveruniversity.com/To-Do-List/index.html");
            var inputToEnterNewItem = driver.FindElement(By.XPath("//input[contains(@placeholder,'Add new todo')]"));
            inputToEnterNewItem.SendKeys("Learn XPath");
            inputToEnterNewItem.SendKeys(Keys.Enter);
            inputToEnterNewItem.SendKeys(conjureSnow);
            inputToEnterNewItem.SendKeys(Keys.Enter);
            var elementToDelete = driver.FindElement(By.XPath($"//*[@id='container']/ul/li[contains(text(),'{conjureSnow}')]"));
            actions.MoveToElement(elementToDelete).Build().Perform();
            driver.FindElement(By.XPath($"//*[@id='container']/ul/li[contains(text(),'{conjureSnow}')]/span/i")).Click();
            wait.Until(d => d.FindElements(By.XPath($"//*[@id='container']/ul/li[contains(text(),'{conjureSnow}')]")).Count == 0);
            var allItemsCount = driver.FindElements(By.XPath("//*[@id='container']/ul/li")).Count;
            Assert.AreEqual(4,allItemsCount);
            driver.Quit();
        }
    }
}
