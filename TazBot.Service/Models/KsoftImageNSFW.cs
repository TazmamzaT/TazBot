using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazBot.Service.Models
{

    public class KsoftImageNSFW
    {
        public string title { get; set; }
        public string image_url { get; set; }
        public string source { get; set; }
        public string subreddit { get; set; }
        public int upvotes { get; set; }
        public int downvotes { get; set; }
        public int comments { get; set; }
        public int created_at { get; set; }
        public bool nsfw { get; set; }
        public string author { get; set; }
        public int awards { get; set; }
    }

}
