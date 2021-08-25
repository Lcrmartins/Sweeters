using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sweeters.Entities;
using Sweeters.Services;
using System;
using System.Threading.Tasks;

namespace Sweeters.Operations
{

    public class Methods
    {
        public static QueryTask[] taskList;


        /// <summary>
        /// This method does the Login into the Twitter's page.
        /// </summary>
        /// <param name="set">Is the instance of MySettings witch contains the App settings data from appsettings.json</param>
        /// <param name="searchString">Is tne string input in the request</param>
        /// <returns>returns a QueryTask Array containing the task data</returns>
        public static QueryTask[] DoLogin(MySettings set, string searchString)
        {
            QueryTask[] taskList = new QueryTask[10];
            var wd = InternetConnection.Driver.drv;

            wd.Navigate().GoToUrl(set.LoginUrl);
            wd.Manage().Window.Maximize();
            string originalWindow = wd.CurrentWindowHandle;

            // if (searchString != "cmd:initialyze" && searchString != "cmd:finalyze")
            if (searchString != "cmd:initialyze")
            {
                string message = "nothing to do";
                taskList[0] = new(searchString, set.MaxResults, set.SortOption, wd, true, originalWindow, message);
                return taskList;
            }

            // vrf if there is the user and e-mail field
            bool loginSuccess = false;
            for (int count = 1; !loginSuccess && count <= 3; count++)
            {
                if (new WebDriverWait(wd, TimeSpan.FromSeconds(5)).Until(e => e.FindElements(By.XPath(set.LoginIndPhoneEmailUsernameXPath))).Count > 0)
                {
                    try
                    {
                        var user = wd.FindElement(By.CssSelector(set.UserEmailCSS));
                        user.Click();
                        user.Clear();
                        user.SendKeys(set.UserEmail);

                        var passwordField = new WebDriverWait(wd, TimeSpan.FromSeconds(10))
                                            .Until(e => e.FindElement(By.CssSelector(set.PasswordCSS)));
                        passwordField.Click();
                        passwordField.Clear();
                        passwordField.SendKeys(set.Password);
                        Task.Delay(138);
                        passwordField.SendKeys(Keys.Return);
                    }
                    catch (Exception e)
                    {
                        string message = "Couldn't login!\n" + e.Message;
                        taskList[0] = new(searchString, set.MaxResults, set.SortOption, wd, false, originalWindow, message);
                        return taskList;
                    }
                }
                if (new WebDriverWait(wd, TimeSpan.FromSeconds(10)).Until(e => e.FindElements(By.XPath(set.LoginIndPhoneUsernameXPath))).Count > 0)
                {
                    try
                    {
                        var user = wd.FindElement(By.CssSelector(set.UsernameCSS));
                        user.Click();
                        user.Clear();
                        user.SendKeys(set.UserName);

                        var passwordField = new WebDriverWait(wd, TimeSpan.FromSeconds(10)).Until(e => e.FindElement(By.CssSelector(set.PasswordCSS)));
                        passwordField.Clear();
                        passwordField.SendKeys(set.Password);
                        passwordField.SendKeys(Keys.Return);
                        Task.Delay(138);
                    }
                    catch (Exception e)
                    {
                        string message = "Couldn't login!\n" + e.Message;
                        taskList[0] = new(searchString, set.MaxResults, set.SortOption, wd, false, originalWindow, message);
                        return taskList;
                    }
                }
                if (new WebDriverWait(wd, TimeSpan.FromSeconds(5)).Until(e => e.FindElements(By.XPath(set.SearchToGetStartedXPath))).Count > 0)
                {
                    try
                    {
                        var user = wd.FindElement(By.CssSelector(set.SearchOnlyUsernameCSS));
                        user.Click();
                        user.Clear();
                        user.SendKeys(set.UserName);

                        var button = new WebDriverWait(wd, TimeSpan.FromSeconds(5)).Until(e => e.FindElement(By.CssSelector(set.SearchForButtonCSS)));
                        button.Click();

                        var passwordField = new WebDriverWait(wd, TimeSpan.FromSeconds(5)).Until(e => e.FindElement(By.CssSelector(set.SearchForPasswordFieldCSS)));
                        passwordField.Clear();
                        passwordField.SendKeys(set.Password);

                        var login = new WebDriverWait(wd, TimeSpan.FromSeconds(5)).Until(e => e.FindElement(By.CssSelector(set.SearchForButtonCSS)));
                        login.Click();

                        Task.Delay(138);
                    }
                    catch (Exception e)
                    {
                        string message = "Couldn't login!\n" + e.Message;
                        taskList[0] = new(searchString, set.MaxResults, set.SortOption, wd, false, originalWindow, message);
                        return taskList;
                    }
                }
                if (new WebDriverWait(wd, TimeSpan.FromSeconds(5)).Until(e => e.FindElements(By.XPath(set.LoginPageIndicatorXPath))).Count > 0)
                {
                    string message = "Couldn't login! Due to the Login bot restrictions from Twitter page";
                    taskList[0] = new(searchString, set.MaxResults, set.SortOption, wd, true, originalWindow, message);
                    return taskList;
                }

                loginSuccess = (new WebDriverWait(wd, TimeSpan.FromSeconds(10)).Until(e => e.FindElements(By.CssSelector(set.SearchCSS))).Count != 0);
            }
            if (new WebDriverWait(wd, TimeSpan.FromSeconds(10)).Until(e => e.FindElements(By.CssSelector(set.SearchCSS))).Count != 0)
            {
                string message = "Login done!";
                taskList[0] = new(searchString, set.MaxResults, set.SortOption, wd, true, originalWindow, message);
                return taskList;
            }
            else
            {
                string message = "Login fail!";
                taskList[0] = new(searchString, set.MaxResults, set.SortOption, wd, false, originalWindow, message);
                return taskList;
            }
        }

        // The sort option People was removed from teh options since this sort only shows the accounts, name and bio.
        // These "Tweets' dont have useful information.
        /// <summary>
        /// Identifier of the sort method of the tweets. It receives two strings: default sortOption and the searchString;
        /// </summary>
        /// <param name="sortOption">Contains the default options of Search, normally a string.Empty"</param>
        /// <param name="searchString">Contains the string contents inputed by the user.</param>
        /// <returns></returns>
        public static (string sortOption, string searchString) SortIdentifier(string sortOption, string searchString)
        {

            if (searchString.Contains("sort:latest", StringComparison.OrdinalIgnoreCase))
            {
                sortOption = "latest";
                searchString = searchString.Replace("sort:latest", string.Empty, StringComparison.OrdinalIgnoreCase);
            }
            else if (searchString.Contains("sort:people", StringComparison.OrdinalIgnoreCase))
            {
                // sortOption = "people";                
                searchString = searchString.Replace("sort:people", string.Empty, StringComparison.OrdinalIgnoreCase);
            }
            else if (searchString.Contains("sort:photos", StringComparison.OrdinalIgnoreCase))
            {
                sortOption = "photos";
                searchString = searchString.Replace("sort:photos", string.Empty, StringComparison.OrdinalIgnoreCase);
            }
            else if (searchString.Contains("sort:videos", StringComparison.OrdinalIgnoreCase))
            {
                sortOption = "videos";
                searchString = searchString.Replace("sort:videos", string.Empty, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                sortOption = string.Empty;
            }
            return (sortOption, searchString.Trim());
        }

        /// <summary>
        /// Identifier of the inserted maximum number of tweets in the results.
        /// </summary>
        /// <param name="maxResults">Integer default value of the maximum number of Tweets.</param>
        /// <param name="searchString">Contains the string contents inputed by the user.</param>
        /// <returns></returns>
        public static (int maxResults, string searchString) MaxResultIdentifier(int maxResults, string searchString)
        {
            string searchPartial = "";

            int index = searchString.IndexOf("maxresults:", StringComparison.OrdinalIgnoreCase);
            if (index != -1)
            {
                int start = index + 11;
                int end = searchString.IndexOf(" ", start);
                if (end == -1)
                {
                    searchPartial = searchString[start..];
                    bool haResult = int.TryParse(searchPartial, out maxResults);
                    searchString = searchString.Remove(index);
                }
                else
                {
                    searchPartial = searchString[start..end];
                    bool haResult = int.TryParse(searchPartial, out maxResults);
                    searchString = searchString.Remove(index, end - index + 1);
                }
            }

            return (maxResults, searchString.Trim());
        }

        /// <summary>
        /// Method to search and stract the account name of twit, with try exception treatment
        /// </summary>
        /// <param name="twit">this instance of tweeter</param>
        /// <param name="searchXPath">is the string of the search position o the intended data in the tweeter page</param>
        /// <returns>the return is a string containing the data</returns>
        public static string SearchDataXPathText(IWebElement twit, string searchXPath)
        {
            string dataString;
            try
            {
                var dataElement = twit.FindElement(By.XPath(searchXPath));
                dataString = dataElement.Text;
            }
            catch (Exception)
            {
                dataString = "Failed to Obtain.";
            }
            return dataString;
        }

        /// <summary>
        /// Method to search and stract the data of twit, with try exception treatment
        /// </summary>
        /// <param name="twit">this instance of tweeter</param>
        /// <param name="searchStringCSS">is the string of the search selection value of the data in the tweeter page</param>
        /// <param name="searchStringAttribute">is the string containing the name of the atribute witch value is the data</param>
        /// <returns>the return is a string containing the data value</returns>
        public static string SearchDataCSSSelectorAttribute(IWebElement twit, string searchStringCSS, string searchStringAttribute)
        {
            string dataString;
            try
            {
                var dataElement = twit.FindElement(By.CssSelector(searchStringCSS));
                dataString = dataElement.GetAttribute(searchStringAttribute);

            }
            catch (Exception)
            {
                dataString = "Failed to Obtain.";
            }
            return dataString;
        }

        /// <summary>
        /// Method to search and stract data of the tweet, with try exception tretment
        /// </summary>
        /// <param name="twit">this instance of tweeter</param>
        /// <param name="searchCSS">is the string of the search selection value in the tweeter page</param>
        /// <returns>The return is a string that represents the data.</returns>
        public static string SearchDataCSSSelectorText(IWebElement twit, string searchCSS)
        {
            string dataString = "";
            try
            {
                var dataElement = twit.FindElement(By.CssSelector(searchCSS));
                dataString = dataElement.Text;
                return dataString;
            }
            catch
            {
                return dataString;
            }
        }

        /// <summary>
        /// Converts string to integer with safety
        /// </summary>
        /// <param name="input">string to be converted to integer</param>
        /// <returns>integer</returns>
        public static int ConvertToInt(string input)
        {
            bool success = int.TryParse(input, out int integer);
            if (!success)
            {
                integer = -1;
            }
            return integer;
        }

        /// <summary>
        /// Converts strings formed by $.$K or $.$M to integer
        /// </summary>
        /// <param name="input">sttring representing the value</param>
        /// <param name="multiplyer">value of the multiplyer letter</param>
        /// <returns>returns a integer</returns>
        public static int ConvertToInt(string input, string multiplyer)
        {
            input.Trim();
            float value;
            if (input == "" || input == " ")
            {
                return 0;
            }

            bool parseOk = float.TryParse(input, out value);
            if (!parseOk)
            {
                return -1;
            }

            if (multiplyer == "K")
            {
                try
                {
                    value *= 1000;
                    return (int)value;
                }
                catch
                {
                    return -1;
                }
            }
            else if (multiplyer == "M")
            {
                try
                {
                    value *= 1000000;
                    return (int)value;
                }
                catch
                {
                    return -1;
                }
            }
            else if (multiplyer?.Length == 0)
            {
                return ConvertToInt(input);
            }
            return -1;
        }

        /// <summary>
        /// Method that returns a int value that represents a value in a string
        /// </summary>
        /// <param name="stringNumber">string represented as a number</param>
        /// <returns>An int number represented by the string input</returns>
        public static int StringToIntHandle(string stringNumber)
        {
            string number = stringNumber.Trim();
            try
            {
                return int.Parse(number);
            }
            catch
            {
                if (number == "" || number == " ")
                {
                    return 0;
                }
                else if (number == null)
                {
                    return -1;
                }
                else
                {
                    if (number.EndsWith("K"))
                    {
                        number = number.Replace("K", "");
                        return ConvertToInt(number, "K");
                    }
                    else if (number.EndsWith("M"))
                    {
                        number = number.Replace("M", "");
                        return ConvertToInt(number, "M");
                    }
                }
                return -1;
            }
        }

        public static string UniqueIdHandler(string rawUniqueId)
        {
            if (rawUniqueId == null)
            {
                return "Fail to obtain data";
            }
            else if (rawUniqueId.Length < 50)
            {
                return "Fail to obtain data";
            }
            else if (!rawUniqueId.Contains("/status/"))
            {
                return "Fail to obtain data";
            }

            return rawUniqueId[20..];
        }

    }
}
