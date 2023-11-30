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
    internal class OtherEventsPage
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        public OtherEventsPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            fluentWait = CoreCodes.FluentWait(this.driver);
        }
        public string GetUrl()
        {
            var url=fluentWait.Until(d => d.Url);
            return url;
        }
    }
}
