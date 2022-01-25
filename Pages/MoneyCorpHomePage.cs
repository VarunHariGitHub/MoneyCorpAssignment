using MoneyCorp.Base;
using MoneyCorp.Extensions;
using MoneyCorp.ObjectRepositery;
using OpenQA.Selenium;

namespace MoneyCorp.Pages
{
	class MoneyCorpHomePage : BaseClass  //Page class inheriting base class
	{
		//This Page class contains all locators and their operations on elements.

		//Created object of Object Repository Class
		MoneyCorpObjectRepository obj = new MoneyCorpObjectRepository();

		#region  Defining the element variables
		public IWebElement countryUSAOptionElement => driver.FindElement(obj.countryUSAOption);
		public IWebElement findOutMoreButtonElement => driver.FindElement(obj.findOutMoreButton);
		public IWebElement acceptCookiesButtonElement => driver.FindElement(obj.acceptCookiesButton);
		public IWebElement languageIconElement => driver.FindElement(obj.languageIcon);
		#endregion

		#region  Defining the class functions
		public void AcceptCookies()
		{
			acceptCookiesButtonElement.Click();
		}
		public void Click(IWebElement element, string elementName)
		{
			Element_Extensions.WaitAndClick(element, driver, elementName, extentReportsHelper);
		}
		public void ScrollToUSAEnglishOptionAndClick(IWebElement element)
		{
			Element_Extensions.ScrollAndClick(driver, element); //Calling element extensions methods
		}
		public void ScrollTofindOutMoreButtonAndClick(IWebElement element)
		{
			Element_Extensions.ScrollAndClick(driver, element);
		}
		#endregion
	}
}