namespace Concordia.Modules.Testing
{
    using System.Threading.Tasks;
    using Discord.Commands;

    public class TestCommands : ModuleBase<SocketCommandContext>
    {
        [Command("test")]
        [Summary("Just a test.")]
        private async Task TestAsync(string input)
            => await Context.Channel.SendMessageAsync($"ur an fag cuz u said {input}.");
        
    }
}
