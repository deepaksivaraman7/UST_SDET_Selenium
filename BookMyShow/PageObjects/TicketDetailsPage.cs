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
    internal class TicketDetailsPage
    {

        IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        public TicketDetailsPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            fluentWait = CoreCodes.FluentWait(this.driver);
        }
        [FindsBy(How = How.XPath, Using = "//div[@style='cursor: pointer; pointer-events: auto;']")]
        private IWebElement AvailableDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-id='time-pill']")]
        private IWebElement AvailableTime { get; set; }

        [FindsBy(How = How.Id, Using = "booking-continue-button")]
        private IWebElement ContinueButton { get; set; }

        public void AvailableDateAndTimeClick()
        {
            AvailableDate?.Click();
            AvailableTime?.Click();
        }
        public AddPersonPage ContinueButtonClick()
        {
            ContinueButton?.Click();
            return new AddPersonPage(driver);
        }
    }
}
