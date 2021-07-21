using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TazBot.Service.Services;

namespace TazBot.Service.CommandModules
{
    [Group("reddit")]
    public class RedditModule : ModuleBase<SocketCommandContext>
    {
        public RedditService RedditService { get; set; }

        [Command("randomtop")]
        public async Task RandomTop(string subreddit)
        {
            await ReplyAsync(RedditService.RandomTopPost(subreddit));
        }


        [Command("dailytop3")]
        public async Task DailyTop3Async(string subreddit)
        {
            for (int i = 0; i < 3; i++)
            {
                await ReplyAsync(RedditService.DailyTopPost(subreddit, i));
            }
        }

        [Command("randomhot")]
        public async Task RandomHotAsync(string subreddit)
        {
            await ReplyAsync(RedditService.RandomHot(subreddit));
        }
    }
}
