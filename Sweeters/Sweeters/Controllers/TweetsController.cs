using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sweeters.Operations;
using Sweeters.Services;

namespace Sweeters.Controllers
{
    [ApiController]
    [Route("api")]
    public class TweetsController : ControllerBase
    {
        private readonly MySettings _mySettings;
        private readonly Search _search = Search.GetSearch();

        public TweetsController(IOptions<MySettings> mySettingsOptions)
        {
            _mySettings = mySettingsOptions.Value;
        }

        // GET api/<TweetsController>/5
        [HttpGet("{inputString}")]
        public ActionResult Get(string inputString)
        {
            // New instance of MySettings witch contains the setup data from appsettings.json
            MySettings set = new(_mySettings.LoginUrl, _mySettings.UserEmail, _mySettings.UserName, _mySettings.Password, _mySettings.LoginPageIndicatorXPath, _mySettings.LoginIndPhoneEmailUsernameXPath, _mySettings.LoginIndPhoneUsernameXPath, _mySettings.UserEmailCSS, _mySettings.UsernameCSS, _mySettings.PasswordCSS, _mySettings.SearchCSS, _mySettings.LatestCSS, _mySettings.PeopleCSS, _mySettings.PhotosCSS, _mySettings.VideosCSS, _mySettings.SearchTweetsCSS, _mySettings.SearchAccountXPath, _mySettings.SearchTimeStampCSS, _mySettings.SearchTimeAttribute, _mySettings.SearchContent1XPath, _mySettings.SearchContent2XPath, _mySettings.SearchContent3XPath, _mySettings.SearchReplyCSS, _mySettings.SearchRetweetCSS, _mySettings.SearchLikeCSS, _mySettings.SearchUniqueIdCSS, _mySettings.SearchUniqueIdAttribute, _mySettings.SearchToGetStartedXPath, _mySettings.SearchOnlyUsernameCSS, _mySettings.SearchForButtonCSS, _mySettings.SearchForPasswordFieldCSS, _mySettings.MaxResults, _mySettings.SortOption, _mySettings.Us);

            if (string.IsNullOrEmpty(inputString))
            {
                return BadRequest("The input string is null or empty.");
            }

            (var Tweets, string message) = _search.ExtractTweeter(set, inputString);

            if (Tweets.Count == 0)
            {
                if (inputString.Equals("cmd:initialyze") || inputString.Equals("cmd:finalyze"))
                {
                    return Ok(message);
                }
                else
                {
                    return NotFound(message);
                }
            }
            return new JsonResult(Tweets);
        }
    }
}
