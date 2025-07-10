using Walter.Models;
using Walter.Models.Interfaces;
using Walter.Repositories.Interfaces;
using Walter.Wrappers.Interfaces;

namespace Walter.Repositories;

internal class RecordRepository(
	ISerializer serializer,
	IIOWrapper ioWrapper)
		: IRecordRepository
{
	private readonly string _recordPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Records", "records.json");
	private readonly ISerializer _serializer = serializer;
	private readonly IIOWrapper _ioWrapper = ioWrapper;

	public IRecord GetRecord()
	{
		PrepareFolderPath();

		if (_ioWrapper.FileExists(_recordPath))
		{
			string content = _ioWrapper.FileReadAllText(_recordPath);
			return _serializer.Deserialize<Record>(content) ?? new Record();
		}

		return new Record();
	}

	public void SaveRecord(IRecord record)
	{
		PrepareFolderPath();

		string content = _serializer.Serialize(record);
		_ioWrapper.FileWriteAllText(_recordPath, content);
	}

	private void PrepareFolderPath()
	{
		if (!_ioWrapper.DirectoryExists(Path.GetDirectoryName(_recordPath)))
		{
			_ioWrapper.DirectoryCreate(Path.GetDirectoryName(_recordPath)!);
		}
	}
}
