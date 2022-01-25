using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using MoneyCorp.TestData;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
                         
namespace MoneyCorp.Base
{
    [SetUpFixture]  //Class that contains the OneTimeSetupUp and OneTimeTearDown method details
    class BaseClass
    {
        public static IWebDriver driver = null;
        public ExtentReportsHelper extentReportsHelper;
        MoneyCorpTestData moneyCorpTestData = new MoneyCorpTestData();

        /// <summary>
        /// Used initialize the IWebDriver and Navigate site URL
        /// </summary>
        /// <param name="URL">Please pass the URL to navigate</param>

        #region - Member functions defined        
       [OneTimeSetUp]  //Include Methods that should be called before any of the child tests are executed.
       public void LaunchChrome()
        {
            try
            {
                driver = new ChromeDriver(); //created instance of ChromeDriver
                driver.Navigate().GoToUrl(moneyCorpTestData.moneyCorpWebSiteURL);
                driver.Manage().Window.Maximize();  //Added to maximize the chorme browser window initate above
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2); //Added Implcit Wait to wait for 2 seconds before each is element located
                extentReportsHelper = new ExtentReportsHelper();
                extentReportsHelper.CreateTest("Scenarios to test MoneyCorp website");
            }
            catch (Exception Es)
            {
                Assert.Fail("Unable to Launch the chrome" + Es.Message);  //in case it fails, will get exception with message
            }
        }
        [OneTimeTearDown]  //Include Methods that should be called after the child tests are executed.
        public void QuitBrowser()
        {
            extentReportsHelper.Close();
            driver.Quit();
        }
        #endregion
    }
}
