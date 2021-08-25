namespace Sweeters.Services
{
    public class MySettings
    {
        /// <summary>
        /// Constructor of the MySettings class.
        /// </summary>
        /// <param name="loginUrl">String that represents the Url of the of Twitter login page</param>
        /// <param name="userEmail">String that represents the value of the user Email</param>
        /// <param name="userName">String that represents the value of user username</param>
        /// <param name="password">String that represents the value of user password</param>
        /// <param name="loginPageIndicatorXPath">String that represents the localization of the field in page that indicates what page it is.</param>
        /// <param name="loginIndPhoneEmailUsernameXPath">String that represents the localization of the field phone, email or username</param>
        /// <param name="loginIndPhoneUsernameXPath">String that represents the localization of the field phone or username</param>
        /// <param name="userEmailCSS">String that represents the CSSSelector for the field user email</param>
        /// <param name="usernameCSS">String that represents the CSSSelector for the field username</param>
        /// <param name="passwordCSS">String that represents the CSSSelector for the field user password</param>
        /// <param name="searchCSS">String that represents the CSSSelector for the field search</param>
        /// <param name="latestCSS">String that represents the CSSSelector for the Latest option in Twitters page</param>
        /// <param name="peopleCSS">String that represents the CSSSelector for the People option in Twitters page</param>
        /// <param name="photosCSS">String that represents the CSSSelector for the Photos option in Twitters page</param>
        /// <param name="videosCSS">String that represents the CSSSelector for the Videos option in Twitters page</param>
        /// <param name="searchTweetsCSS">String that represents the CSSSelector for the tweets in Twitters page</param>
        /// <param name="searchAcountXPath">is the string of the search position o the account data in the tweeter page</param>
        /// <param name="searchTimeStampCSS">is the string of the search selection value of the timestamp data in the tweeter page</param>
        /// <param name="searchTimeAttribute">is the string containing the name of the atribute witch value is the timestamp</param>
        /// <param name="searchContent1XPath">is the string of the search position of the first content data in the tweeter page</param>
        /// <param name="searchContent2XPath">is the string of the search position of the second content data in the tweeter page</param>
        /// <param name="searchContent3XPath">is the string of the search position of the third content data in the tweeter page</param>
        /// <param name="searchReplyCSS">is the string of the search selection value of the number of replies in the tweeter page</param>
        /// <param name="searchRetweetCSS">is the string of the search selection value of the number of retweets in the tweeter page</param>
        /// <param name="searchLikeCSS">is the string of the search selection value of the number of likes in the tweeter page</param>
        /// <param name="searchUniqueIdCSS">is the string of the search selection value of the UniqueId in the tweeter page</param>
        /// <param name="searchUniqueIdAttribute">is the string containing the name of the atribute witch value is the UniqueId</param>
        /// <param name="searchToGetStartedXPath">String that represents the localization of the field in page that indicates what page it is.</param>
        /// <param name="searchOnlyUsernameCSS">String that represents the CSSSelector for the field username</param>
        /// <param name="searchForButtonCSS">String that represents the CSSSelector for the field button</param>
        /// <param name="searchForPasswordFieldCSS">String that represents the CSSSelector for the field userpassword</param>
        /// <param name="maxResults">Integer standard value on quantity of tweets in the result</param>
        /// <param name="sortOption">String that represents the standard value of the search option</param>
        /// <param name="us">String that represents the standard value of CultureInfo </param>
        public MySettings(string loginUrl, string userEmail, string userName, string password, string loginPageIndicatorXPath, string loginIndPhoneEmailUsernameXPath, string loginIndPhoneUsernameXPath, string userEmailCSS, string usernameCSS, string passwordCSS, string searchCSS, string latestCSS, string peopleCSS, string photosCSS, string videosCSS, string searchTweetsCSS, string searchAccountXPath, string searchTimeStampCSS, string searchTimeAttribute, string searchContent1XPath, string searchContent2XPath, string searchContent3XPath, string searchReplyCSS, string searchRetweetCSS, string searchLikeCSS, string searchUniqueIdCSS, string searchUniqueIdAttribute, string searchToGetStartedXPath, string searchOnlyUsernameCSS, string searchForButtonCSS, string searchForPasswordFieldCSS, int maxResults, string sortOption, string us)
        {
            LoginUrl = loginUrl;
            UserEmail = userEmail;
            UserName = userName;
            Password = password;
            LoginPageIndicatorXPath = loginPageIndicatorXPath;
            LoginIndPhoneEmailUsernameXPath = loginIndPhoneEmailUsernameXPath;
            LoginIndPhoneUsernameXPath = loginIndPhoneUsernameXPath;
            UserEmailCSS = userEmailCSS;
            UsernameCSS = usernameCSS;
            PasswordCSS = passwordCSS;
            SearchCSS = searchCSS;
            LatestCSS = latestCSS;
            PeopleCSS = peopleCSS;
            PhotosCSS = photosCSS;
            VideosCSS = videosCSS;
            SearchTweetsCSS = searchTweetsCSS;
            SearchAccountXPath = searchAccountXPath;
            SearchTimeStampCSS = searchTimeStampCSS;
            SearchTimeAttribute = searchTimeAttribute;
            SearchContent1XPath = searchContent1XPath;
            SearchContent2XPath = searchContent2XPath;
            SearchContent3XPath = searchContent3XPath;
            SearchReplyCSS = searchReplyCSS;
            SearchRetweetCSS = searchRetweetCSS;
            SearchLikeCSS = searchLikeCSS;
            SearchUniqueIdCSS = searchUniqueIdCSS;
            SearchUniqueIdAttribute = searchUniqueIdAttribute;
            SearchToGetStartedXPath = searchToGetStartedXPath;
            SearchOnlyUsernameCSS = searchOnlyUsernameCSS;
            SearchForButtonCSS = searchForButtonCSS;
            SearchForPasswordFieldCSS = searchForPasswordFieldCSS;
            MaxResults = maxResults;
            SortOption = sortOption;
            Us = us;
        }
        public MySettings() { }
        public string LoginUrl { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LoginPageIndicatorXPath { get; set; }
        public string LoginIndPhoneEmailUsernameXPath { get; set; }
        public string LoginIndPhoneUsernameXPath { get; set; }
        public string UserEmailCSS { get; set; }
        public string UsernameCSS { get; set; }
        public string PasswordCSS { get; set; }
        public string SearchCSS { get; set; }
        public string LatestCSS { get; set; }
        public string PeopleCSS { get; set; }
        public string PhotosCSS { get; set; }
        public string VideosCSS { get; set; }
        public string SearchTweetsCSS { get; set; }
        public string SearchAccountXPath { get; set; }
        public string SearchTimeStampCSS { get; set; }
        public string SearchTimeAttribute { get; set; }
        public string SearchContent1XPath { get; set; }
        public string SearchContent2XPath { get; set; }
        public string SearchContent3XPath { get; set; }
        public string SearchReplyCSS { get; set; }
        public string SearchRetweetCSS { get; set; }
        public string SearchLikeCSS { get; set; }
        public string SearchUniqueIdCSS { get; set; }
        public string SearchUniqueIdAttribute { get; set; }
        public string SearchToGetStartedXPath { get; set; }
        public string SearchOnlyUsernameCSS { get; set; }
        public string SearchForButtonCSS { get; set; }
        public string SearchForPasswordFieldCSS { get; set; }
        public int MaxResults { get; set; }
        public string SortOption { get; set; }
        public string Us { get; set; }
    }
}
