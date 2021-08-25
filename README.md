
<p>
<img src="https://image.flaticon.com/icons/png/512/1523/1523660.png" height="150" witdth="175" alt="Sweeters"/>
<img src="SweetersBanner.gif"><br>
<h1>Search Twitter and receive structured representation of the search results!</h1>
</p>

# Sweeters

## API DOCUMENTATION (Preview) Version 0.5 21-08-20

### [**Important note: Please, read this to initialize Sweeters!**](#how-to-initialize-sweeters) 

## Title

Searching a way to optimize the scrap data of TWitter? Use **Sweeters**...

This Application Programming Interface intends to consume the <ins>advanced search</ins> facility in the Twitter site.
Retuning structured data.

## To use **Sweeters** API

To use **Sweeters**, go to << To be Defined >> URL and input your search string according with the orientations listed below in this documentation.

[Go Straight to Fast Start](#fast-start)

## Status of Project
🚧 This project is under development. 🚧

# Table of Contents


* [Title](#title)  
* [Twitter Search Fields](#twitter-search-fields)
 * [To Search by All These Words](#to-search-by-all-these-words)
 * [To Search by This Exact Phrase](#to-search-by-this-exact-phrase)
 * [To Search by Any of These Words](#to-search-by-any-of-these-words)
 * [To Search by hashtags](#to-search-by-hashtags)
* [Filters](#filters)
 * [To Filter using None of These Words](#to-filter-using-none-of-these-words)
 * [Account filter](#account-filter)
 * [Language Filter](#language-filter)
 * [Replies](#replies)
 * [Links](#links)
 * [Engagements](#engagements)
 * [Times](#times)
 * [Sorts](#sorts)
 * [Maximum number of tweets in the result](#maximum-number-of-tweets-in-the-result)
* [Fast Start](#fast-start)
* [The Functioning of API](#the-functioning-of-api)
 *[]
* [Results](#results)
* [Tests](#tests)
* [Things to be done](#things-to-be-done)
* [Used Technologies](#used-technologies)
* [Credits](#credits)

## Twitter Search Fields

The <ins>advanced search</ins> has up to 20 fields or chooses available to use. This API, after receiving the users options,  will insert it in the twitter's search box.

After that, this API will scrap the Twitter's page content, searching for the tweets data, and parse the information in a structured grid and return in a Json format.

Sweeters don't manipulate the data extracted. Only the Tweet's numbers of engagements are converted in integers. The content data extracted by Sweeters contains only text and isn't manipulated. The raw data is returned.

The users must insert data in API by the GET verb, using the instructions listed below.

**VERY IMPORTANT:
The quality of the results depends only from the quality of your input string.**

In this documentation, search string means the data input by the user in the GET field.

[Return](#table-of-contents)

## To Search by All These Words

You can tell the search machine that you want that all the words included in a list exist in the result.

Examples:
    If you insert the word `SpaceX` - This word must be present in the result tweets; and
    If you insert two or more words, like `SpaceX Splashdown` - all of them should exist in the result.

### In this API

If you want to make a search including one or more words and want that all of them in the results, insert the intended words directly into the GET string, without any punctuations.

Examples:
    `SpaceX` or `SpaceX Splashdown` or `Moon rocket Sky`

**Important: Remember that you should **not** use the apostrophes or any punctuation before or after these words.
You should use only the punctuation mentioned in this documentation.**

Sweeters will insert your the search string in the right field in the tweet's search page.

[Return](#table-of-contents)

## To Search by "This Exact Phrase"

You can tell the search machine that you want that **all** the words included in a phrase **must** exist in the result list in the **correct sequence**. In other words. The search will be by phrase.

Example:
    If you insert the phrase `SpaceX splashed down in the Gulf of Mexico` - This phrase must be present in the result tweets.

### In this API

If you want to make a search by entire phrase, insert the intended phrase **between "quotation marks"**.

Examples:
    `"SpaceX splashed in the Gulf"` or `"Moon light"`

Note - You can put your search phrase into the same GET input, case you have intentions of search by words also.

Example:
    GET - `SpaceX Splashdown "Moon light"`
In this example, the tweet will search by the `SpaceX` and `Splashdown` words and by the phrase `"Moon Light"`.

[Return](#table-of-contents)

## To Search by Any of These Words

Your can tell the search machine that you want that at least one of a list of words will be present in the result tweets.

Example:
    If you insert the words `SpaceX splashdown` - The tweets in the result must have the word `SpaceX` **OR** the word `Splashdown`, or both of them.

### In this API

If you want to make a search by any one word in a list of words, insert the intended words between parentheses `(` `)` and put the operator ` OR ` between the words.

Examples:
    `(SpaceX OR splash OR Gulf)` or `(new OR age)`

Note 1 - The Tweeter's search machine is case sensitive, hence `OR` is different from `or`. So `or` will not function.

Note 2 - You can include this search with the others by putting your words into the same GET input.

Example:
    GET - `SpaceX Splashdown "Moon light" (space OR splash OR Gulf)`

In this example, the tweet will search by the SpaceX and Splashdown words, by the phrase "Moon Light" and by any of the words `space`, `splash` and `Gulf`.

[Return](#table-of-contents)

## To Filter using None of These Words

You can tell the search machine that you want that no word of a list of words will be present in the result tweets.

### In this API

If you want to make a search that exclude the tweets that have some words in the given list of words, insert the intended words directly into the GET, with a minus signal `-` before each word.

Examples:
    `-star` or `-Moon -Sun`

Note - You can include this search with the others by putting your words into the same GET input.

Example:
    GET - `SpaceX Splashdown "Moon light" (space OR splash OR Gulf) -Moon -Sun`

In this example, the tweet will search by the `SpaceX` and `Splashdown` words, by the phrase `"Moon Light"` and by any of the words `space`, `splash` and `Gulf` and will filter eliminating all tweets that contains the words `Moon` and `Sun`.

[Return](#table-of-contents)

## To Search by hashtags

You can tell the search machine that you want to include one or more hashtags int the search. The same as int subitem 3.3, but with the `#`, hashtag, before each word.

Note that the result tweets will have at least one of the hashtag. If you want that the result tweets have all the hashtags, input them in all these words box.

### In this API

If you want to make a search by any hashtag in a list of hashtags, you can put them between parentheses `(` `)` and put the operator ` OR ` between the words. The tweets in the result will have at least one of them.

Examples:
    `(#nasa)` or `(#nasa OR #sky)`

Note - You can include this search with the others by putting your words into the same GET input.

Example:
        GET - `SpaceX Splashdown "Moon light" (space OR splash OR Gulf) -Moon -Sun (#nasa OR #sky)`

In this example, the tweet will search by the `SpaceX` and `Splashdown` words, by the phrase `"Moon Light"`, by any of the words `space` `splash` and `Gulf`, by any of the hashtags `#nasa` or `#sky` and will filter eliminating all tweets that contains the words `Moon` and `Sun`.

[Return](#table-of-contents)

## Language filter

You can filter the results by language. You can choose one language from this dropdown list.

Note: This list of languages is valid today (2021-08-20). If your query returns null, please check if its still valid in Twitters documentation.

|Languages available:         |                   |                           |                |
|:----------------------------|:------------------|:--------------------------|:---------------|
|"ar" Arabic                  | "de" German       | "fa" Persian              | "tr" Turkish   |
|"ar-x-fm" Arabic (Feminine)  | "el" Greek        | "pl" Polish               | "uk" Ukrainian |
|"bn" Bangla                  | "gu" Gujarati     | "pt" Portuguese           | "ur" Urdu      |
|"eu" Basque                  | "he" Hebrew       | "ro" Romanian             | "vi" Vietnamese|
|"bg" Bulgarian               | "hi" Hindi        | "ru" Russian
|"ca" Catalan                 | "hu" Hungarian    | "sr" Serbian
|"hr" Croatian                | "id" Indonesian   | "zh-cn" Simplified Chinese
|"cs" Czech                   | "it" Italian      | "sk" Slovak
|"da" Danish                  | "ja" Japanese     | "es" Spanish
|"nl" Dutch                   | "kn" Kannada      | "sv" Swedish
|"en" English                 | "ko" Korean       | "ta" Tamil
|"fi" Finnish                 | "mr" Marathi      | "th" Thai
|"fr" French                  | "no" Norwegian    | "zh-tw" Traditional Chinese

There is no need to choose one language, since the default is to display all the results, in any language. In this case, the language will not influence the results. If you want to choose a specific language, you can pick one of the languages listed above.

### In this API

To choose the language, input the two-letters code (Note: In fact, some codes have more than two letters) after the reserved word `lang:`. Remember not to use apostrophes.

Example:
    `lang:pt`

Note - You can include this search filter with the an search by putting language option into the same GET input.

Example:
    GET  - `SpaceX Splashdown "Moon light" (space OR splash OR Gulf) -Moon -Sun (#nasa OR #sky) lang:pt`

In this example, the tweet will search by the `SpaceX` and `Splashdown` words, by the phrase `"Moon Light"`, by any of the words `space` `splash` and `Gulf`, by any of the hashtags mentioned and will filter eliminating all tweets that contains the words `Moon` and `Sun`. And the machine will show only the tweets written in portuguese .

Important: Remember that you should **not** use the apostrophes or any punctuation before or after these words.
You should use only the punctuation mentioned in this documentation.

[Return](#table-of-contents)

## Account filter

You can filter your search by account, in three different search options:

* From these accounts `(from:@account)`;
* To these accounts `(to:@account)`; or
* Mentioning these accounts`(@account)`.

To specify the accounts, the user may put or not the `@` particle before de account name.It returns the same results.

### In this API

Using the account search options you can include accounts in the search:

* tweets from one or more listed accounts(use the reserved word `from:` before each account name and use ` OR ` between the accounts, like the examples below); or
* tweets sent in reply to one or more listed accounts (use the reserved word `to:` before each account name and use ` OR ` between the accounts, like the examples below); or
* tweets that mentions one or more of the listed accounts (use ` OR ` between the accounts, like the examples below).

Important:

1. Note that, inside an option, like `from:`, an account list will be used to filter the results by **any** one of the included account list, using the logic operator **OR**. The same occurs with the others options.
2. But using more than one option, like `from:` and `to:`. The search functions like an **AND** operator, limiting greatly the search.

Examples:

`(to:John)` -> To account ...
`(from:@martins12574 OR from:@rezende6584)` -> from accounts ...
`(martins12574 OR rezende6584)` -> mentioning the accounts ...
`(to:John) (rezende6584)` -> to account ... and mentioning the account ...

Note -> You can include this search with the others by putting your words into the same GET input.

Example:
        GET  -> `SpaceX Splashdown "Moon light" (space OR splash OR Gulf) -Moon -Sun (#nasa OR #sky)(from:John)`

In this example, the tweet will search by the `SpaceX` and `Splashdown` words, by the phrase `"Moon Light"`, by any of the words `space` `splash` and `Gulf`, by any of the hashtags mentioned and will filter eliminating all tweets that contains the words `Moon` and `Sun`. The machine will show only the tweets from account `John`.

[Return](#table-of-contents)

## Filters

The result list of tweets can be filtered by the presence or absence of replies and links, as follows.
Note: All these filters can be put directly in the GET string among the others search options

[Return](#table-of-contents)

## Replies

In normal situation, the result will show all tweets that match with the given search criteria. But you can filter the results by choosing if the tweets replied should be removed from the list. Or if the list should be composed only by retweeted tweets.

### In this API

* Use the expression `-filter:replies` if you want that the tweets replied should be removed from result. or
* Use the expression `filter:replies` if you want that the result should be composed only by retweeted tweets.

The default filter is not to exclude from result replies nor original ones.

Note - You can include this filter with the others by putting the expression into the same GET input.

Example:
    GET  -> `SpaceX Splashdown "Moon light" (space OR splash OR Gulf) -Moon -Sun (#nasa OR #sky)(from:John) -filter:replies`

In this example, the tweet will search by the `SpaceX` and  `Splashdown` words, by the phrase  `"Moon Light"`,  by  any  of  the  words  `space` `splash` and `Gulf`, by any  of  the  hashtags  mentioned  and  will filter eliminating all tweets that contains the words `Moon` and `Sun`. The machine will show only the tweets from account `John`. In this list should not contain any `retweet`.

Important: Remember that you should **not** use the apostrophes or any punctuation before or after these words.
    You should use only the punctuation mentioned in this documentation.

[Return](#table-of-contents)

## Links

In normal situation, the result will show all tweets that match with the given search criteria. But you can filter the results by choosing if the tweets with link(s) should be removed from the list. Or if the list should be composed only by tweets with link(s).

### In this API

* Use the expression `-filter:links` if you want that the tweets with link(s) should be removed from the result. or
* Use the expression `filter:links` if you want that the result should be composed only by tweets with link(s).

The default filter is not to exclude from result tweets with links.

Note -> You can include this filter with the others by putting the expression into the same GET input.
Important: Remember that you should **not** use the apostrophes or any punctuation before or after these words.
    You should use only the punctuation mentioned in this documentation.

[Return](#table-of-contents)

## Engagements

You can stablish filters of engagement that will permit to filter tweets with low profile of engagement.
In this matter, you can filter the tweets by minimum number of replies, likes or retweets.

### In this API

* Use the expression `min_replies:` followed by an **integer** value to filter by a minimum number of replies, you should insert this filter if you want to be shown only tweets with more replies then the limit number inserted. Insert directly in GET input, with the other search options.

* Use the expression `min_faves:` followed by an **integer** value to filter by a minimum number of likes, you should insert this filter if you want to be shown only tweets with more likes then the limit number inserted. Insert directly in GET input, with the other search options.

* Use the expression `min_retweets:` followed by an **integer** value to filter by a minimum number of retweets, you should insert this filter if you want to be shown only tweets with more retweets then the limit number inserted. Insert directly in GET input, with the other search options.

Examples:
        `min_replies:10` and/or `min_faves:20` and/or `min_retweets:30`

Note -> You can include this filter with the others by putting the expression into the same GET input.
Important: Remember that you should **not** use the apostrophes or any punctuation before or after these words.
    You should use only the punctuation mentioned in this documentation.

[Return](#table-of-contents)

## Times

### In this API

If you want that the search machine shows only the tweets older than a specific date, you may use this filter, using the reserved word `until:` and the date value in the right format `yyyy-MM-dd`.
If you want that the search machine shows only the tweets newer than a specific date, you may use this filter, using the reserved word `since:` and the date value in the right format `yyyy-MM-dd`.

Examples:

* Insert `until:2020-12-31` - to receive only tweets published before this date.

* Insert `since:2021-01-01` - to receive only tweets published after this date.

Note -> You can include this filter with the others by putting the expression into the same GET input.
Important: Remember that you should **not** use the apostrophes or any punctuation before or after these words.
    You should use only the punctuation mentioned in this documentation.

[Return](#table-of-contents)

## Maximum number of tweets in the result

### In this API

You can input into the search string the max number of results, witch determines the maximum number of tweets in the return list.

This API will try to extract, at least, this number of tweets.

You can input this number by using the expression `maxresults:`.

For example:

* Insert `maxresults:100` - to receive a maximum of 100 tweets in the result.

Note -> You can include this option with the others by putting the expression into the same GET input.
Important: Remember that you should **not** use the apostrophes or any punctuation before or after these words and numbers other than what is presented in this documentation.

[Return](#table-of-contents)

## Sorts

The tweeter search machine has five options to sort the result: Top, Latest, People, Photos and Videos

**Top** - Choosing this option, the Twitters search machine will apply an algorithm that intends to show tweets you are likely to care about most first. Twitter believes that this option will show the most relevant tweets for the search.  This algorithm is automatic and not manually curated.

**Latest** - Choosing this option, the Tweets search machine will show the latest tweets first and then, descending until the oldest tweet that matches the search

**People** - Choosing this option, the search machine will, sort the result by account (inactive). [See important note below](#important-note)

**Photos** - Choosing this option, the search machine will, sort the result by photos.

**Videos** - Choosing this option, the search machine will, sort the result by videos.

The `Top` option is the default, if no option is inputted. So, there is no need to input this option.

More information about these sort  algorithms and criteria, please see the Twitter documentation and Help Center in <https://help.twitter.com/en>.

### In this API

Use the reserved word `sort:` followed by your option.

### Important note:
The sort option was inactivated because the results are a list of users/accounts and there is no data of interest to this project. 

Examples:

* Insert `sort:latest` - to sort Chronologically, descending algorithm.
* Insert `sort:people` - to sort by People/Account algorithm <inactive.>.
* Insert `sort:photos` - to sort by Photos algorithm.
* Insert `sort:videos` - to sort by Videos algorithm.

[Return](#table-of-contents)

# Fast Start

|**What you Want**                          | **What you should input String**                                  
|:--------------------------------------|:------------------------------------------|
|**Search by all these words:** [(see more here)](#to-search-by-all-these-words)             |                                           |
|word1, word2, word3                    | word1 word2 word3                         |
|dog, cat, pet                          | dog cat pet                               |
|||
|**Search by this exact phrase:** [(see more here)](#to-search-by-this-exact-phrase)          |                                           |
|I want to search by this phrase.       | "I want to search by this phrase."        |
|||
|**Search by an expression:** [(see more here)](#to-search-by-this-exact-phrase)              |                                           |
|Coca Cola |"Coca Cola"|
|Elon Musk|"Elon Musk"|
|||
|**Search by any of these words:** [(see more here)](#to-search-by-any-of-these-words)||
|Olympics, gold, silver, bronze, medal |(Olympics OR gold OR silver OR bronze OR medal)|
|||
|**If you want to make a search but filter some word:** [(see more here)](#to-filter-using-none-of-these-words)||
|Europe but not mentioning Portugal|Europe -Portugal|
|Formula One, F#1, F1 but not mentioning Ayrton Senna|"Formula One" (F#1 OR F1) -Ayrton -Senna|
|||
|**Search by Hashtags:** [(see more here)](#to-search-by-hashtags)||
|Is the same as above, but with the # before the tags||
|#nasa #space #moon but not mentioning #SpaceX and Elon Musk|(#nasa OR #space OR #moon) -#SpaceX -#Elon -#Musk|
|||
|**Language:** [(see more here)](#language-filter)||
|Use language filter if you desire only one specific language to appear in the results||
|only tweets in portuguese| lang:pt|
|only tweets in english| lang:en|
|only tweets in japanese| lang:jp|
|See the available languages [here](#language-filter)||
|||
|**Search by Accounts:** [(see more here)](#account-filter)||
|This is a search and a filter||
|Starship tweets from Elon Musk| Starship (from:@elonmusk)|
|from someone (sent from)|(from:@someone)|
|to someone (sent in reply to someone)|(to:@someone)|
|mentioning someone|(@someone)|
|If more than one, put " OR "| (from:@John OR from:@Mary)|
|||
|**Filters:** ||
|Replies: [(see more here)](#replies)||
|**remove** the tweets replied| -filter:replies|
|**only** by retweeted tweets.| filter:replies|
|||
|Links: [(see more here)](#links)||
|**remove** tweets with link(s)| -filter:links|
|**only** tweets with link(s).| filter:links|
|||
|**Engagements:** [(see more here)](#engagements)||
|minimum of 100 replies|min_replies:100|
|minimum of 15000 replies|min_replies:15000|
|||
|minimum of 250 likes or faves|min_faves:250|
|||
|minimum of 50 retweets|min_retweets:100|
|||
|**Times:** [(see more here)](#times)||
|Only before 2021-01-01| until:2021-01-01|
|Only after 2019-08-31| since:2019-08-31|
|Starship after 2018-07-25 and before 2021-08-11|Starship until:2021-08-11 since:2018-07-25|
|**Results** [(see more here)](#maximum-number-of-tweets-in-the-result)||
|Want 50 tweets|maxresults:50|
|Want 150 tweets|maxresults:150|
|The results is a maximum number because that it depends on the search data you input||

[Return](#table-of-contents)

## The Functioning of API

### How to Initialize Sweeters

To put into service, Sweeters need to be initialized. After command run, the first string to be put in the url is:

`https://localhost:44344/api/cmd:initialyze`.

Doing this you are commanding Sweeters to call the Twitters home page and log in.
If it returns a **"Login done!"** message, the Sweeters is ready to scrap.

Before to put down the Sweeters, insert:

`https://localhost:44344/api/cmd:finalyze`.

This will log out the Twitter, close the window and quit all drivers. Receiving the **Logout done!** message, Sweeters is ready to be shut down.

## Constants in appsettings.json

`"LoginUrl": "https://www.twitter.com/login"`, the actual url of the Twitter login page;

`"UserEmail": "mytesting832@gmail.com"`, the Email used to login in the Twitter page;

`"UserName": "MyTestingAcc832"`, the username used to login;

`"Password": "173205080"`, the password used to login;

`"LoginPageIndicatorXPath": "//div[text()=\"Please verify your account\"]"`, the XPath of the text that indicates the "Log in to" alternative login page;

`"LoginIndPhoneEmailUsernameXPath": "//span[text()=\"Phone, email, or username\"]"`, the XPath of the email or username field in login page;

`"LoginIndPhoneUsernameXPath": "//span[text()=\"Phone or username\"]"`, the XPath of the username field in login page;

`"UserEmailCSS": "input[name=\"session[username_or_email]\"]"`, the CSS selector for the email field in login page;

`"UsernameCSS": "input[name=\"session[username_or_email]\"]"`, the CSS selector for the username field in login page;

`"PasswordCSS": "input[name=\"session[password]\"]"`, the CSS selector for the password field in login page;

`"SearchCSS": "input[data-testid=\"SearchBox_Search_Input\"]"`, the CSS selector for the search field of Twitter;

`"LatestCSS": "a[href$=\"&f=live\"]"`, the Css selector for the Latest button in the Twitter page;

`"PeopleCSS": "a[href$=\"&f=user\"]"`, the Css selector for the People button in the Twitter page;

`"PhotosCSS": "a[href$=\"&f=image\"]"`, the Css selector for the Photo button in the Twitter page;

`"VideosCSS": "a[href$=\"&f=video\"]"`, the Css selector for the Videos button in the Twitter page;

`"SearchTweetsCSS": "div[data-testid=\"tweet\"]"`, the CSS selector that indicates the tweets in the Twitter page;

`"SearchAccountXPath": ".//span[contains(text(),\"@\")]"`, the XPath of the account data in the tweets;

`"SearchTimeStampCSS": "time"`, the CSS selector for the element containing the timestamp;

`"SearchTimeAttribute": "datetime"`, the attribute which value contains the timestamp;

`"SearchContent1XPath": ".//div[2]/div[2]/div[1]"`, the XPath of the first content data element;

`"SearchContent2XPath": ".//div[2]/div[2]/div[2]"`, the XPath of the second content data element;

`"SearchContent3XPath": ".//div[2]/div[2]/div[3]"`, the XPath of the third content data element;

`"SearchReplyCSS": "div[data-testid=\"reply\"]"`, the CSS selector for the element containing the reply quantity;

`"SearchRetweetCSS": "div[data-testid=\"retweet\"]"`, the CSS selector for the element containing the retweet quantity;

`"SearchLikeCSS": "div[data-testid=\"like\"]"`, the CSS selector for the element containing the like quantity;

`"SearchUniqueIdCSS": "a[href*=\"/status/\"]"`, the CSS selector for the element containing the UniqueId of the tweet;

`"SearchUniqueIdAttribute": "href"`, the attribute which value contains the UniqueId;

`"SearchToGetStartedXPath": "//span[contains(text(),\"To get started\")]"`, The XPath of the "To get Started" alternative page of Login;

`"SearchOnlyUsernameCSS": "input[name=\"username\"]"`, CSS selector for the username field in "To get Started" login page;

`"SearchForButtonCSS": "div[role =\"button\"]"`, CSS selector for the buttons in login pages;

`"SearchForPasswordFieldCSS": "input[name=\"password\"]"`, CSS selector for the password field in login page;
`"MaxResults": 10`, default value of maximum quantity of tweets to scrap;

`"SortOption": "Top"`, default value of the sort option; and

`"Us": "en-US"`, the default value for the Culture info (Globalization).

## Requirements

Initially, the unique requirement is to maintain the window opened by the driver opened and maximized. The Twitter page is dynamic and is possible that the CSS selector or the XPath fail due the respective absence in the window.

## Functioning

The API runs in the Server and upon receiving the GET request, the Controller checks the input string for null or empty, returning `BadRequest()` in this case.

If OK, Controller calls the `ExtractTweeter()` Method in the Search Class.

To make a search, a login must be done. So the `ExtractTweeter()` Method calls the `DoLogin` Method that will perform the duties. The API can pass through up to three alternative login pages from the Tweeter bot protection.
But, if the login fails, the API will return a blanc result to the Controller. The Controller than return to user.

The `ExtractTweeter()` Method analyses the search input by the `MaxResultIdentifier()` and `SortIdentifier()` methods that will respectively extract the maximum result quantity and sort option, if any, and will remove the substrings about these matters.

The ChromeDriver.exe file is included between the API files.

The ChromeDriver maximize the Chrome window and goes to Url of the login page.
The URL of the Twitter login page must be set int the respective variable in appsettings.json.

Login done, the `ExtractTweeter()` inserts the searchString into the search field of the Twitter page, waits about 5 seconds and search for the Tweets in the page.This search returns a List of raw Tweets.
Names involved:

tweets - list of raw Tweets extracted from Twitters page;
twit - each raw Tweets from the tweets list;

Tweets - list of Tweet(class) instances;
twt - an instance of Tweet class;

By a foreach, the aimed properties are extracted. Each twit, is then compared with the twt in Tweet, by the UniqId property. If the twit is anew one, this twit is added to the Tweets list. And an counter is incremented to control the amount of twts.

After the end of the foreach, inf the counter isn't enough, a scroll page is executed and a goto throw back to a new search for the Tweets in the page.  The API will try scroll three times after the last new twit. Then will return the List Tweets acquired to controller. Then the Controller return the List by a `JsonResult`.

[Return](#table-of-contents)

## Results

The API returns the List of Tweets extracted from the Twitter page by a `JsonResult`.

    [
        ...
        {
            "uniqueId": <unique tweet id>,

            "content": <tweet content>,

            "timestamp": <date and time of the tweet>,

            "account": <account that posted the tweet>,

            "replies": <amounts of replies>,

            "retweets": <amount of retweets>,

            "likes": <amount of likes>
        },
        {
            "uniqueId": "SpaceX/status/1413702720230285314",

            "content": "Splashdown of Dragon confirmed, completing SpaceX’s 22nd cargo resupply mission to the @space_station!",

            "timestamp": "2021-07-10T03:32:48.000Z",

            "account": "SpaceX",

            "replies": 294,

            "retweets": 1200,
            
            "likes": 13900
        }
        ...
    ]

### Result Types

uniqueId -> string,

content -> string,

timestamp -> string,

account -> string,

replies -> int,

retweets -> int,

likes -> int.

[Return](#table-of-contents)

## Tests

This API was tested by two other codes:

### Sweeters Unit Tests

Almost all methods in the API code was tested and all passed. There are 64 unit tests.

The project **SweetersUnitTests**, based in XUnit tests all methods not dependent from the outside data.
This project is entirely inside the **solution**.

### API Behavior Tests

I built a console project to test the behavior of the API. By sending controlled search strings into the API Url and testing the returning data.

The project **APIBehaviorTest** sends 7 search strings using a `for` statement trying to simulate simultaneous requests. I received the task to do in 4 days but I coudnt find the bug that crash the functioning.

I couldn't manage to put this project inside the Sweeters without inserting bug into it. Lack of knowledge.

I didn't try to make a new repository for it because the restrictions. So I put it in the same repository of Sweeters.

## Things to be done: 
(At least...)

* **Sweeters** - Obviously, Sweeters needs Refactoring to make it more stable while submitted to multi requests.

* **UnitTestProject** - Needs to move the `DoLoginTest Class` settings to outside.
Probably using the same json?
Or same MySettings from Sweeters?
Needs also to make changes to the tests to make them more elegant ones.

* **APIBehaviorTest** - Needs to be analysed by a more experienced developer to identify the errors and the wrong concepts.

[Return](#table-of-contents)

## Used Technologies

.NET 5

C#9

OpenQA.Selenium

OpenQA.Selenium.Chrome

XUnit

[Return](#table-of-contents)

## Credits

To produce these codes I used the knowledge acquired in courses and in internet videos, tutorials, blogs and documentations.

Several courses in Balta.io - https://balta.io/

Macoratti - http://www.macoratti.net/

*Seja um Data Scientist* - https://sejaumdatascientist.com/

Several courses in Udemy - https://www.udemy.com/

Data Modeling - *Bóson Treinamentos* - http://www.bosontreinamentos.com.br/

Selenium - www.selenium.dev

Stack Overflow - stackoverflow.com

Microsoft - docs.microsoft.com

NewtonSoft - www.newtonsoft.com

Blog - https://qastack.com.br/

And many other places. couldn't nominate one by one.

Sweeters Icon obtained in <a href="https://www.freepik.com" title="Freepik">Freepik</a> from <a href="https://www.flaticon.com/br/" title="Flaticon">www.flaticon.com</a>

Twitter Scraper Python Tutorial by: Izzy Analytics <a href="https://www.youtube.com/channel/UCWHJGQc7Vqo37dlUmpiK6hQ"> (watch the video here)</a>

[Return](#table-of-contents)

<p align="center" >Luis Martins <br>-- <b>The End</b> --</p>