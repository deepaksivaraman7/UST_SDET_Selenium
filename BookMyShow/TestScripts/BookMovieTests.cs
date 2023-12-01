using BookMyShow.PageObjects;
using BookMyShow.Utilities;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.TestScripts
{
    [TestFixture]
    internal class BookMovieTests : CoreCodes
    {
        [Test, Order(1), Category("Regression Test")]
        public void BookAMovieTest()
        {
            var homePage = new BMSHomePage(driver);
            Log.Information("Book a movie test started");

            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "MovieBooking";
            List<BookMovie> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                if (!driver.Url.Equals("https://in.bookmyshow.com/"))
                {
                    driver.Navigate().GoToUrl("https://in.bookmyshow.com/");
                }
                try
                {
                    TakeScreenshot();
                    Assert.That(driver.Title, Does.Contain("BookMyShow"));

                    string? city = excelData.City;
                    string? numberOfSeats = excelData.NumberOfSeats;
                    string? email = excelData.Email;
                    string? mobno = excelData.MobileNumber;
                    string? cardno = excelData.CardNumber;
                    string? nameoncard = excelData.NameOnCard;
                    string? cardexpirymonth = excelData.CardExpiryMonth;
                    string? cardexpiryyear = excelData.CardExpiryYear;
                    string? cvv = excelData.CardCvv;

                    homePage.SelectCity(city);
                    Log.Information("City selected");
                    TakeScreenshot();
                    Assert.That(driver.Url, Does.Contain(city));

                    var moviePage = homePage.SelectMovie();
                    Log.Information("Movie Selected");
                    TakeScreenshot();
                    Assert.That(driver.Url, Does.Contain("movies"));

                    var theatresPage = moviePage.ClickBookTickets();
                    Log.Information("Clicked Book Tickets Button");
                    TakeScreenshot();
                    Assert.That(driver.Title, Does.Contain("Online Ticket Booking"));
                    
                    string buyTicketsUrl = driver.Url;
                    var seatLayoutPage = theatresPage.TimeSlotSelect();
                    Log.Information("Selected Timeslot");
                    TakeScreenshot();
                    Assert.That(driver.Url, Is.EqualTo(buyTicketsUrl + "#!seatlayout"));

                    seatLayoutPage.SelectNumberofSeats(numberOfSeats);
                    Log.Information("Selected number of seats");

                    seatLayoutPage.SelectSeatsButtonClick();
                    Log.Information("Proceed to seat selection layout");

                    seatLayoutPage.SelectAvailableSeats();
                    Log.Information("Selected available seats from the layout");

                    seatLayoutPage.PayButtonClick();
                    Log.Information("Clicked Pay button");

                    seatLayoutPage.TermsAndConditionsAccept();
                    Log.Information("Accepted terms and conditions");

                    seatLayoutPage.AddFoodItem();
                    Log.Information("Added food item");
                    TakeScreenshot();
                    Assert.That(seatLayoutPage.FoodSummaryCheck(), Is.True);

                    var paymentPage = seatLayoutPage.PaymentConfirmButtonClick();
                    Log.Information("Payment confirmation button clicked");

                    Assert.That(driver.Url, Does.Contain("payment"));

                    paymentPage.EmailInputText(email);
                    paymentPage.MobileInputText(mobno);
                    paymentPage.CardNumberInputText(cardno);
                    paymentPage.NameOnCardInputText(nameoncard);
                    paymentPage.CardExpiryMonthInputText(cardexpirymonth);
                    paymentPage.CardExpiryYearInputText(cardexpiryyear);
                    paymentPage.CardCvvInputText(cvv);
                    paymentPage.MakePaymentButtonClick();

                    LogTestResult("Book a movie Test", "Book a movie success");
                    test = extent.CreateTest("Book a movie test - Passed");
                    test.Pass("Book a movie Success");
                }
                catch (Exception ex)
                {
                    TakeScreenshot();
                    LogTestResult("Book a movie Test", "Book a movie failed", ex.Message);
                    test = extent.CreateTest("Book a movie - Failed");
                    test.Fail("Book a movie Failed");
                }

            }
        }
    }
}
