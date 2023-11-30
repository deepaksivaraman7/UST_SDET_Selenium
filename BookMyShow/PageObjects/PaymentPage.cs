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
    internal class PaymentPage
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        public PaymentPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            fluentWait = CoreCodes.FluentWait(this.driver);
        }
        [FindsBy(How = How.Id, Using = "txtEmail")]
        private IWebElement? EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "txtMobile")]
        private IWebElement? MobileInput { get; set; }

        [FindsBy(How = How.Id, Using = "txtCardNo")]
        private IWebElement? CardNumberInput { get; set; }

        [FindsBy(How = How.Id, Using = "txtCardName")]
        private IWebElement? NameOnCardInput { get; set; }

        [FindsBy(How = How.Id, Using = "txtExpMonth")]
        private IWebElement? CardExpiryMonthInput { get; set; }

        [FindsBy(How = How.Id, Using = "txtExpYear")]
        private IWebElement? CardExpiryYearInput { get; set; }

        [FindsBy(How = How.Id, Using = "txtCVV")]
        private IWebElement? CardCvvInput { get; set; }

        [FindsBy(How = How.Id, Using = "makeCardPayment")]
        private IWebElement? MakePaymentButton { get; set; }
        public void EmailInputText(string email)
        {
            EmailInput?.SendKeys(email);
        }
        public void MobileInputText(string mob)
        {
            MobileInput?.SendKeys(mob);
        }
        public void CardNumberInputText(string cardNumber)
        {
            CardNumberInput?.SendKeys(cardNumber);
        }
        public void NameOnCardInputText(string name)
        {
            NameOnCardInput?.SendKeys(name);
        }
        public void CardExpiryMonthInputText(string name)
        {
            CardExpiryMonthInput?.SendKeys(name);
        }
        public void CardExpiryYearInputText(string name)
        {
            CardExpiryYearInput?.SendKeys(name);
        }
        public void CardCvvInputText(string name)
        {
            CardCvvInput?.SendKeys(name);
        }
        public void MakePaymentButtonClick()
        {
            MakePaymentButton?.Click();
        }
    }
}
