using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ICanHazDadJoke.NET;

namespace TazBot.Service.Services
{
    public class DadJokeService
    {
        public async Task<string> GetRandomDadJokeAsync()
        {
            //TODO: Make the client not be created every invocation. 

            // the identifying information
            var libraryName = "TazmamzaT-bot Discord Bot";
            var contactUri = "tazmamzat@gmail.com";

            // creating a client
            var client = new DadJokeClient(libraryName, contactUri);

            // getting a dad joke
            return await client.GetRandomJokeStringAsync();
        }
    }
}
