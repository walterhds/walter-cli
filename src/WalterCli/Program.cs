using System.CommandLine;
using Walter.Commands.Register;

var rootCommand = new RootCommand("Walter CLI");
rootCommand.Aliases.Add("walter");

rootCommand.Subcommands.Add(new RegisterCommand());

rootCommand.Parse(args).Invoke();
