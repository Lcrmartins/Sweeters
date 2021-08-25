namespace Sweeters.Entities
{
    public class Tweet
    {
        public Tweet() { }
        public Tweet(string account, string timeStamp, string content, int replies, int retweets, int likes, string uniqueId)
        {
            Account = account;
            TimeStamp = timeStamp;
            Content = content;
            Replies = replies;
            Retweets = retweets;
            Likes = likes;
            UniqueId = uniqueId;
        }
        public string UniqueId { get; set; }
        public string Content { get; set; }
        public string TimeStamp { get; set; }
        public string Account { get; set; }
        public int Replies { get; set; }
        public int Retweets { get; set; }
        public int Likes { get; set; }
    }
}
