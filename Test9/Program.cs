using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

// 1.	Navigate to http://webdriveruniversity.com/File-Upload/index.html
// 2.	Upload any file
// 3.	Assert alert appear

public class Test9
{
    public static void Main(string[] args)
    {
        var driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://webdriveruniversity.com/File-Upload/index.html");
        // don't know why, but the name of txt file in the path doesn't work :c
        driver.FindElement(By.Id("myFile"))
            .SendKeys("/Users/malinka/RiderProjects/Selenium-tasks/Test9/whoWashTheDish.txt");
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
