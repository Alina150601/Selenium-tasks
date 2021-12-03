using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

// 1.	Navigate to  http://webdriveruniversity.com/Click-Buttons/index.html
// Test 11.1
// 2.	Using method WebElement Click perform click by button
//     Test 11.2
// 2.	Using JavaScript perform click by button.


namespace Test12
{
    public static class Test12
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Navigate().GoToUrl("http://webdriveruniversity.com/Click-Buttons/index.html");

            driver.Quit();
        }
    }
}
