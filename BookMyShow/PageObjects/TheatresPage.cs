using BookMyShow.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.PageObjects
{
    internal class TheatresPage
    {
        IWebDriver driver;
        //DefaultWait<IWebDriver> fluentWait;
        public TheatresPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            //fluentWait = CoreCodes.FluentWait(this.driver);
        }
        [FindsBy(How = How.XPath, Using = "//a[@class='showtime-pill'][1]")]
        private IWebElement? TimeSlotLink { get; set; }
        public SeatLayoutPage TimeSlotSelect()
        {
            TimeSlotLink?.Click();
            return new SeatLayoutPage(driver);
        }
    }
}
