using DotMake.CommandLine;
using Walter.Models;
using Walter.Repositories.Interfaces;
using Walter.Wrappers.Interfaces;

namespace Walter.Commands.Register;

[CliCommand(Name = "register", Description = "Register a new script")]
internal class RegisterCommand(
	IRecordRepository recordRepository,
	IConsoleWrapper consoleWrapper,
	IIOWrapper ioWrapper)
		: CommandBase(
			recordRepository,
			consoleWrapper,
			ioWrapper)
{
	[CliArgument(Description = "The name of the script to register")]
	public string? NameArgument { get; set; }

	[CliArgument(Description = "The path to the script file to register")]
	public string? PathArgument { get; set; }

	public void Run()
	{
		if (string.IsNullOrWhiteSpace(NameArgument) && string.IsNullOrWhiteSpace(PathArgument))
		{
			ConsoleWrapper.WriteError("Name and path cannot be empty.");
			return;
		}

		if (string.IsNullOrWhiteSpace(NameArgument) || string.IsNullOrWhiteSpace(PathArgument))
		{
			ConsoleWrapper.WriteError("Name and path cannot be empty.");
			return;
		}

		if (!IOWrapper.FileExists(PathArgument))
		{
			ConsoleWrapper.WriteError($"The file at path '{PathArgument}' does not exist.");
			return;
		}

		Record record = RecordRepository.GetRecord();

		if (record.ScriptList.Any(script => script.Name.Equals(NameArgument, StringComparison.CurrentCultureIgnoreCase)))
		{
			ConsoleWrapper.WriteError($"A script with the name '{NameArgument}' already exists.");
			return;
		}

		var script = new Script(NameArgument, PathArgument);

		record.ScriptList.Add(script);

		RecordRepository.SaveRecord(record);

		ConsoleWrapper.WriteLine($"Script {NameArgument} registered.");
	}
}
