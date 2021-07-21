using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TazBot.Service.Services;

namespace TazBot.Service.CommandModules
{
    [Group("google")]
    public class GoogleModule : ModuleBase<SocketCommandContext>
    {
        public GoogleService GoogleService { get; set; }
        
        [Command("luckyimage")]
        public async Task LuckyImage(string query)
        {
            await ReplyAsync(GoogleService.ImageSearch(query));
        }
    }
}
