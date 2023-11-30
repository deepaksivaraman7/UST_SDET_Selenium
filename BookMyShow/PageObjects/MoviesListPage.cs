using BookMyShow.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.PageObjects
{
    internal class MoviesListPage
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        public MoviesListPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            fluentWait = CoreCodes.FluentWait(this.driver);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='sc-133848s-2 sc-ije77g-3 fVGEDJ']")]
        private IWebElement? LanguageSelectButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='sc-133848s-2 sc-ije77g-3 fVGEDJ']/div/div")]
        private IWebElement? ButtonText { get; set; }

        public FilteredMoviesPage LanguageSelectButtonClick()
        {
            fluentWait.Until(d=>LanguageSelectButton?.Displayed==true);
            LanguageSelectButton?.Click();
            return new FilteredMoviesPage(driver);
        }
        public string GetButtonText()
        {
           return ButtonText.Text;
        }
    }
}
