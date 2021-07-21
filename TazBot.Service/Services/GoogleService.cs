using System;
using System.Collections.Generic;
using System.Text;
using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
using Microsoft.Extensions.Options;
using TazBot.Service.Options;

namespace TazBot.Service.Services
{
    public class GoogleService
    {
        private readonly GoogleOptions _options;

        public GoogleService(IOptions<GoogleOptions> options)
        {
            _options = options.Value;
        }

        public string ImageSearch(string query)
        {
            var customSearchService = new CustomsearchService(new BaseClientService.Initializer { ApiKey = _options.ApiKey });

            var listRequest = customSearchService.Cse.List();
            listRequest.Cx = _options.SearchEngineId;
            listRequest.Q = query;
            listRequest.SearchType = CseResource.ListRequest.SearchTypeEnum.Image;
            listRequest.Safe = CseResource.ListRequest.SafeEnum.Off;
            var link = listRequest.Execute().Items[0].Link;

            return link;
        }
    }
}
