using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

//Task
// 1.	Navigate to http://webdriveruniversity.com/Actions/index.html
// 2.	Drag “Drag me to my target” element to “Drop here!” element
// 3.	Assert it is dropped
// 4.	Double click “Double Click Me!” element
// 5.	Assert it changed color
// 6.	Hover “Hover Over Me Second!”
// 7.	Click on link in dropdown menu
// 8.	Assert alert with “Well done you clicked on the link!” text appear
// 9.	Accept alert
// 10.	Click and hold “Click and Hold!” element
// 11.	Assert “Well done” message appear

namespace Test6
{
    public static class Test6
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://webdriveruniversity.com/Actions/index.html");
            var blockToDrag = driver.FindElement(By.Id("draggable"));
            var blockWhereToDrag = driver.FindElement(By.Id("droppable"));
            var builder = new Actions(driver);
            builder.DragAndDrop(blockToDrag, blockWhereToDrag).Perform();
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='droppable']/p/b")).Text,"Dropped!");
            var message = driver.FindElement(By.Id("double-click"));
            var oldColor = message.GetCssValue("background-color");
            builder.DoubleClick(message).Build().Perform();
            Assert.AreNotEqual(oldColor, message.GetCssValue("background-color"));
            var hoverMeFirst = driver.FindElement(By.XPath("//*[@id='div-hover']/div[2]/button"));
            builder.MoveToElement(hoverMeFirst).Perform();
            driver.FindElement(By.XPath("//*[@id='div-hover']/div[2]/div/a")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(IsAlertShown);
            var gotMessageAlert = driver.SwitchTo().Alert().Text;
            Assert.IsTrue(gotMessageAlert == "Well done you clicked on the link!");
            driver.SwitchTo().Alert().Accept();
            builder.ClickAndHold(driver.FindElement(By.Id("click-box")));
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
