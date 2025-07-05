using System.CommandLine;
using Walter.Models;

namespace Walter.Commands.Register;

internal class RegisterCommand : CommandBase
{
	private readonly Argument<string> _nameArgument = new("name");
	private readonly Argument<string> _pathArgument = new("path");

	public RegisterCommand() : base("register", "Register a new script")
	{
		Add(_nameArgument);
		Add(_pathArgument);

		SetAction((result) =>
		{
			string? path = result.GetValue(_pathArgument);
			string? name = result.GetValue(_nameArgument);

			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(path))
			{
				Console.WriteLine("Name and path cannot be empty.");
				return;
			}

			if (!File.Exists(path))
			{
				Console.WriteLine($"The file at path '{path}' does not exist.");
				return;
			}

			Record record = RecordRepository.GetRecord();

			if (record.ScriptList.Any(script => script.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
			{
				Console.WriteLine($"A script with the name '{name}' already exists.");
				return;
			}

			var script = new Script(name, path);

			record.ScriptList.Add(script);

			RecordRepository.SaveRecord(record);

			Console.WriteLine($"Script {name} registered.");
		});
	}
}
