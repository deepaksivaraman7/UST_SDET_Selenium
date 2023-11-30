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
    internal class ActivityPage
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        public ActivityPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            fluentWait = CoreCodes.FluentWait(this.driver);
        }
        [FindsBy(How = How.XPath, Using = "//button[text()='Book']")]
        private IWebElement BookButton { get; set; }

        public TicketDetailsPage BookButtonClick()
        {
            BookButton?.Click();
            return new TicketDetailsPage(driver);
        }
    }
}
