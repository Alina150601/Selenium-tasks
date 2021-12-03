using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

// TASK
// 1.	Navigate to http://webdriveruniversity.com/Dropdown-Checkboxes-RadioButtons/index.html
// 2.	From “Dropdown Menu(s)” section select:
// -	C#
// -	Maven
// -    CSS
// 3.	Check “Option 1” and uncheck “Option 3” checkboxes
// 4.	Select “Yellow” radio button
// 5.	Check “Cabbage” radio button is disabled
// 6.	Check “Orange” option is disabled
// 7.	Select “Apple” option
namespace Test4
{
    public static class Test4
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://webdriveruniversity.com/Dropdown-Checkboxes-RadioButtons/index.html");

            //DROPDOWN MENU(S)
            // select the drop down list
            var dropdownMenu1 = driver.FindElement(By.Id("dropdowm-menu-1"));
            //create select element object
            var selectElementDropdown1 = new SelectElement(dropdownMenu1);
            //select by value
            selectElementDropdown1.SelectByValue("c#");

            var dropdownMenu2 = driver.FindElement(By.Id("dropdowm-menu-2"));
            var selectElementDropdown2 = new SelectElement(dropdownMenu2);
            selectElementDropdown2.SelectByValue("maven");

            var dropdownMenu3 = driver.FindElement(By.Id("dropdowm-menu-3"));
            var selectElementDropdown3 = new SelectElement(dropdownMenu3);
            selectElementDropdown3.SelectByValue("css");

            driver.FindElement(By.XPath("//*[@id='checkboxes']/label[1]/input")).Click();
            driver.FindElement(By.XPath("//*[@id='checkboxes']/label[3]/input")).Click();
            driver.FindElement(By.XPath("//*[@id='radio-buttons']/input[3]")).Click();
            var disabledRadioButton = driver.FindElement(By.XPath("//*[@id='radio-buttons-selected-disabled']"));
            Assert.IsTrue(disabledRadioButton.Enabled);
            driver.FindElement(By.XPath("//*[@id='fruit-selects']/option[1]")).Click();
            driver.Quit();
        }
    }
}
