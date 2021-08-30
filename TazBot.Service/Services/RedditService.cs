using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Reddit;
using Reddit.Controllers;
using TazBot.Service.Options;

namespace TazBot.Service.Services
{
    public class RedditService
    {
        private const string CANT_FIND_SUBREDDIT = "I don't think I can find the subreddit.";

        Random rnd = new Random();

        private RedditClient _client { get; set; }
        private RedditOptions _redditOptions { get; set; }

        public RedditService(IOptions<RedditOptions> options)
        {
            _redditOptions = options.Value;
            _client = new RedditClient(_redditOptions.AppId, _redditOptions.RefreshToken, _redditOptions.Secret);
        }

        public string RandomTopPost(string subreddit)
        {
            var rand = rnd.Next(10);

            try
            {
                var post = _client.Subreddit(subreddit).Posts.Top[rand];
                var uri = GetUriFromPost(post);

                return post.Title + "\n" + uri.ToString();
            }
            catch (Reddit.Exceptions.RedditNotFoundException)
            {
                return CANT_FIND_SUBREDDIT;
            }
            
        }

        public string DailyTopPost(string subreddit, int number)
        {
            try
            {
                var post = _client.Subreddit(subreddit).Posts.GetTop("day")[number];
                return AddTitle(post);
            }
            catch (Reddit.Exceptions.RedditNotFoundException)
            {
                return CANT_FIND_SUBREDDIT;
            }
        }

        public string RandomHot(string subreddit)
        {
            try
            {
                var post = _client.Subreddit(subreddit).Posts.GetHot()[rnd.Next(10)];
                return AddTitle(post);
            }
            catch (Reddit.Exceptions.RedditNotFoundException)
            {
                return CANT_FIND_SUBREDDIT;
            }
        }

        private string AddTitle(Post post)
        {
            return post.Title + "\n" + GetUriFromPost(post).ToString();
        }

        private Uri GetUriFromPost(Post post)
        {
            Uri uri = null;
            if (post is LinkPost linkpost)
            {
                uri = new Uri(linkpost.URL);
            }
            else if (post is SelfPost)
            {
                var linkstring = "https://www.reddit.com" + post.Permalink;
                uri = new Uri(linkstring);
            }

            return uri;
        }
    }
}
