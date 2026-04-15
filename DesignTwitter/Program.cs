namespace DesignTwitter
{
    public class Twitter
    {

        public Twitter()
        {

        }

        public void PostTweet(int userId, int tweetId)
        {

        }

        public IList<int> GetNewsFeed(int userId)
        {

        }

        public void Follow(int followerId, int followeeId)
        {

        }

        public void Unfollow(int followerId, int followeeId)
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var twitter = new Twitter();
            twitter.PostTweet(1, 5);
            twitter.PostTweet(1, 3);
        }
    }
}