using DotMake.CommandLine;
using Walter.Commands.Register;
using Walter.Wrappers.Interfaces;

namespace Walter.Commands.Root;

[CliCommand(
	Name = "walter",
	Description = "Walter CLI",
	Children = [
		typeof(RegisterCommand)
	]
)]
internal class RootCommand(IConsoleWrapper consoleWrapper)
{
	private readonly IConsoleWrapper _consoleWrapper = consoleWrapper;

	public void Run()
	{
		_consoleWrapper.WriteLine("Hello! I'm Walter. How can I help you today?");
	}
}
