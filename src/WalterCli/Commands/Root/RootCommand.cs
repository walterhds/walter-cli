using DotMake.CommandLine;
using Walter.Commands.Register;

namespace Walter.Commands.Root;

[CliCommand(
	Name = "walter",
	Description = "Walter CLI",
	Children = [
		typeof(RegisterCommand)
	]
)]
internal class RootCommand
{
	public void Run()
	{
		Console.WriteLine("Hello! I'm Walter. How can I help you today?");
	}
}
