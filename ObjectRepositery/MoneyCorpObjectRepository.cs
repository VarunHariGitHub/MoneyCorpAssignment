using OpenQA.Selenium;

namespace MoneyCorp.ObjectRepositery
{
    class MoneyCorpObjectRepository  //All the locator information resides here
    {
        public By countryUSAOption = By.XPath("//a[@aria-label = 'USA English']");
        public By findOutMoreButton = By.XPath("//h3[text()='Foreign exchange solutions']/following-sibling::a/span");
        public By searchIcon = By.XPath("//button[contains(@class,'navigation-search')]");
        public By searchTextField = By.Id("nav_search");
        public By searchedLinks = By.XPath("//a[@class='title']");
        public By acceptCookiesButton = By.Id("onetrust-accept-btn-handler");
        public By languageIcon = By.CssSelector("#language-dropdown-flag img");
    }
}
