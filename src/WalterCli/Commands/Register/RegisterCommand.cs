using DotMake.CommandLine;
using Walter.Models;
using Walter.Repositories.Interfaces;

namespace Walter.Commands.Register;

[CliCommand(Name = "register", Description = "Register a new script")]
internal class RegisterCommand(IRecordRepository recordRepository) : CommandBase(recordRepository)
{
	[CliArgument(Description = "The name of the script to register")]
	public string? NameArgument { get; set; }

	[CliArgument(Description = "The path to the script file to register")]
	public string? PathArgument { get; set; }

	public void Run()
	{
		if (string.IsNullOrWhiteSpace(NameArgument) && string.IsNullOrWhiteSpace(PathArgument))
		{
			Console.WriteLine("Name and path cannot be empty.");
			return;
		}

		if (string.IsNullOrWhiteSpace(NameArgument) || string.IsNullOrWhiteSpace(PathArgument))
		{
			Console.WriteLine("Name and path cannot be empty.");
			return;
		}

		if (!File.Exists(PathArgument))
		{
			Console.WriteLine($"The file at path '{PathArgument}' does not exist.");
			return;
		}

		Record record = RecordRepository.GetRecord();

		if (record.ScriptList.Any(script => script.Name.Equals(NameArgument, StringComparison.CurrentCultureIgnoreCase)))
		{
			Console.WriteLine($"A script with the name '{NameArgument}' already exists.");
			return;
		}

		var script = new Script(NameArgument, PathArgument);

		record.ScriptList.Add(script);

		RecordRepository.SaveRecord(record);

		Console.WriteLine($"Script {NameArgument} registered.");
	}
}
