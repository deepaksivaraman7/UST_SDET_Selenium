using BookMyShow.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.PageObjects
{
    internal class BMSHomePage
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        public BMSHomePage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            fluentWait = CoreCodes.FluentWait(this.driver);
        }
        //Arrange
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search for your city']")]
        private IWebElement? SearchCityInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@class='bwc__sc-1iyhybo-9 fMpEag']")]
        private IWebElement? CitySelectOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"super-container\"]/div[2]/div[3]/div[1]/div[1]/div/div/div/div[2]/div/div[1]/div[2]/a")]
        private IWebElement? MovieLink { get; set; }

        

        //Act
        public void SelectCity(string city)
        {
            SearchCityInput?.SendKeys(city);
            fluentWait.Until(d => CitySelectOption?.Displayed == true);
            CitySelectOption?.Click();
        }
        public MoviePage SelectMovie()
        {
            fluentWait.Until(d => MovieLink?.Displayed == true);
            MovieLink?.Click();
            return new MoviePage(driver);
        }
        public void ScrollIntoView(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
