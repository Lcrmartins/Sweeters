using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Sweeters.Extensions
{
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Extension Method to introduce a WebDriverWait automaticaly.
        /// </summary>
        /// <param name="driver">This instance of WebDriver</param>
        /// <param name="by">The mecanism to find elements in a page</param>
        /// <param name="timeoutInSeconds">Integer number indicating the max waiting time, in seconds</param>
        /// <returns></returns>
        //public static async Task<IWebElement> FindElementAsync(this IWebDriver driver, Zu.AsyncWebDriver.By by, int timeoutInSeconds)
        //{
        //    if (timeoutInSeconds > 0)
        //    {
        //        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //        return wait.Until(drv => drv.FindElement(by));
        //    }
        //    return driver.FindElement(by);
        //}

        /// <summary>
        /// To maximize the window of the browser.Since the page is dynamic, the window must stay maximized to show all the options.
        /// </summary>
        /// <param name="driver">this instance of the WebDriver</param>
        public static void MaximizeBrowser(this IWebDriver driver) => driver.Manage().Window.Maximize();

        public static IList<IWebElement> WaitForItems(this IWebDriver driver, By by, int twitTryNumber, int timeout)
        {
            Thread.Sleep(1000);
            IList<IWebElement> elements;
            bool timedout;
            var now = DateTime.Now;
            do
            {
                elements = driver.FindElements(by);
                timedout = (DateTime.Now - now).Seconds > timeout;

            } while (!timedout && elements.Count != twitTryNumber);
            return elements;
        }
    }
}
