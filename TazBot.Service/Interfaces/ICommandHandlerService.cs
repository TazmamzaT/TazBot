using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace TazBot.Service.Interfaces
{
    public interface ICommandHandlerService
    {
        Task CommandExecutedAsync(Optional<CommandInfo> command, ICommandContext context, IResult result);
        Task InstallCommandsAsync();
    }
}