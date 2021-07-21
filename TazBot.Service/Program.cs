﻿using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using TazBot.Service.Options;
using Microsoft.Extensions.Configuration;
using TazBot.Service.Services;
using System.Net.Http;

namespace TazBot.Service
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            await host.Services.GetRequiredService<CommandHandlerService>().InstallCommandsAsync();
            await host.Services.GetRequiredService<GeneralService>().GetRandomGifByTag("sponge");

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.AddJsonFile("secrets.json", false);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Bootstrapper>();
                    services.AddSingleton<CommandHandlerService>();
                    services.AddSingleton<DiscordSocketClient>();
                    services.AddSingleton<CommandService>();
                    services.AddSingleton<DadJokeService>();
                    services.AddSingleton<RedditService>();
                    services.AddSingleton<GoogleService>();
                    services.AddSingleton<HttpClient>();
                    services.AddSingleton<GeneralService>();

                    var config = hostContext.Configuration;

                    var env = Environment.GetEnvironmentVariable("ENVIRONMENT");

                    if (env == "Development")
                    {
                        services.Configure<DiscordOptions>(config.GetSection(DiscordOptions.DiscordDev));
                    }
                    else
                    {
                        services.Configure<DiscordOptions>(config.GetSection(DiscordOptions.DiscordProd));
                    }
                    
                    services.Configure<RedditOptions>(config.GetSection(RedditOptions.Reddit));
                    services.Configure<GoogleOptions>(config.GetSection(GoogleOptions.Google));
                    services.Configure<GiphyOptions>(config.GetSection(GiphyOptions.Giphy));

                    services.AddHttpClient();
                });
    }
}