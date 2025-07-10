using Walter.Models.Interfaces;

namespace Walter.Repositories.Interfaces;

public interface IRecordRepository
{
	IRecord GetRecord();
	void SaveRecord(IRecord record);
}
