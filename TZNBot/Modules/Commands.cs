using System;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;
using System.Reflection;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace TZNBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("info")]
        private async Task info([Remainder]string text)
        {
            var TZN = new EmbedAuthorBuilder()
                    .WithName("TZN")
                    .WithIconUrl("https://cdn.discordapp.com/attachments/803742273816625183/961571950688346132/tzn.png");
            Context.Channel.SendMessageAsync("@everyone");
            var embeda = new EmbedBuilder()
                    .WithTitle($"Ogłoszenie")
                    .WithDescription(text)
                    .WithColor(new Color(227, 66, 52))
                    .WithAuthor(TZN);

            var e = await ReplyAsync(embed: embeda.Build());
            Context.Message.DeleteAsync();
        }
        [Command("pomysł")]
        private async Task pomysł([Remainder]string text)
        {
            var emojiRole1 = new Emoji("👍");
            var emojiRole2 = new Emoji("👎");
            var TZN = new EmbedAuthorBuilder()
                .WithName("TZN")
                .WithIconUrl("https://cdn.discordapp.com/attachments/803742273816625183/961571950688346132/tzn.png");

            var embeda = new EmbedBuilder()
                    .WithTitle("Pomysł od " + Context.Message.Author)
                    .WithDescription(text)
                    .WithColor(new Color(44, 31, 76))
                    .WithAuthor(TZN);

            var e = await ReplyAsync(embed: embeda.Build());
            var emo1 = e.AddReactionAsync(emojiRole1);
            var emo2 = e.AddReactionAsync(emojiRole2);

            Context.Message.DeleteAsync();
        }
    }
}
