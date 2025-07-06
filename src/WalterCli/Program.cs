using DotMake.CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Walter.Commands.Root;
using Walter.Repositories;
using Walter.Repositories.Interfaces;
using Walter.Wrappers;
using Walter.Wrappers.Interfaces;

try
{
	ConfigureServices();

	Cli.Run<RootCommand>(args);
}
catch (Exception e)
{
	Console.WriteLine(@"Error: {0}", e.Message);
}

static void ConfigureServices() => Cli.Ext.ConfigureServices(services =>
{
	services
		.AddSingleton<ISerializer, Serializer>()
		.AddSingleton<IRecordRepository, RecordRepository>()
		.AddSingleton<IConsoleWrapper, ConsoleWrapper>()
		.AddSingleton<IIOWrapper, IOWrapper>()
		;
});
