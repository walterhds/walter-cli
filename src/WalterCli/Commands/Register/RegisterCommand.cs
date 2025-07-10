using DotMake.CommandLine;
using Walter.Exceptions;
using Walter.Models;
using Walter.Models.Interfaces;
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
		ArgumentNullException.ThrowIfNullOrWhiteSpace(NameArgument, nameof(NameArgument));
		ArgumentNullException.ThrowIfNullOrWhiteSpace(PathArgument, nameof(PathArgument));

		if (!IOWrapper.FileExists(PathArgument))
		{
			ConsoleWrapper.WriteError(new ScriptNotFoundException(PathArgument).Serialize());
			return;
		}

		IRecord record = RecordRepository.GetRecord();

		if (record.ScriptList.Any(script => script.Name.Equals(NameArgument, StringComparison.CurrentCultureIgnoreCase)))
		{
			ConsoleWrapper.WriteError(new ScriptAlreadyRegisteredException(NameArgument).ToString());
			return;
		}

		var script = new Script(NameArgument, PathArgument);

		record.ScriptList.Add(script);

		RecordRepository.SaveRecord(record);

		ConsoleWrapper.WriteLine($"Script {NameArgument} registered.");
	}
}
