using Walter.Repositories.Interfaces;

namespace Walter.Commands;

internal abstract class CommandBase(IRecordRepository recordRepository)
{
	protected readonly IRecordRepository RecordRepository = recordRepository;
}
