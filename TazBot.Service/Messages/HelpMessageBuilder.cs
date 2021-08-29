using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazBot.Service.Messages
{
    public class HelpMessageBuilder : EmbedBuilder
    {
        public HelpMessageBuilder()
        {
            Title = "Command List";
            ThumbnailUrl = "https://avatars2.githubusercontent.com/u/25140729?s=460&u=e87cfa6adaed41b3b9f1d77c8d45165989233160&v=4";

            Color = Discord.Color.Red;

            GenerateHelpUsingReflection();
            Footer = new EmbedFooterBuilder()
            {
                Text = "Make sure to use quotes (\"\") for multiple words in queries!\nAlso remember subreddits are a single string."
            };
        }

        private void GenerateHelpUsingReflection()
        {
            Fields = new List<EmbedFieldBuilder>();

            var commandmodules = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(ModuleBase<SocketCommandContext>).IsAssignableFrom(p))
                .ToList();

            foreach(var module in commandmodules)
            {
                // Should only be one group per module
                GroupAttribute group = (GroupAttribute) Attribute.GetCustomAttribute(module, typeof(GroupAttribute));
                //CommandAttribute[] commands = (CommandAttribute[]) Attribute.GetCustomAttributes(module, typeof(CommandAttribute));
                var methods = module.GetMethods();
                //var commands2 = methods.Where(m => m.CustomAttributes.Any(ca => ca.GetType() == typeof(CommandAttribute))).ToList();
                var commands = methods.Where(m => m.CustomAttributes.Any(ca => ca.AttributeType == typeof(CommandAttribute))).ToList();

                foreach (var command in commands)
                {
                    //Fields.Insert(0, new() { Name = "!taz", Value = command.CustomAttributes.Where(a => a.AttributeType == typeof(CommandAttribute)).First().ConstructorArguments.First().Value.ToString() });
                    var attributes = (CommandAttribute[])Attribute.GetCustomAttributes(command, typeof(CommandAttribute));
                    //Fields.Insert(0, new() { Name = "!taz", Value = command.CustomAttributes.Where(a => a.AttributeType == typeof(CommandAttribute)).First().ConstructorArguments.First().Value.ToString() });
                    var temp = command.GetParameters();
                    foreach (var attribute in attributes)
                    {
                        string groupname = string.Empty;
                        if (group is not null)
                        {
                            groupname = $" {group.Prefix}";
                        }

                        if (groupname == string.Empty)
                        {
                            var text = attribute.Text;
                            foreach (var param in temp)
                            {
                                text += $" [{param.Name}]";
                            }
                            Fields.Insert(0, new EmbedFieldBuilder { Name = $"!taz{groupname}", Value = text });
                        }
                        else
                        {
                            var text = attribute.Text;
                            foreach (var param in temp)
                            {
                                text += $" [{param.Name}]";
                            }
                            Fields.Add(new EmbedFieldBuilder { Name = $"!taz{groupname}", Value = text });
                        }
                    }
                }
            }
        }
    }
}
