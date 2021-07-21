using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord;
using TazBot.Service.Options;
using Microsoft.Extensions.Options;

namespace TazBot.Service
{
    public class Bootstrapper : BackgroundService
    {
        private readonly ILogger<Bootstrapper> _logger;
        private readonly DiscordSocketClient _client;
        private readonly DiscordOptions _discordOptions;

        public Bootstrapper(ILogger<Bootstrapper> logger, DiscordSocketClient client, IOptions<DiscordOptions> options)
        {
            _logger = logger;
            _client = client;
            _discordOptions = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting Bootstrapper and loggin in to discord.");
            await _client.LoginAsync(TokenType.Bot, _discordOptions.DiscordToken);
            await _client.StartAsync();
            await _client.SetActivityAsync(new Game("!taz help", ActivityType.Listening));
            _logger.LogInformation("Logged in and waiting for cancellation.");
            await Task.Delay(-1, stoppingToken);
            _logger.LogInformation("Ending program.");
        }
    }
}
