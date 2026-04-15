namespace DesignTwitter
{
    /*
     Design a simplified version of Twitter where users can post tweets, follow/unfollow another user, and is able to see the 10 most recent 
    tweets in the user's news feed.

Implement the Twitter class:

Twitter() Initializes your twitter object.
void postTweet(int userId, int tweetId) Composes a new tweet with ID tweetId by the user userId. Each call to this function will be made with a unique tweetId.
List<Integer> getNewsFeed(int userId) Retrieves the 10 most recent tweet IDs in the user's news feed. Each item in the news feed must be 
    posted by users who the user followed or by the user themself. Tweets must be ordered from most recent to least recent.
void follow(int followerId, int followeeId) The user with ID followerId started following the user with ID followeeId.
void unfollow(int followerId, int followeeId) The user with ID followerId started unfollowing the user with ID followeeId.
    
     Example 1:

Input
["Twitter", "postTweet", "getNewsFeed", "follow", "postTweet", "getNewsFeed", "unfollow", "getNewsFeed"]
[[], [1, 5], [1], [1, 2], [2, 6], [1], [1, 2], [1]]
Output
[null, null, [5], null, null, [6, 5], null, [5]]

Explanation
Twitter twitter = new Twitter();
twitter.postTweet(1, 5); // User 1 posts a new tweet (id = 5).
twitter.getNewsFeed(1);  // User 1's news feed should return a list with 1 tweet id -> [5]. return [5]
twitter.follow(1, 2);    // User 1 follows user 2.
twitter.postTweet(2, 6); // User 2 posts a new tweet (id = 6).
twitter.getNewsFeed(1);  // User 1's news feed should return a list with 2 tweet ids -> [6, 5]. Tweet id 6 should precede tweet id 5 because it is posted after tweet id 5.
twitter.unfollow(1, 2);  // User 1 unfollows user 2.
twitter.getNewsFeed(1);  // User 1's news feed should return a list with 1 tweet id -> [5], since user 1 is no longer following user 2.
     
     */

    public class Twitter
    {

        Dictionary<int, User> users;// store map of users
        static int tweetSeq = 0;// for tweet sequence

        public Twitter()
        {
            users = new Dictionary<int, User>();// initialize map
        }

        public void PostTweet(int userId, int tweetId)
        {
            createUserIfNotExist(userId);
            users[userId].Tweets.Add((tweetSeq, tweetId));// add tweet with sequence and id to user's tweets list
            tweetSeq++;
        }

        public IList<int> GetNewsFeed(int userId)
        {
            createUserIfNotExist(userId);
            List<(int, int)> tweets = new List<(int, int)>();// create temp list for tweets
            tweets.AddRange(users[userId].Tweets);
            foreach (var follower in users[userId].Followers)
            {
                tweets.AddRange(users[follower].Tweets);
            }
            tweets.Sort((a, b) => b.Item1.CompareTo(a.Item1));// sort tweets by sequence in descending order
            List<int> res = new List<int>();
            int count = 0;
            foreach (var t in tweets)
            {
                if (count >= 10)// only get top 10 tweets
                    break;
                res.Add(t.Item2);
                count++;
            }
            return res;
        }

        public void Follow(int followerId, int followeeId)
        {
            createUserIfNotExist(followerId);
            createUserIfNotExist(followeeId);
            users[followerId].Followers.Add(followeeId);// add followee to follower's followers list
        }

        public void Unfollow(int followerId, int followeeId)
        {
            createUserIfNotExist(followerId);
            createUserIfNotExist(followeeId);
            users[followerId].Followers.Remove(followeeId);// remove followee from follower's followers list
        }

        private void createUserIfNotExist(int userId)
        {
            if (!users.ContainsKey(userId))
                users[userId] = new User(userId);
        }
    }

    class User
    {
        public int Id { get; set; }
        public HashSet<int> Followers { get; set; }
        public List<(int, int)> Tweets { get; set; }

        public User(int id)
        {
            Id = id;
            Followers = new HashSet<int>();
            Tweets = new List<(int, int)>();
        }

    }

    /**
     * Your Twitter object will be instantiated and called as such:
     * Twitter obj = new Twitter();
     * obj.PostTweet(userId,tweetId);
     * IList<int> param_2 = obj.GetNewsFeed(userId);
     * obj.Follow(followerId,followeeId);
     * obj.Unfollow(followerId,followeeId);
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            //var twitter = new Twitter();
            //twitter.PostTweet(1, 5);
            //twitter.PostTweet(1, 3);

            Twitter twitter = new Twitter();
            twitter.PostTweet(1, 5); // User 1 posts a new tweet (id = 5).
            twitter.GetNewsFeed(1);  // User 1's news feed should return a list with 1 tweet id -> [5]. return [5]
            twitter.Follow(1, 2);    // User 1 follows user 2.
            twitter.PostTweet(2, 6); // User 2 posts a new tweet (id = 6).
            twitter.GetNewsFeed(1);  // User 1's news feed should return a list with 2 tweet ids -> [6, 5]. Tweet id 6 should precede tweet id 5 because it is posted after tweet id 5.
            twitter.Unfollow(1, 2);  // User 1 unfollows user 2.
            twitter.GetNewsFeed(1);  // User 1's news feed should return a list with 1 tweet id -> [5], since user 1 is no longer following user 2.
        }
    }
}