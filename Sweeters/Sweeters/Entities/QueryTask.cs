using OpenQA.Selenium;

namespace Sweeters.Entities
{
    public struct QueryTask
    {
        public string SearchString;
        public int MaxResults;
        public string SortOption;
        public IWebDriver Driver;
        public bool Success;
        public string OriginalWindow;
        public string Message;

        public QueryTask(string searchString, int maxresults, string sortOption, IWebDriver driver, bool success, string originalWindow, string message)
        {
            SearchString = searchString;
            MaxResults = maxresults;
            SortOption = sortOption;
            Driver = driver;
            Success = success;
            OriginalWindow = originalWindow;
            Message = message;
        }


    }
}
