using ALGON.LeetCodeProblems.Model;
using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    public class TwitterSolution : SolutionBase
    {
        public override bool SolveMe()
        {
            var twitter = new Twitter();
            twitter.PostTweet(1, 5);
            var news = twitter.GetNewsFeed(1);
            twitter.Follow(1, 2);
            twitter.PostTweet(2, 6);
            var news2 = twitter.GetNewsFeed(1);
            twitter.Unfollow(1, 2);
            var news3 = twitter.GetNewsFeed(1);

            return true;
        }
    }

  /*Design a simplified version of Twitter where users can post tweets, follow/unfollow another user and is able to see the 10 most recent tweets in the user's news feed. Your design should support the following methods:

    postTweet(userId, tweetId) : Compose a new tweet.
    getNewsFeed(userId): Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent.
    follow(followerId, followeeId) : Follower follows a followee.
    unfollow(followerId, followeeId): Follower unfollows a followee.
    Example:

    Twitter twitter = new Twitter();

    //User 1 posts a new tweet (id = 5).
    twitter.postTweet(1, 5);

    //User 1's news feed should return a list with 1 tweet id -> [5].
    twitter.getNewsFeed(1);

    //User 1 follows user 2.
    twitter.follow(1, 2);

    //User 2 posts a new tweet (id = 6).
    twitter.postTweet(2, 6);

    //User 1's news feed should return a list with 2 tweet ids -> [6, 5].
    //Tweet id 6 should precede tweet id 5 because it is posted after tweet id 5.
    twitter.getNewsFeed(1);

    //User 1 unfollows user 2.
    twitter.unfollow(1, 2);

    //User 1's news feed should return a list with 1 tweet id -> [5],
    //since user 1 is no longer following user 2.
    twitter.getNewsFeed(1);*/

    public class Twitter
    {
        Dictionary<int, HashSet<int>> _Followers; //followee - key, value - followers
        Dictionary<int, Heap<Tweet>> _FollowerNews;
        Dictionary<int, HashSet<Tweet>> _FollowerTwits;
        int count = 0;

        internal class Tweet : IComparable<Tweet>
        {
            public int id;
            public int time;

            public Tweet(int id, int time)
            {
                this.id = id;
                this.time = time;
            }

            public int CompareTo(Tweet other)
            {
                if (time == other.time)
                    return 0;
                else if (time > other.time)
                    return 1;
                else
                    return -1;
            }
        }

        /** Initialize your data structure here. */
        public Twitter()
        {
            _Followers = new Dictionary<int, HashSet<int>>();
            _FollowerTwits = new Dictionary<int, HashSet<Tweet>>();
            _FollowerNews = new Dictionary<int, Heap<Tweet>>();
        }

        void EnsureUserExist(int userId)
        {
            if (!_Followers.ContainsKey(userId))
            {
                var followers = new HashSet<int>();
                followers.Add(userId);
                _Followers[userId] = followers;
                _FollowerTwits[userId] = new HashSet<Tweet>();
                _FollowerNews[userId] = new Heap<Tweet>(SortDirection.Descending);
            }
        }

        /** Compose a new tweet. */
        public void PostTweet(int userId, int tweetId)
        {
            EnsureUserExist(userId);
            var followers = _Followers[userId];
            var userTweets = _FollowerTwits[userId];
            var tweet = new Tweet(tweetId, ++count);
            userTweets.Add(tweet);
            foreach (var follower in followers)
                _FollowerNews[follower].Push(tweet);
        }

        /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
        public IList<int> GetNewsFeed(int userId)
        {
            EnsureUserExist(userId);
            var preservedTweets = new List<Tweet>();
            var ids = new List<int>();
            var tweets = _FollowerNews[userId];
            var size = Math.Min(tweets.Count, 10);
            for (int i = 0; i < size; i++)
            {
                var tweet = tweets.Pop();
                preservedTweets.Add(tweet);
                ids.Add(tweet.id);
            }

            foreach (var pt in preservedTweets)
                _FollowerNews[userId].Push(pt);

            return ids;
        }

        /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
        public void Follow(int followerId, int followeeId)
        {
            EnsureUserExist(followerId);
            EnsureUserExist(followeeId);
            if (!_Followers[followeeId].Contains(followerId) && followerId != followeeId)
            {
                _Followers[followeeId].Add(followerId);
                var tweets = _FollowerTwits[followeeId];
                foreach (var tweet in tweets)
                    _FollowerNews[followerId].Push(tweet);
            }
        }

        /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
        public void Unfollow(int followerId, int followeeId)
        {
            EnsureUserExist(followerId);
            EnsureUserExist(followeeId);
            if (_Followers[followeeId].Contains(followerId) && followerId != followeeId)
            {
                _Followers[followeeId].Remove(followerId);
                var tweets = _FollowerTwits[followeeId];
                using (var hds = new HeapifyDeferState(_FollowerNews[followerId]))
                {
                    foreach (var tweet in tweets)
                    {
                        _FollowerNews[followerId].RemoveIf(t => t.id == tweet.id);
                    }
                }
            }
        }
    }
}
