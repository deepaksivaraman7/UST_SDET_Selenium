using BookMyShow.PageObjects;
using BookMyShow.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.TestScripts
{
    [TestFixture]
    internal class ActivityBookTests : CoreCodes
    {
        [Test, Order(1), Category("Regression Test")]
        public void ActivityBookTest()
        {
            var homePage = new BMSHomePage(driver);
            Log.Information("Activity book test started");

            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "MovieBooking";
            List<BookMovie> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);
            foreach (var excelData in excelDataList)
            {
                
                string? city = excelData.City;
                string? name = excelData.NameOnCard;
                string? email=excelData.Email;
                string? mobno = excelData.MobileNumber;
                try
                {
                    homePage.SelectCity(city);
                    var activitiesPage=homePage.ActivitiesLinkClick();
                    Log.Information("Activities Link Clicked");
                    //TakeScreenshot();
                    //Assert.That(driver.Url, Does.Contain("activities"));

                    string activityName = activitiesPage.GetActivityName();
                    var activityPage =activitiesPage.ActivityLinkClick();
                    Log.Information("Selected an Activity");
                    //TakeScreenshot();
                    //Assert.That(driver.Title, Does.Contain(activityName));

                    var ticketDetailsPage=activityPage.BookButtonClick();
                    Log.Information("Book button clicked");
                    //TakeScreenshot();
                    //Assert.That(driver.Url, Does.Contain("datetime"));

                    ticketDetailsPage.AvailableDateAndTimeClick();
                    Log.Information("Date and Time selected");
                    var addPersonPage = ticketDetailsPage.ContinueButtonClick();
                    addPersonPage.AddPersonButtonClick();
                    Log.Information("Added a person");
                    var registrationPage =addPersonPage.ProceedButtonClick();
                    Log.Information("Proceed button clicked");
                    //TakeScreenshot();
                    //Assert.That(driver.Url, Does.Contain("registration"));

                    registrationPage.Register(name,mobno,email);
                    Log.Information("Registration attempted");

                    TakeScreenshot();
                    Assert.That(driver.Url, Does.Contain("ticket-options"));
                    LogTestResult("Activity book Test", "Activity book success");
                    test = extent.CreateTest("Activity book test - Passed");
                    test.Pass("Activity book Success");
                }
                catch (Exception ex)
                {
                    LogTestResult("Activity book Test", "Activity book failed", ex.Message);
                    test = extent.CreateTest("Activity book - Failed");
                    test.Fail("Activity book Failed");
                    TakeScreenshot();
                    Assert.Fail(ex.Message);
                }
            }
        }
    }
}
