using BookMyShow.PageObjects;
using BookMyShow.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.TestScripts
{
    [TestFixture]
    internal class MoviesLinkTests:CoreCodes
    {
        MoviesListPage? moviesListPage;
        [Test, Order(1), Category("Smoke Test")]
        public void MoviesLinkRedirectTest()
        {
            var homePage = new BMSHomePage(driver);
            try
            {
                homePage.SelectCity("trivandrum");
                TakeScreenshot();
                Assert.That(driver.Url, Does.Contain("trivandrum"));
                moviesListPage=homePage.MoviesLinkCLick();
                Assert.That(driver.Url, Does.Contain("movies"));
                LogTestResult("Movies link redirect Test", "Movies link redirect success");
                test = extent.CreateTest("Movies link redirect Test - Passed");
                test.Pass("Movies link redirect Success");
            }
            catch (Exception ex)
            {
                LogTestResult("Movies link redirect Test", "Movies link redirect failed", ex.Message);
                test = extent.CreateTest("Movies link redirect Test - Failed");
                test.Pass("Movies link redirect Failed");
                TakeScreenshot();
                Assert.Fail(ex.Message);
            }

        }
        [Test, Order(2), Category("Smoke Test")]
        public void MoviesFilterTest()
        {
            try
            {
                var filteredMoviesList = moviesListPage?.LanguageSelectButtonClick();
                Assert.That(driver.Url, Does.Contain("languages=" + moviesListPage?.GetButtonText().ToLower()));
                LogTestResult("Movies filter Test", "Movies filter success");
                test = extent.CreateTest("Movies filter Test - Passed");
                test.Pass("Movies filter Success");
            }
            catch (Exception ex)
            {
                LogTestResult("Movies filter Test", "Movies filter failed", ex.Message);
                test = extent.CreateTest("Movies filter Test - Failed");
                test.Pass("Movies filter Failed");
                TakeScreenshot();
                Assert.Fail(ex.Message);
            }

        }
    }
}
