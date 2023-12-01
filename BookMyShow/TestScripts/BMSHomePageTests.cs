using BookMyShow.PageObjects;
using BookMyShow.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.TestScripts
{
    [TestFixture]
    internal class BMSHomePageTests:CoreCodes
    {

        [Test, Order(1), Category("Smoke Test")]
        public void SelectCityTest()
        {
           var homePage = new BMSHomePage(driver);
            try
            {
                homePage.SelectCity("trivandrum");
                TakeScreenshot();
                Assert.That(driver.Url, Does.Contain("trivandrum"));
                LogTestResult("Select city Test", "Select city success");
                test = extent.CreateTest("Select city Test - Passed");
                test.Pass("Select city Success");
            }
            catch(Exception ex)
            {
                LogTestResult("Select city Test", "Select city failed",ex.Message);
                test = extent.CreateTest("Select city Test - Failed");
                test.Pass("Select city Failed");
                TakeScreenshot();
                Assert.Fail(ex.Message);
            }

        }
        [Test, Order(2), Category("Smoke Test")]
        public void AllLinksStatusTest()
        {
            var homePage = new BMSHomePage(driver);
            try
            {
                List<string> invalidUrls = homePage.AllLinksStatusCheck();
                TakeScreenshot();
                Assert.That(invalidUrls, Is.Not.Null);
                LogTestResult("All links status test", "All links status check success");
                test = extent.CreateTest("All links status test - Passed");
                test.Pass("All links status Success");
            }
            catch(Exception ex)
            {
                LogTestResult("All links status test", "All links status check failed", ex.Message);
                test = extent.CreateTest("All links status test - Failed");
                test.Pass("All links status Failed");
                TakeScreenshot();
                Assert.Fail(ex.Message);
            }

        }
        [Test, Order(3), Category("Smoke Test"),TestCase("mumbai")]
        public void ChangeLocationTest(string location)
        {
            var homePage = new BMSHomePage(driver);
            try
            {
                homePage.ChangeLocationClick();
                homePage.SelectCity(location);
                TakeScreenshot();
                Assert.That(driver.Url.Contains(location), Is.True);
                LogTestResult("Change location test", "Change location success");
                test = extent.CreateTest("Change location test - Passed");
                test.Pass("Change location Success");
            }
            catch (Exception ex)
            {
                LogTestResult("Change location test", "Change location failed", ex.Message);
                test = extent.CreateTest("Change location test - Failed");
                test.Pass("Change location Failed");
                TakeScreenshot();
                Assert.Fail(ex.Message);
            }

        }
        [Test, Order(4), Category("Smoke Test"),TestCaseSource(nameof(Links))]
        public void EventsPageRedirectTest(string link)
        {
            var homePage = new BMSHomePage(driver);
            try
            {
                var otherEventPage =homePage.EventLinkCLick(link);
                TakeScreenshot();
                Assert.That(otherEventPage.GetUrl(), Does.Contain(link.ToLower()));
                LogTestResult(link+" page redirect test", link+" page redirect success");
                test = extent.CreateTest(link+" page redirect test - Passed");
                test.Pass(link+" page redirect Success");
            }
            catch (Exception ex)
            {
                LogTestResult(link+" page redirect test", link+" page redirect failed", ex.Message);
                test = extent.CreateTest(link+" page redirect test - Failed");
                test.Pass(link+" page redirect Failed");
                TakeScreenshot();
                Assert.Fail(ex.Message);
            }

        }
        [Test, Order(5), Category("Smoke Test"),TestCaseSource(nameof(ValidMobileNumbers))]
        public void ValidSignInTest(string mobno)
        {
            var homePage = new BMSHomePage(driver);
            try
            {
                homePage.SignInButtonClick();
                homePage.MobileNumberInput(mobno);
                bool success=homePage.ContinueButtonClick();
                TakeScreenshot();
                Assert.That(success, Is.True);
                LogTestResult("Valid SignIn test", "Valid SignIn success");
                test = extent.CreateTest("Valid SignIn test - Passed");
                test.Pass("Valid SignIn Success");
                homePage.BackToSignInClick();
                homePage.CloseSignInClick();
            }
            catch (Exception ex)
            {
                LogTestResult("Valid SignIn test", "Valid SignIn failed", ex.Message);
                test = extent.CreateTest("Valid SignIn test - Failed");
                test.Pass("Valid SignIn Failed");
                TakeScreenshot();
                Assert.Fail(ex.Message);
            }

        }
        [Test, Order(5), Category("Smoke Test"), TestCaseSource(nameof(InvalidMobileNumbers))]
        public void InvalidSignInTest(string mobno)
        {
            var homePage = new BMSHomePage(driver);
            try
            {
                homePage.SignInButtonClick();
                homePage.MobileNumberInput(mobno);
                bool success = homePage.ContinueButtonClick();
                TakeScreenshot();
                Assert.That(success, Is.False);
                LogTestResult("Invalid SignIn test", "Invalid SignIn success");
                test = extent.CreateTest("Invalid SignIn test - Passed");
                test.Pass("Invalid SignIn Success");
                homePage.CloseSignInClick();
            }
            catch (Exception ex)
            {
                LogTestResult("Invalid SignIn test", "Invalid SignIn failed", ex.Message);
                test = extent.CreateTest("Invalid SignIn test - Failed");
                test.Pass("Invalid SignIn Failed");
                TakeScreenshot();
                Assert.Fail(ex.Message);
            }

        }
        static object[] Links()
        {
            return new object[]
            {
                new object[]{"Movies"},
                new object[]{"Stream"},
                new object[]{"Events"},
                new object[]{"Plays"},
                new object[]{"Sports"},
                new object[]{"Activities"},
            };
        }
        static object[] ValidMobileNumbers()
        {
            return new object[]
            {
                new object[]{"1234567890"},
                new object[]{"9876543210"},
            };
        }
        static object[] InvalidMobileNumbers()
        {
            return new object[]
            {
                new object[]{"12345"},
                new object[]{""},
                new object[]{"abcd"},
            };
        }
    }
}
