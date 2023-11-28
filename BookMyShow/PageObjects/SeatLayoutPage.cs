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
    internal class SeatLayoutPage
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        public SeatLayoutPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            fluentWait = CoreCodes.FluentWait(this.driver);
        }
        
        [FindsBy(How = How.XPath, Using = "proceed-Qty")]
        [CacheLookup]
        private IWebElement? SelectSeatsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='_available']")]
        [CacheLookup]
        private IWebElement? AvailableSeat { get; set; }

        [FindsBy(How = How.Id, Using = "btmcntbook")]
        [CacheLookup]
        private IWebElement? PayButton { get; set; }

        [FindsBy(How = How.Id, Using = "btnPopupAccept")]
        [CacheLookup]
        private IWebElement? TermsAndConditionsAcceptButton { get; set; }

        [FindsBy(How = How.Id, Using = "prePay")]
        [CacheLookup]
        private IWebElement? PaymentConfirmButton { get; set; }

        public void SelectNumberofSeats(string number)
        {
            fluentWait.Until(d=>d.FindElement(By.Id("pop_" + number))).Click();
        }
        public void SelectSeatsButtonClick()
        {
            SelectSeatsButton?.Click();
        }
        public void SelectAvailableSeats()
        {
            AvailableSeat?.Click();
        }
        public void PayButtonClick()
        {
            PayButton?.Click();
        }
        public void TermsAndConditionsAccept()
        {
            TermsAndConditionsAcceptButton?.Click();
        }
        public PaymentPage PaymentConfirmButtonClick()
        {
            fluentWait.Until(d => PaymentConfirmButton?.Displayed == true);
            PaymentConfirmButton?.Click();
            return new PaymentPage(driver);
        }
    }
}
