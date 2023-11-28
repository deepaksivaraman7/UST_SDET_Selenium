using BookMyShow.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.CSS;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.PageObjects
{
    internal class MoviePage
    {
        
        IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        public MoviePage(IWebDriver driver)
        {
            
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            fluentWait=CoreCodes.FluentWait(this.driver);
        }
        [FindsBy(How = How.XPath, Using = "//button[@data-phase='postRelease']")]
        [CacheLookup]
        private IWebElement? BookTicketsButton { get; set; }
        public TheatresPage ClickBookTickets()
        {
            fluentWait.Until(d => BookTicketsButton?.Displayed==true);
            BookTicketsButton?.Click();
            return new TheatresPage(driver);
        }
    }
}
