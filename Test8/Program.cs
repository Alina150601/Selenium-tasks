using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

//TASK
// 1.	Navigate to http://webdriveruniversity.com/IFrame/index.html
// 2.	Get “Who Are We?” section description
// 3.	Assert it contains “Lorem ipsum” phrase
// 4.	Click “WebdriverUniversity.com (IFrame)” button

namespace Test8
{
    public static class Test8
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://webdriveruniversity.com/IFrame/index.html");
            var element = driver.FindElements(By.TagName("p")).First();
            var sectionDescriptionText = element.Text;
            Assert.IsTrue(sectionDescriptionText.Contains("Lorem ipsum"));
            driver.FindElement(By.Id("nav-title")).Click();
            driver.Quit();
        }
    }
}
