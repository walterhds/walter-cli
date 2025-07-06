using Walter.Repositories.Interfaces;
using Walter.Wrappers.Interfaces;

namespace Walter.Commands;

internal abstract class CommandBase(
	IRecordRepository recordRepository,
	IConsoleWrapper consoleWrapper,
	IIOWrapper ioWrapper)
{
	protected readonly IRecordRepository RecordRepository = recordRepository;

	protected readonly IConsoleWrapper ConsoleWrapper = consoleWrapper;

	protected readonly IIOWrapper IOWrapper = ioWrapper;
}
