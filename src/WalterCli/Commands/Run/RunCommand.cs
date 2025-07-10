using DotMake.CommandLine;
using Walter.Repositories.Interfaces;
using Walter.Wrappers.Interfaces;

namespace Walter.Commands.Run;

[CliCommand(Name = "run", Description = "Run a registered script", Alias = "run")]
internal class RunCommand(
	IRecordRepository recordRepository,
	IConsoleWrapper consoleWrapper,
	IIOWrapper ioWrapper)
		: CommandBase(
			recordRepository,
			consoleWrapper,
			ioWrapper)
{
	[CliArgument(Description = "The name of the script to run")]
	public string? NameArgument { get; set; }

	public void Run(CliContext cliContext)
	{

	}
}
