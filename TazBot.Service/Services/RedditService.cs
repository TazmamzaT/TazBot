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

            var post = _client.Subreddit(subreddit).Posts.Top[rand];

            var uri = GetUriFromPost(post);

            return post.Title + "\n" + uri.ToString();
        }

        public string DailyTopPost(string subreddit, int number)
        {
            var post = _client.Subreddit(subreddit).Posts.GetTop("day")[number];

            return AddTitle(post);
        }

        public string RandomHot(string subreddit)
        {
            var post = _client.Subreddit(subreddit).Posts.GetHot()[rnd.Next(10)];
            return AddTitle(post);
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
