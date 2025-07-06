using Walter.Models;

namespace Walter.Repositories.Interfaces;

internal interface IRecordRepository
{
	Record GetRecord();
	void SaveRecord(Record record);
}
