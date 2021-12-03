using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// Task
// 1.	Navigate to http://webdriveruniversity.com/Contact-Us/contactus.html
// 2.	Enter First name, Last name, Comment
// 3.	Enter Email value with incorrect format
// 4.	Click “Submit” button
// 5.	Assert error:  Invalid email address
namespace Test2b
{
    public static class Test2B
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://webdriveruniversity.com/Contact-Us/contactus.html");
            driver.FindElement(By.Name("first_name")).SendKeys("Alinka");
            driver.FindElement(By.Name("last_name")).SendKeys("Barc");
            driver.FindElement(By.Name("message")).SendKeys("Hello World!");
            driver.FindElement(By.Name("email")).SendKeys("alina.barc!");
            driver.FindElement(By.XPath("//*[@id='form_buttons']/input[2]")).Click();
            var errorText = driver.FindElement(By.TagName("body")).Text;
            Assert.AreEqual("error: invalid email address", errorText.ToLower());
            driver.Quit();
        }
    }
}
