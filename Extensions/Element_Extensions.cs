using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MoneyCorp.Extensions
{
   public static class Element_Extensions //Extension class is marked static 
    {

        #region All the static functions defined here
        public static void EnterText(this IWebElement element, string text, ExtentReportsHelper extentReportsHelper, string elementName) 
            //An extension method is a static method of a static class, where the "this" modifier is applied to the first parameter. The type of the first parameter will be the type that is extended.
            //Here we have created a method with Clear function merged to Sendkeys, so as to clear the element and then use sendkeys on an element
        {
            element.Clear();
            element.SendKeys(text);
            //extentReportsHelper.SetStepStatusPass($"[{elementName}] Data is entered.");
            //extentReportsHelper.Scree("test");
        }

        public static bool IsDisplayed(this IWebElement element, string elementName, ExtentReportsHelper extentReportsHelper)
        {
            //Here we have created a method with Displayed function to check if element exist or not and try catch exception handling

            bool result;
            try
            {
                result = (element.Displayed && element != null);
                extentReportsHelper.SetStepStatusPass($"Element [{elementName}] is displayed");
            }
            catch (Exception)
            {
                result = false;
                extentReportsHelper.SetStepStatusWarning($"Element [{elementName}] is not displayed");
            }

            return result;
        }
        public static void WaitAndClick(this IWebElement element, IWebDriver driver, string elementName, ExtentReportsHelper extentReportsHelper)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.IgnoreExceptionTypes(typeof(NoSuchWindowException));
            wait.Timeout.TotalSeconds.ToString("10");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//button[text()='Filter']")));
            element.Click();
            
        }
        public static bool IsAt(this string url, IWebDriver driver)
        {
            if (driver.Url == url)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ScrollAndClick(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }
        #endregion
    }
}
