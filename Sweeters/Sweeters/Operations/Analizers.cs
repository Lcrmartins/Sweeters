using System;
using System.Text;

namespace WebTweetScraping.Operations
{
    public class Analyze
    {
        public (StringBuilder, string) AnalyzeAllTheseWords(StringBuilder searchString, string input)
        {
            switch (input.Length)
            {
                case > 0:
                    {
                        if (input.StartsWith('\''))
                        {
                            int count = input.IndexOf('\'', 1);
                            string words = input[1..count];
                            words = Uri.EscapeUriString(words);
                            input = input.Remove(0, count + 1).Trim();
                            searchString.Append(words)
                                        .Append("%20");
                        }
                        else
                        {
                            int count = input.IndexOf("all:", 0, StringComparison.OrdinalIgnoreCase);
                            if (count != -1)
                            {
                                int start = count + 5;
                                int end = input.IndexOf('\'', start);
                                string words = input[start..end];
                                words = Uri.EscapeUriString(words);
                                input = input.Remove(count, end - count + 1).Trim();
                                searchString.Append(words)
                                            .Append("%20");
                            }
                        }
                        return (searchString, input);
                    }
                default:
                    return (searchString, input);
            }
        }
        public (StringBuilder, string) AnalyzePhrase(StringBuilder searchString, string input)
        {
            switch (input.Length)
            {
                case > 0:
                    {
                        if (input.StartsWith("\""))
                        {
                            int count = input.IndexOf("\"", 1);
                            string words = "\"";
                            words += input[1..count];
                            words = words.Insert(words.Length, "\"");
                            words = Uri.EscapeUriString(words);
                            input = input.Remove(0, count + 1).Trim();
                            searchString.Append(words)
                                        .Append("%20");
                            return (searchString, input);
                        }
                        else
                        {
                            int count = input.IndexOf("phrase:", 0, StringComparison.OrdinalIgnoreCase);
                            if (count != -1)
                            {
                                int start = count + 8;
                                int end = input.IndexOf('\"', start);
                                string words = input[start..end];
                                words = words.Insert(0, "\"");
                                words = words.Insert(words.Length, "\"");
                                words = Uri.EscapeUriString(words);
                                input = input.Remove(count, end - count + 1).Trim();
                                searchString.Append(words)
                                            .Append("%20");
                                return (searchString, input);
                            }
                        }
                        return (searchString, input);
                    }
                default:
                    return (searchString, input);
            }
        }
        public (StringBuilder, string) AnalyzeAnyOfTheseWords(StringBuilder searchString, string input)
        {
            switch (input.Length)
            {
                case > 0:
                    {
                        if (input.StartsWith('('))
                        {
                            int count = input.IndexOf(')', 1);
                            string words = input[1..count];
                            words = words.Replace(" ", " OR ");
                            words = Uri.EscapeDataString(words);
                            searchString.Append('(')
                                        .Append(words)
                                        .Append(')')
                                        .Append("%20");
                            input = input.Remove(0, count + 1).Trim();
                        }
                        else
                        {
                            int count = input.IndexOf("any:", 0, StringComparison.OrdinalIgnoreCase);
                            if (count != -1)
                            {
                                int start = count + 5;
                                int end = input.IndexOf('\'', start);
                                string words = input[start..end];
                                words = words.Replace(" ", " OR ");
                                words = Uri.EscapeDataString(words);
                                words = words.Insert(0, "(");
                                words = words.Insert(words.Length, ")");
                                input = input.Remove(count, end - count + 1).Trim();

                                searchString.Append(words)
                                            .Append("%20");
                            }
                        }
                        return (searchString, input);
                    }
                default:
                    return (searchString, input);
            }
        }
        public (StringBuilder, string) AnalyzeNoneOfTheseWords(StringBuilder searchString, string input)
        {
            switch (input.Length)
            {
                case > 0:
                    {
                        int index = input.IndexOf("none:", 0, StringComparison.OrdinalIgnoreCase);

                        switch (index)
                        {
                            case -1:
                                break;
                            default:
                                {
                                    StringBuilder noneOfThese = new(100);
                                    int start = index + 6;
                                    int end = input.IndexOf('\'', start);
                                    string words = input[start..end];
                                    var wordList = words.Split(" ");
                                    for (int i = 0; i < wordList.Length; i++)
                                    {
                                        if (wordList[i] != "")
                                        {
                                            noneOfThese.Append('-')
                                                       .Append(wordList[i])
                                                       .Append("%20");
                                        }
                                    }
                                    input = input.Remove(index, end - index + 1).Trim();
                                    searchString.Append(noneOfThese);
                                    break;
                                }
                        }
                        input = input.Trim();
                        return (searchString, input);
                    }
                default:
                    return (searchString, input);
            }
        }
        public (StringBuilder, string) AnalyzeHashTags(StringBuilder searchString, string input)
        {
            switch (input.Length)
            {
                case > 0:
                    {
                        int index = input.IndexOf("tag:", 0, StringComparison.OrdinalIgnoreCase);

                        switch (index)
                        {
                            case -1:
                                break;
                            default:
                                {
                                    StringBuilder tagString = new(100);
                                    int start = index + 5;
                                    int end = input.IndexOf('\'', start);
                                    tagString.Append('(')
                                             .Append(input[start..end])
                                             .Append(')');
                                    tagString.Replace(" ", " OR ");
                                    input = input.Remove(index, end - index + 1);
                                    input = input.Trim();
                                    searchString.Append(Uri.EscapeDataString(tagString
                                        .ToString())
                                        .Replace("%28", "(")
                                        .Replace("%29", ")"))
                                        .Append("%20");
                                    break;
                                }
                        }
                        return (searchString, input);
                    }
                default:
                    return (searchString, input);
            }
        }
        public (StringBuilder, string) AnalyzeLanguage(StringBuilder searchString, string input)
        {
            switch (input.Length)
            {
                case > 0:
                    {
                        int index = input.IndexOf("lang:", 0, StringComparison.OrdinalIgnoreCase);

                        switch (index)
                        {
                            case -1: break;
                            default:
                                {
                                    int start = index + 6;
                                    int end = input.IndexOf('\'', start);
                                    string lang = input[start..end];
                                    lang = lang.Trim();
                                    switch (lang)
                                    {
                                        case "ar-x-fm": lang = "arxfm"; break;
                                        case "zh-cn": lang = "zhcn"; break;
                                        case "zh-tw": lang = "zhtw"; break;
                                    }
                                    if (!Enum.IsDefined(typeof(Data.LanguageList), lang))
                                    {
                                        ArgumentException argumentException = new(
                                            "The language value does not exist int the options languages.",
                                            "lang");
                                        throw argumentException;
                                    }
                                    switch (lang)
                                    {
                                        case "arxfm": lang = "ar-x-fm"; break;
                                        case "zhcn": lang = "zh-cn"; break;
                                        case "zhtw": lang = "zh-tw"; break;
                                    }
                                    lang = "%20lang%3A" + lang;
                                    input = input.Remove(index, end - index + 1).Trim();
                                    searchString
                                        .Append(lang)
                                        .Append("%20");
                                    break;
                                }
                        }
                        return (searchString, input);
                    }
                default:
                    return (searchString, input);
            }
        }
        public (StringBuilder, string) AnalyzeFromAccounts(StringBuilder searchString, string input)
        {
            switch (input.Length)
            {
                case > 0:
                    {
                        int index = input.IndexOf("from:", 0, StringComparison.OrdinalIgnoreCase);
                        switch (index)
                        {
                            case >= 0:
                                {
                                    StringBuilder fromString = new(100);
                                    int start = index + 6;
                                    int end = input.IndexOf('\'', start);
                                    fromString.Append("(from:")
                                              .Append(input[start..end])
                                              .Append(')');
                                    fromString.Replace(" ", " OR from:");
                                    input = input.Remove(index, end - index + 1).Trim();
                                    searchString.Append(Uri.EscapeDataString(
                                        fromString
                                        .ToString()
                                        .Replace("%28", "(")
                                        .Replace("%29", ")")))
                                        .Append("%20");
                                    break;
                                }
                        }
                        return (searchString, input);
                    }
                default:
                    return (searchString, input);
            }
        }
        public (StringBuilder, string) AnalyzeToAccounts(StringBuilder searchString, string input)
        {
            switch (input.Length)
            {
                case > 0:
                    {
                        int index = input.IndexOf("to:", 0, StringComparison.OrdinalIgnoreCase);
                        switch (index)
                        {
                            case >= 0:
                                {
                                    StringBuilder toString = new(100);
                                    int start = index + 4;
                                    int end = input.IndexOf('\'', start);
                                    toString.Append("(to:")
                                             .Append(input[start..end])
                                             .Append(')');
                                    toString.Replace(" ", " OR to:");
                                    input = input.Remove(index, end - index + 1).Trim();
                                    searchString.Append(Uri.EscapeDataString(
                                        toString.ToString()
                                        .Replace("%28", "(")
                                        .Replace("%29", ")")))
                                        .Append("%20");
                                    break;
                                }
                        }
                        return (searchString, input);
                    }
                default:
                    return (searchString, input);
            }
        }
        public (StringBuilder, string) AnalyzeInfoAccounts(StringBuilder searchString, string input)
        {
            switch (input.Length)
            {
                case > 0:
                    {
                        int index = input.IndexOf("info:", 0, StringComparison.OrdinalIgnoreCase);
                        switch (index)
                        {
                            case >= 0:
                                {
                                    StringBuilder infoString = new(100);
                                    int start = index + 6;
                                    int end = input.IndexOf('\'', start);
                                    infoString.Append("(info:@")
                                             .Append(input[start..end])
                                             .Append(')');
                                    infoString.Replace(" ", " OR info:@");
                                    input = input.Remove(index, end - index + 1).Trim();
                                    searchString.Append(Uri.EscapeDataString(
                                        infoString.ToString()
                                        .Replace("%28", "(")
                                        .Replace("%29", ")")))
                                        .Append("%20");
                                    break;
                                }
                        }
                        return (searchString, input);
                    }
                default:
                    return (searchString, input);
            }
        }
        public (StringBuilder, string) AnalyzeReplies(StringBuilder searchString, string input)
        {
            switch (input.Length)
            {
                case > 0:
                    {
                        int index = input.IndexOf("noreply", 0, StringComparison.OrdinalIgnoreCase);

                        if (index != -1)
                        {
                            searchString.Append("-filter%3Areplies");
                            input = input.Remove(index, 7).Trim();
                            return (searchString, input);
                        }
                        else
                        {
                            index = input.IndexOf("repliesonly", 0, StringComparison.OrdinalIgnoreCase);

                            if (index != -1)
                            {
                                searchString
                                    .Append("filter%3Areplies")
                                    .Append("%20");
                                input = input.Remove(index, 11).Trim();
                                return (searchString, input);
                            }
                            else
                            {
                                return (searchString, input);
                            }
                        }
                    }
                default:
                    return (searchString, input);
            }
        }
        public (StringBuilder, string) AnalyzeLinks(StringBuilder searchString, string input)
        {
            switch (input.Length)
            {
                case > 0:
                    {
                        int index = input.IndexOf("nolinks", 0, StringComparison.OrdinalIgnoreCase);

                        if (index != -1)
                        {
                            searchString.Append("-filter%3Alinks");
                            input = input.Remove(index, 7).Trim();
                            return (searchString, input);
                        }
                        else
                        {
                            index = input.IndexOf("onlywithlink", 0, StringComparison.OrdinalIgnoreCase);

                            if (index != -1)
                            {
                                searchString.Append("filter%3Alinks");
                                input = input.Remove(index, 12).Trim();
                                return (searchString, input);
                            }
                            else
                            {
                                return (searchString, input);
                            }
                        }
                    }
                default:
                    return (searchString, input);
            }
        }
        public (StringBuilder, string) AnalyzeEngagements(StringBuilder searchString, string input)
        {
            switch (input.Length)
            {
                case > 0:
                    {
                        int count = input.IndexOf("min_replies:", 0, StringComparison.OrdinalIgnoreCase);

                        if (count != -1)
                        {
                            int start = count + 13;
                            int end = input.IndexOf('\'', start);
                            string numbers = input[start..end];
                            searchString.Append("min_replies%3A")
                                        .Append(numbers)
                                        .Append("%20");
                            input = input.Remove(count, end - count + 1).Trim();
                            return (searchString, input);
                        }
                        else
                        {
                            count = input.IndexOf("min_likes:", 0, StringComparison.OrdinalIgnoreCase);

                            if (count != -1)
                            {
                                int start = count + 11;
                                int end = input.IndexOf('\'', start);
                                string numbers = input[start..end];
                                searchString.Append("min_faves%3A")
                                            .Append(numbers)
                                            .Append("%20");
                                input = input.Remove(count, end - count + 1).Trim();
                                return (searchString, input);
                            }
                            else
                            {
                                count = input.IndexOf("min_retweets:", 0, StringComparison.OrdinalIgnoreCase);

                                if (count != -1)
                                {
                                    int start = count + 14;
                                    int end = input.IndexOf('\'', start);
                                    string numbers = input[start..end];
                                    searchString.Append("min_retweets%3A")
                                                .Append(numbers)
                                                .Append("%20");
                                    input = input.Remove(count, end - count + 1).Trim();
                                    return (searchString, input);
                                }
                                else
                                {
                                    return (searchString, input);
                                }
                            }
                        }
                    }
                default:
                    return (searchString, input);
            }
        }

        // Analizing tweets older than

        // Analizing tweets newer than

        // Analizing Maximum number of tweets in the result


    }
}
