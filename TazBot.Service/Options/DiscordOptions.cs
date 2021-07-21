using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazBot.Service.Options
{
    public class DiscordOptions
    {
        public const string DiscordProd = "DiscordProd";

        public const string DiscordDev = "DiscordDev";

        public string DiscordToken { get; set; }
    }
}
