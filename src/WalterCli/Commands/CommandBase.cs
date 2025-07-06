using Walter.Repositories.Interfaces;
using Walter.Wrappers.Interfaces;

namespace Walter.Commands;

internal abstract class CommandBase(
	IRecordRepository recordRepository,
	IConsoleWrapper consoleWrapper)
{
	protected readonly IRecordRepository RecordRepository = recordRepository;

	protected readonly IConsoleWrapper ConsoleWrapper = consoleWrapper;
}
