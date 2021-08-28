using KSoftNet;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazBot.Service.Options;

namespace TazBot.Service.Services
{
    public class KsoftService : KSoftAPI
    {
        public KsoftService(ILogger<KsoftService> logger, IOptions<KsoftOptions> options) : base(options.Value.Apitoken)
        {
        }
    }
}
