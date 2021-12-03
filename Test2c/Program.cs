using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

// TASK
// 1.	Navigate to http://webdriveruniversity.com/Contact-Us/contactus.html
// 2.	Enter First name, Last name, Comment
// 3.	Enter correct Email
// 4.	Click “Submit” button
// 5.	Assert new url and text “Thank You for your Message!”
namespace Test2c
{
    public static class Test2C
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://webdriveruniversity.com/Contact-Us/contactus.html");
            driver.FindElement(By.Name("first_name")).SendKeys("Alinka");
            driver.FindElement(By.Name("last_name")).SendKeys("Barc");
            driver.FindElement(By.Name("message")).SendKeys("Hello World");
            driver.FindElement(By.Name("email")).SendKeys("alina.barc@mail.ru");
            driver.FindElement(By.XPath("//*[@id='form_buttons']/input[2]")).Click();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(d => d.FindElement(By.XPath("//*[@id='contact_reply']/h1")));
            var message = driver.FindElement(By.XPath("//*[@id='contact_reply']/h1")).Text;
            Assert.AreEqual("Thank You for your Message!", message);
            driver.Quit();
        }
    }
}
