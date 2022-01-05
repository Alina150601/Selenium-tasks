using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

// 1.	Navigate to http://webdriveruniversity.com/Datepicker/index.html
// 2.	Assert default value data field  is current  date
// 3.	Using Datapicker select  “01-01-2021(current year)”
// 4.	Assert  data field  is “01-01-2021(current year)”

namespace Testt11
{
    public static class Test11
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Navigate().GoToUrl("http://webdriveruniversity.com/Datepicker/index.html");
            var defaultValueData =driver.FindElement(By.XPath("//*[@id='datepicker']/input")).GetAttribute("value");
            var today = DateTime.Now.ToString("MM-dd-yyyy");
            Assert.AreEqual(today,defaultValueData);

            driver.Quit();
        }
    }
}
