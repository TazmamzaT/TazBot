using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazBot.Service.Messages
{
    public class HelpMessageBuilder : EmbedBuilder
    {
        public HelpMessageBuilder()
        {
            Fields = new List<EmbedFieldBuilder>()
            {
                new(){ Name = "!taz", Value = "joke"},
                new(){ Name = "!taz", Value = "thanks"},
                new(){ Name = "!taz", Value = "insult [@user]"},
                new(){ Name = "!taz", Value = "spongebob-gif"},
                new(){ Name = "!taz reddit", Value = "dailytop3 [subreddit]"},
                new(){ Name = "!taz reddit", Value = "randomtop [subreddit]"},
                new(){ Name = "!taz reddit", Value = "randomhot [subreddit]"},
                new(){ Name = "!taz google", Value = "luckyimage [query (quotes)]"},
                new(){ Name = "!taz gif", Value = "random [tag]"},
            };

            Title = "Command List";
            ThumbnailUrl = "https://avatars2.githubusercontent.com/u/25140729?s=460&u=e87cfa6adaed41b3b9f1d77c8d45165989233160&v=4";

            Color = Discord.Color.Red;
        }
    }
}
