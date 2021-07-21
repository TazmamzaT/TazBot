using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazBot.Service.Options
{
    public class RedditOptions
    {
        public const string Reddit = "Reddit";

        public string AppId { get; set; }
        public string RefreshToken { get; set; }
        public string Secret { get; set; }
    }
}
