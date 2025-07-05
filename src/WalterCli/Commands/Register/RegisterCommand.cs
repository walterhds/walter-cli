using System.CommandLine;

namespace WalterCli.Commands.Register;

internal class RegisterCommand : Command
{
	private readonly Argument<string> _nameArgument = new("name");
	private readonly Argument<string> _pathArgument = new("path");

	public RegisterCommand() : base("register", "Register a new script")
	{
		Add(_nameArgument);
		Add(_pathArgument);

		SetAction((result) =>
		{
			var name = result.GetValue(_nameArgument);
			Console.WriteLine($"Registering script with name: {name}");
		});
	}
}
