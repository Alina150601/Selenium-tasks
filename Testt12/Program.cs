using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SanteDB.BusinessRules.JavaScript;
using SeleniumExtras.WaitHelpers;

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
            driver.FindElement(By.Id("button1")).Click();
            wait.Until(d=>d.FindElement(By.CssSelector("#myModalClick > div > div > div.modal-footer > button")));
            driver.FindElement(By.CssSelector("#myModalClick > div > div > div.modal-footer > button")).Click();
            var element = driver.FindElement(By.Id("button2"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
            driver.FindElement(By.XPath("//*[contains(text(),'Close']")).Click();
            driver.FindElement(By.ClassName("btn")).Click();
            driver.Quit();
        }
    }
}
