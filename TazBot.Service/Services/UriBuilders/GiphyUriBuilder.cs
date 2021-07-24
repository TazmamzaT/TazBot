using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazBot.Service.Options;

namespace TazBot.Service.Services.UriBuilders
{
    public class GiphyUriBuilder
    {
        private readonly GiphyOptions _giphyOptions;

        public GiphyUriBuilder(IOptions<GiphyOptions> options)
        {
            _giphyOptions = options.Value;
        }
            
        public string RandomByTag()
        {
            var build = new UriBuilder("api.giphy.com/v1/gifs/random");
                        query["api_key"] = _giphyOptions.Apikey;
        }
    }
}
