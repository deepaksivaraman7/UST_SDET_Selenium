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
    internal class RegistrationPage
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            fluentWait = CoreCodes.FluentWait(this.driver);
        }
        [FindsBy(How = How.Name, Using = "FullName")]
        private IWebElement FullNameInput { get; set; }

        [FindsBy(How = How.Name, Using = "primary_phoneNo")]
        private IWebElement PhoneNumberInput { get; set; }

        [FindsBy(How = How.Name, Using = "primary_email")]
        private IWebElement EmailInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='I agree to the Terms & Conditions']")]
        private IWebElement AgreeCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "registration-submit-button")]
        private IWebElement SubmitButton { get; set; }

        public void Register(string name,string mobno,string email)
        {
            FullNameInput?.SendKeys(name);
            PhoneNumberInput?.SendKeys(mobno);
            EmailInput?.SendKeys(email);
            AgreeCheckBox?.Click();
            fluentWait.Until(d => SubmitButton.Displayed == true);
            SubmitButton?.Click();
        }
    }
}
