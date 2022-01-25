using MoneyCorp.Base;
using MoneyCorp.Extensions;
using MoneyCorp.ObjectRepositery;
using MoneyCorp.TestData;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MoneyCorp.Pages
{
    class MoneyCorpInternationalPaymentPage : BaseClass  //Page class inheriting base class
		{
			//This Page class contains all locators and their operations on elements.

			//Created object of Object Repository Class
			MoneyCorpObjectRepository obj = new MoneyCorpObjectRepository();
			MoneyCorpTestData moneyCorpTestData = new MoneyCorpTestData();


		#region  Defining the element variables
		private IList<IWebElement> searchedLinksListElement => driver.FindElements(obj.searchedLinks);
		#endregion

		#region  Defining the class functions

		public bool CheckPageURL(string url)
		{
			return Element_Extensions.IsAt(url, driver);
		}
		public bool ValidateLinks()
		{
			for (int i = 0; i < searchedLinksListElement.Count; i++)
			{
				if (searchedLinksListElement[i].GetAttribute("href").StartsWith(moneyCorpTestData.moneyCorpWebSiteUSURL))
				{

					return true;
				}
					
			}
					return false;
		}
        #endregion
    }
}
