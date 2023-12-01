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
    internal class ActivitiesPage
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        public ActivitiesPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            fluentWait = CoreCodes.FluentWait(this.driver);
        }

        [FindsBy(How = How.XPath, Using = "//a[@class='sc-133848s-11 sc-1ljcxl3-1 cxWSPX']")]
        private IWebElement ActivityLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='sc-133848s-11 sc-1ljcxl3-1 cxWSPX']/div/div[2]")]
        private IWebElement ActivityName { get; set; }

        public ActivityPage ActivityLinkClick()
        {
            fluentWait.Until(d => ActivityLink?.Displayed == true);
            ActivityLink?.Click();
            return new ActivityPage(driver);
        }
        public string GetActivityName()
        {
            fluentWait.Until(d => ActivityName?.Displayed == true);
            return ActivityName.GetAttribute("data-content");
        }
        
    }
}
