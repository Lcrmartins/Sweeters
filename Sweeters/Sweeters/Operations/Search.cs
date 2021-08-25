using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sweeters.Entities;
using Sweeters.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Sweeters.Operations
{
    public class Search
    {
        private static readonly object openWindowAndFindSeachField = new();
        private static readonly object SearchCodeLock = new();

        private static Search _search;

        public static Search GetSearch() { return _search ??= new Search(); }

        /// <summary>
        /// Method to Extract the Tweeter data from the Twitter page.
        /// </summary>
        /// <param name="set">The instance of the data settings from configuration</param>
        /// <param name="searchString">The input string received from Controller</param>
        /// <returns></returns>
        public (List<Tweet>, string) ExtractTweeter(MySettings set, string searchString)
        {
            CultureInfo us = new(set.Us);

            var taskList = Methods.DoLogin(set, searchString);

            if (searchString == "cmd:initialyze")
            {
                var Twts = new List<Tweet>();
                return (Twts, taskList[0].Message);
            }
            else if (searchString == "cmd:finalyze")
            {
                var Twts = new List<Tweet>();
                taskList[0].Driver.Quit();
                string message = "Logout done!";
                return (Twts, message);
            }

            int maxResults = set.MaxResults;
            (maxResults, searchString) = Methods.MaxResultIdentifier(set.MaxResults, searchString);

            string sortOption = set.SortOption;
            (sortOption, searchString) = Methods.SortIdentifier(set.SortOption, searchString);

            int i = taskList[0].Driver.WindowHandles.Count;
            taskList[i] = new(searchString, maxResults, sortOption, taskList[0].Driver, true, taskList[0].OriginalWindow, "");
            IWebDriver driver = taskList[i].Driver;

            lock (openWindowAndFindSeachField)
            {
                // obtain the window id
                // originalWindow = driver.CurrentWindowHandle;
                var windows = driver.WindowHandles;
                int windowsCount = driver.WindowHandles.Count;

                //Open new window and find and change to it
                driver.SwitchTo().NewWindow(WindowType.Window);
                WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));
                wait.Until(wd => wd.WindowHandles.Count == windowsCount + 1);

                var NewwindowList = driver.WindowHandles.Except(windows);
                taskList[i].OriginalWindow = NewwindowList.First<string>();
                driver.SwitchTo().Window(taskList[i].OriginalWindow);

                driver.Navigate().GoToUrl("https://twitter.com/explore");
                driver.Manage().Window.Maximize();

                Thread.Sleep(2398);

                #region Search input
                // Search and find the search field and insert the searcString.
                var searchField = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                    .Until(e => e.FindElement(By.CssSelector(set.SearchCSS)));

                searchField.SendKeys(searchString);
                searchField.SendKeys(Keys.Return);
            }
            #endregion

            #region Input the Sort option

            IWebElement sort;

            switch (taskList[i].SortOption)
            {
                case "latest":
                    sort = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
             .Until(e => e.FindElement(By.CssSelector(set.LatestCSS))); sort.Click(); break;
                case "people":
                    sort = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
             .Until(e => e.FindElement(By.CssSelector(set.PeopleCSS))); sort.Click(); break;
                case "photos":
                    sort = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
             .Until(e => e.FindElement(By.CssSelector(set.PhotosCSS))); sort.Click(); break;
                case "videos":
                    sort = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
             .Until(e => e.FindElement(By.CssSelector(set.VideosCSS))); sort.Click(); break;
                default: break;
            }
            #endregion
            Thread.Sleep(3398);

            lock (SearchCodeLock)
            {
                #region Here the search begins ...
                int scrollCount = 0;
                int twitCount = 0;
                int replies = 0;
                int retweets = 0;
                int likes = 0;
                string uniqueId = "";
                string account = "";
                string timestamp = "";
                string content = "";
                bool isSaved = false;
                var Tweets = new List<Tweet>();

                // Return point to peek more tweets
                TweetSearch:

                // finding the tweets...
                var tweets = driver.FindElements(By.CssSelector(set.SearchTweetsCSS));
                // start a list of objects of class Tweet 

                foreach (var twit in tweets)
                {
                    account = Methods.SearchDataXPathText(twit, set.SearchAccountXPath);
                    string content1 = Methods.SearchDataXPathText(twit, set.SearchContent1XPath);
                    string content2 = Methods.SearchDataXPathText(twit, set.SearchContent2XPath);
                    string content3 = Methods.SearchDataXPathText(twit, set.SearchContent3XPath);
                    content = content1 + "\n" + content2 + "\n" + content3;
                    replies = Methods.StringToIntHandle(Methods.SearchDataCSSSelectorText(twit, set.SearchReplyCSS));
                    retweets = Methods.StringToIntHandle(Methods.SearchDataCSSSelectorText(twit, set.SearchRetweetCSS));
                    likes = Methods.StringToIntHandle(Methods.SearchDataCSSSelectorText(twit, set.SearchLikeCSS));
                    var rawUniqueId = Methods.SearchDataCSSSelectorAttribute(twit, set.SearchUniqueIdCSS, set.SearchUniqueIdAttribute);
                    uniqueId = Methods.UniqueIdHandler(rawUniqueId);
                    timestamp = Methods.SearchDataCSSSelectorAttribute(twit, set.SearchTimeStampCSS, set.SearchTimeAttribute);

                    Tweet twt = new(account, timestamp, content, replies, retweets, likes, uniqueId);

                    // Verify if the twit have been saved in Tweets List
                    isSaved = Tweets.Any(x => x.UniqueId == twt.UniqueId);
                    if (!isSaved)
                    {   //discarting the ads
                        if (timestamp != "")
                        {
                            Tweets.Add(twt);
                            twitCount++;
                            scrollCount = 0;
                        }
                    }
                }

                if (twitCount < taskList[i].MaxResults)
                {
                    // To do Scroll page
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    _ = js.ExecuteScript("window.scrollBy(0,2080);");
                    Thread.Sleep(857);
                    scrollCount++;
                    if (scrollCount <= 3)
                    {
                        Thread.Sleep(3398);
                        goto TweetSearch;
                    }
                    else
                    {
                        driver.Close();
                        driver.SwitchTo().Window(taskList[0].OriginalWindow);
                        return (Tweets, "Success but couldn't reach the max value");
                    }
                }
                #endregion 
                driver.Close();
                driver.SwitchTo().Window(taskList[0].OriginalWindow);
                return (Tweets, "Success!");
            }
        }
    }
}