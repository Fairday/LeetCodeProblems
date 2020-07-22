using ALGON.LeetCodeProblems.Design;

namespace ALGON.LeetCodeProblemsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var twitter = new Twitter();
            twitter.PostTweet(1, 5);
            twitter.PostTweet(1, 3);
            twitter.PostTweet(1, 101);
            twitter.PostTweet(1, 13);
            twitter.PostTweet(1, 10);
            twitter.PostTweet(1, 2);
            twitter.PostTweet(1, 94);
            twitter.PostTweet(1, 505);
            twitter.PostTweet(1, 333);
            var news = twitter.GetNewsFeed(1);
        }
    }
}
