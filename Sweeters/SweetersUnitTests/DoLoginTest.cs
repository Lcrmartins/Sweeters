using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Sweeters.Entities;
using Sweeters.Operations;
using Sweeters.Services;
using Xunit;

namespace Sweeters.UnitTests
{
    public class DoLoginTest
    {
        [Fact]
        public static void LoginTestComonString1()
        {
            MySettings set = new("https://www.twitter.com/login", "mytesting832@gmail.com", "MyTestingAcc832", "173205080", "//div[text()=\"Please verify your account\"]", "//span[text()=\"Phone, email, or username\"]", "//span[text()=\"Phone or username\"]", "input[name=\"session[username_or_email]\"]", "input[name=\"session[username_or_email]\"]", "input[name=\"session[password]\"]", "input[data-testid=\"SearchBox_Search_Input\"]", "a[href$=\"&f=live\"]", "a[href$=\"&f=user\"]", "a[href$=\"&f=image\"]", "a[href$=\"&f=video\"]", "div[data-testid=\"tweet\"]", ".//span[contains(text(),\"@\")]", "time", "datetime", ".//div[2]/div[2]/div[1]", ".//div[2]/div[2]/div[2]", ".//div[2]/div[2]/div[3]", "div[data-testid=\"reply\"]", "div[data-testid=\"retweet\"]", "div[data-testid=\"like\"]", "a[href*=\"/status/\"]", "href", "//span[contains(text(),\"To get started\")]", "input[name=\"username\"]", "div[role=\"button\"]", "input[name=\"password\"]", 10, "Top", "en-US");
            string inputSearchString = "Formula One";
            string searchString = "Formula One";
            IWebDriver wd = new ChromeDriver();
            var expected = new QueryTask[1];
            string originalWindow = "TextValueForOriginalWindow1";
            string message = "nothing to do";
            int maxresults = 10;
            string sortOption = "Top";
            bool success = true;
            expected[0] = new(searchString, maxresults, sortOption, wd, success, originalWindow, message);
            QueryTask[] result = Methods.DoLogin(set, inputSearchString);
            wd.Close();
            wd.Quit();
            Assert.Equal(expected[0].SearchString, result[0].SearchString);
        }

        [Fact]
        public static void LoginTestComonString2()
        {
            MySettings set = new("https://www.twitter.com/login", "mytesting832@gmail.com", "MyTestingAcc832", "173205080", "//div[text()=\"Please verify your account\"]", "//span[text()=\"Phone, email, or username\"]", "//span[text()=\"Phone or username\"]", "input[name=\"session[username_or_email]\"]", "input[name=\"session[username_or_email]\"]", "input[name=\"session[password]\"]", "input[data-testid=\"SearchBox_Search_Input\"]", "a[href$=\"&f=live\"]", "a[href$=\"&f=user\"]", "a[href$=\"&f=image\"]", "a[href$=\"&f=video\"]", "div[data-testid=\"tweet\"]", ".//span[contains(text(),\"@\")]", "time", "datetime", ".//div[2]/div[2]/div[1]", ".//div[2]/div[2]/div[2]", ".//div[2]/div[2]/div[3]", "div[data-testid=\"reply\"]", "div[data-testid=\"retweet\"]", "div[data-testid=\"like\"]", "a[href*=\"/status/\"]", "href", "//span[contains(text(),\"To get started\")]", "input[name=\"username\"]", "div[role=\"button\"]", "input[name=\"password\"]", 10, "Top", "en-US");
            string inputSearchString = "Formula One";
            string searchString = "Formula One";
            IWebDriver wd = new ChromeDriver();
            var expected = new QueryTask[1];
            string originalWindow = "TextValueForOriginalWindow1";
            string message = "nothing to do";
            int maxresults = 10;
            string sortOption = "Top";
            bool success = true;
            expected[0] = new(searchString, maxresults, sortOption, wd, success, originalWindow, message);
            QueryTask[] result = Methods.DoLogin(set, inputSearchString);
            wd.Close();
            wd.Quit();
            Assert.Equal(expected[0].Success.ToString(), result[0].Success.ToString());
        }

        [Fact]
        public static void LoginTestFinalyze()
        {
            MySettings set = new("https://www.twitter.com/login", "mytesting832@gmail.com", "MyTestingAcc832", "173205080", "//div[text()=\"Please verify your account\"]", "//span[text()=\"Phone, email, or username\"]", "//span[text()=\"Phone or username\"]", "input[name=\"session[username_or_email]\"]", "input[name=\"session[username_or_email]\"]", "input[name=\"session[password]\"]", "input[data-testid=\"SearchBox_Search_Input\"]", "a[href$=\"&f=live\"]", "a[href$=\"&f=user\"]", "a[href$=\"&f=image\"]", "a[href$=\"&f=video\"]", "div[data-testid=\"tweet\"]", ".//span[contains(text(),\"@\")]", "time", "datetime", ".//div[2]/div[2]/div[1]", ".//div[2]/div[2]/div[2]", ".//div[2]/div[2]/div[3]", "div[data-testid=\"reply\"]", "div[data-testid=\"retweet\"]", "div[data-testid=\"like\"]", "a[href*=\"/status/\"]", "href", "//span[contains(text(),\"To get started\")]", "input[name=\"username\"]", "div[role=\"button\"]", "input[name=\"password\"]", 10, "Top", "en-US");
            string inputSearchString = "cmd:finalyze";
            IWebDriver wd = new ChromeDriver();
            var expected = new QueryTask[1];
            string searchString = "cmd:finalyze";
            string originalWindow = "TextValueForOriginalWindow1";
            string message = "nothing to do";
            int maxresults = 10;
            string sortOption = "Top";
            bool success = true;
            expected[0] = new(searchString, maxresults, sortOption, wd, success, originalWindow, message);
            QueryTask[] result = Methods.DoLogin(set, inputSearchString);
            wd.Close();
            wd.Quit();
            Assert.Equal(expected[0].Success.ToString(), result[0].Success.ToString());
        }

        [Fact]
        public static void LoginTestInitialyze()
        {
            MySettings set = new("https://www.twitter.com/login", "mytesting832@gmail.com", "MyTestingAcc832", "173205080", "//div[text()=\"Please verify your account\"]", "//span[text()=\"Phone, email, or username\"]", "//span[text()=\"Phone or username\"]", "input[name=\"session[username_or_email]\"]", "input[name=\"session[username_or_email]\"]", "input[name=\"session[password]\"]", "input[data-testid=\"SearchBox_Search_Input\"]", "a[href$=\"&f=live\"]", "a[href$=\"&f=user\"]", "a[href$=\"&f=image\"]", "a[href$=\"&f=video\"]", "div[data-testid=\"tweet\"]", ".//span[contains(text(),\"@\")]", "time", "datetime", ".//div[2]/div[2]/div[1]", ".//div[2]/div[2]/div[2]", ".//div[2]/div[2]/div[3]", "div[data-testid=\"reply\"]", "div[data-testid=\"retweet\"]", "div[data-testid=\"like\"]", "a[href*=\"/status/\"]", "href", "//span[contains(text(),\"To get started\")]", "input[name=\"username\"]", "div[role=\"button\"]", "input[name=\"password\"]", 10, "Top", "en-US");
            string inputSearchString = "cmd:initialyze";
            IWebDriver wd = new ChromeDriver();
            var expected = new QueryTask[1];
            string searchString = "cmd:initialyze";
            string originalWindow = "TextValueForOriginalWindow1";
            string message = "Login done!";
            int maxresults = 10;
            string sortOption = "Top";
            bool success = true;
            expected[0] = new(searchString, maxresults, sortOption, wd, success, originalWindow, message);
            QueryTask[] result = Methods.DoLogin(set, inputSearchString);
            wd.Close();
            wd.Quit();
            Assert.Equal(expected[0].Success.ToString(), result[0].Success.ToString());
        }
    }
}