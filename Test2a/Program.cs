using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// Task
// 1.	Navigate to http://webdriveruniversity.com/Contact-Us/contactus.html
// 2.	Assert that all fields contain placeholder
// 3.	Enter First name and Last name
// 4.	Click “Submit” button
// 5.	Assert error: all fields are required
namespace Test2a
{
    public static class Test2A
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://webdriveruniversity.com/Contact-Us/contactus.html");
            var elementsWithPlaceholder = driver.FindElements(By.ClassName("feedback-input"));
            foreach (var element in elementsWithPlaceholder)
            {
                Assert.IsFalse(string.IsNullOrEmpty(element.GetAttribute("placeholder")));
            }

            driver.FindElement(By.Name("first_name")).SendKeys("Alinka");
            driver.FindElement(By.Name("last_name")).SendKeys("Barc");
            driver.FindElement(By.XPath("//*[@id='form_buttons']/input[2]")).Click();
            var errorText = driver.FindElement(By.TagName("body")).Text;
            Assert.AreEqual("Error: all fields are required", errorText);
            driver.Quit();
        }
    }
}
