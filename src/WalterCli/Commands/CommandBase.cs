using System.CommandLine;
using Walter.Repositories;

namespace Walter.Commands;
internal abstract class CommandBase(string name, string description) : Command(name, description)
{
	protected readonly RecordRepository RecordRepository = RecordRepository.Instance;
}
