using System;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SanteDB.BusinessRules.JavaScript;

// 1.	Navigate to http://webdriveruniversity.com/Scrolling/index.html
// 2.	Scroll to the first element (zone1)
// 3.	Assert the text of element is changed to “Well done for scrolling to me!”
// 4.	Scroll to elements of zone2.
// 5.	Assert the number of entries is changes.
// 6.	Scroll to the element of zone3 using coordinates.
// 7.	Assert x,y coordinates are displayed.
//
//      But I think the task is incorrect. Correct version:
//
// 1.	Navigate to http://webdriveruniversity.com/Scrolling/index.html
// 2.	Scroll to the zone1 element.
// 3.	Assert the text of element is changed to “Well done for scrolling to me!”.
// 4.	Scroll to the zone2 element, then to the zone3 element.
// 5.	Assert the numbers of entries are changes both in zone2 and zone3.
// 6.	Scroll to the element of zone4 using coordinates.
// 7.	Assert x,y coordinates are displayed.

namespace Test13
{
    public static class Test13
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            var actions = new Actions(driver);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Navigate().GoToUrl("http://webdriveruniversity.com/Scrolling/index.html");

            var zone1 = driver.FindElement(By.Id("zone1"));
            var zone1Text = zone1.Text;
            actions.MoveToElement(zone1).Perform();
            Assert.AreNotEqual(zone1Text, zone1.Text);
            Assert.AreEqual("Well done for scrolling to me!", zone1.Text);

            var zone2 = driver.FindElement(By.Id("zone2"));
            var zone3 = driver.FindElement(By.Id("zone3"));
            for (var i = 0; i < 2; i++) // check if it increments instead of be changed once
            {
                var zone2Text = zone2.Text;
                var zone3Text = zone3.Text;
                actions.MoveToElement(zone2).MoveToElement(zone3).Perform();
                Assert.AreNotEqual(zone2Text, zone2.Text);
                Assert.AreNotEqual(zone3Text, zone3.Text);
            }

            var zone4 = driver.FindElement(By.Id("zone4"));
            var zone4Text = zone4.Text;
            //JavascriptExecutor js = (JavascriptExecutor) driver;
            //js.ExecuteScript("window.scrollBy("60", " 99 ")");

            driver.ExecuteJavaScript("window.scrollBy(0, 270)");
            Assert.AreNotEqual(zone4Text, zone4.Text);
            var regex = new Regex(@"X\s*.?\s*\d*.*Y\s*.?\s*\d*", RegexOptions.IgnoreCase);
            // With this regex all variants below are valid:
            // blabla X: 123 Y: 123 blablabla
            // bla X-43Y-323 blabla
            // X=32 and Y= 331
            Assert.IsTrue(regex.IsMatch(zone4.Text));

            driver.Quit();
        }
    }
}
