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
    internal class AddPersonPage
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        public AddPersonPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            fluentWait = CoreCodes.FluentWait(this.driver);
        }

        [FindsBy(How = How.XPath, Using = "//div[@data-id='add-tickets'][1]")]
        private IWebElement AddPersonButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-id='ticket-selector-proceed")]
        private IWebElement ProceedButton { get; set; }
        public void AddPersonButtonClick()
        {
            AddPersonButton?.Click();
        }
        public RegistrationPage ProceedButtonClick()
        {
            ProceedButton?.Click();
            return new RegistrationPage(driver);
        }
    }
}
