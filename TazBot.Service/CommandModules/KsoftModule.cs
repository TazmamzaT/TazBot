using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazBot.Service.Services;

namespace TazBot.Service.CommandModules
{
    [Group("ksoft")]
    public class KsoftModule : ModuleBase<SocketCommandContext>
    {
        public KsoftService KsoftService { get; set; }

        [Command("randomnsfwgif")]
        public async Task RandomNSFWGif()
        {
            var yeet = await KsoftService.imagesAPI.RandomNsfw(true);
            await ReplyAsync(yeet.ImageUrl);
        }

        [Command("nsfwimage")]
        public async Task NsfwImage(string tag)
        {
            var yeet = await KsoftService.imagesAPI.RandomImage(tag, true);
            await ReplyAsync(yeet.Url);
        }
    }
}
