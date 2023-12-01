using BookMyShow.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface;
using SeleniumExtras.PageObjects;
using Serilog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.PageObjects
{
    internal class BMSHomePage
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        public BMSHomePage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            fluentWait = CoreCodes.FluentWait(this.driver);
        }
        //Arrange
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search for your city']")]
        private IWebElement? SearchCityInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@class='bwc__sc-1iyhybo-9 fMpEag']")]
        private IWebElement? CitySelectOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"super-container\"]/div[2]/div[3]/div[1]/div[1]/div/div/div/div[2]/div/div[1]/div[2]/a")]
        private IWebElement? MovieLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='bwc__sc-1nbn7v6-10 lgYuCR ellipsis']")]
        private IWebElement LocationSelectButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Movies")]
        private IWebElement MoviesLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Activities")]
        private IWebElement ActivitiesLink { get; set; }

        [FindsBy(How = How.TagName, Using = "a")]
        private IList<IWebElement> AllLinks { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='Sign in']")]
        private IWebElement SignInButton { get; set; }

        [FindsBy(How = How.Id, Using = "mobileNo")]
        private IWebElement MobileNumberField { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Continue']")]
        private IWebElement ContinueButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='Verify your Mobile Number']")]
        private IWebElement OtpPopUp { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='bwc__sc-dh558f-5 fcHGRh']")]
        private IWebElement BackToSignInButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='bwc__sc-dh558f-4 eeSODb']")]
        private IWebElement CloseSignInButton { get; set; }

        //Act
        public void SelectCity(string city)
        {
            fluentWait.Until(d => SearchCityInput?.Displayed == true);
            SearchCityInput?.SendKeys(city);
            fluentWait.Until(d => CitySelectOption?.Displayed == true);
            CitySelectOption?.Click();
        }
        public MoviePage SelectMovie()
        {
            fluentWait.Until(d => MovieLink?.Displayed == true);
            MovieLink?.Click();
            return new MoviePage(driver);
        }
        public void ChangeLocationClick()
        {
            LocationSelectButton?.Click();
        }
        public OtherEventsPage EventLinkCLick(string link)
        {
            fluentWait.Until(d=>d.FindElement(By.LinkText(link))?.Displayed == true);
            driver.FindElement(By.LinkText(link))?.Click();
            return new OtherEventsPage(driver);
        }
        public ActivitiesPage ActivitiesLinkClick()
        {
            ActivitiesLink?.Click();
            return new ActivitiesPage(driver);
        }
        public MoviesListPage MoviesLinkCLick()
        {
            MoviesLink?.Click();
            return new MoviesListPage(driver);
        }
        public void MobileNumberInput(string mobno)
        {
            fluentWait.Until(d => MobileNumberField?.Displayed == true);
            MobileNumberField?.SendKeys(mobno);
        }
        public string GetPopUpHeading()
        {
            return OtpPopUp.Text;
        }
        public void SignInButtonClick()
        {
            SignInButton?.Click();
        }
        public bool ContinueButtonClick()
        {
            try
            {
                ContinueButton?.Click();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void BackToSignInClick()
        {
            fluentWait.Until(d=>BackToSignInButton?.Displayed == true);
            BackToSignInButton?.Click();
        }
        public void CloseSignInClick()
        {
            fluentWait.Until(d => CloseSignInButton?.Displayed == true);
            CloseSignInButton?.Click();
        }
        public List<string> AllLinksStatusCheck()
        {

            List<string> invalidUrls = new();
            foreach (var link in AllLinks)
            {
                string url = link.GetAttribute("href");
                if (url == null)
                {
                    Log.Information("Url is null");
                    invalidUrls.Add(url);
                    continue;
                }
                else
                {
                    bool isWorking = CoreCodes.CheckLinkStatus(url);
                    if (isWorking)
                    {
                        Log.Information(url + " is working");
                    }
                    else
                    {
                        Log.Information(url + " is not working");
                        invalidUrls.Add(url);
                    }
                }
            }
            return invalidUrls;
        }
    }
}
