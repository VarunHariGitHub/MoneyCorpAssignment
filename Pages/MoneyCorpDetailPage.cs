using MoneyCorp.Base;
using MoneyCorp.Extensions;
using MoneyCorp.ObjectRepositery;
using OpenQA.Selenium;

namespace MoneyCorp.Pages
{
    class MoneyCorpDetailPage : BaseClass  //Page class inheriting base class
		{
		//This Page class contains all locators and their operations on elements.
		//Page Object Model or POM  is a design pattern or a framework that we use in Selenium using which one can create an object repository of the different web elements across the application. To simplify, in the Page Object Model framework, we create a class file for each web page. This class file consists of different web elements present on the web page. Moreover, the test scripts then use these elements to perform different actions. Since each page's web elements are in a separate class file, the code becomes easy to maintain and reduces code duplicity. 

		//Created object of Object Repository Class
		MoneyCorpObjectRepository obj = new MoneyCorpObjectRepository();

#region  Defining the element variables
		public IWebElement searchIconElement => driver.FindElement(obj.searchIcon);
		public IWebElement searchTextFieldElement => driver.FindElement(obj.searchTextField);
		public IWebElement searchedLinksElement => driver.FindElement(obj.searchedLinks);
		public IWebElement acceptCookiesButtonElement => driver.FindElement(obj.acceptCookiesButton);
        
#endregion

#region  Defining the class functions
		public void Click(IWebElement element, string elementName) //calling the re-usable static methods such as WaitAndClick from Element_Extensions static class
		{
			Element_Extensions.WaitAndClick(element, driver, elementName, extentReportsHelper);
		}
		public void EnterText(IWebElement element, string text, ExtentReportsHelper extentReportsHelper, string elementName)
		{
			Element_Extensions.EnterText(element, text, extentReportsHelper, elementName);
		}
		public void ClickEnter(IWebElement element)
		{
			element.SendKeys(Keys.Enter);
		}
		public bool CheckPageURL(string url)
		{
		    return Element_Extensions.IsAt(url, driver);
		}
#endregion
	}
}
