using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Sweeters.Services;

namespace Sweeters.Operations
{
    public class InternetConnection
    {
        private InternetConnection()
        {

        }
        private static InternetConnection driver;


        public IWebDriver drv = new ChromeDriver();

        public static InternetConnection Driver
        {
            get
            {
                return driver ??= new InternetConnection();
            }
        }
    }
}
