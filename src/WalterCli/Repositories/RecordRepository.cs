using Walter.Models;
using Walter.Repositories.Interfaces;
using Walter.Wrappers.Interfaces;

namespace Walter.Repositories;

internal class RecordRepository(ISerializer serializer) : IRecordRepository
{
	private readonly string _recordPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Records", "records.json");
	private readonly ISerializer _serializer = serializer;

	public Record GetRecord()
	{
		PrepareFolderPath();

		if (File.Exists(_recordPath))
		{
			string content = File.ReadAllText(_recordPath);
			return _serializer.Deserialize<Record>(content) ?? new Record();
		}

		return new Record();
	}

	public void SaveRecord(Record record)
	{
		PrepareFolderPath();

		string content = _serializer.Serialize(record);
		File.WriteAllText(_recordPath, content);
	}

	private void PrepareFolderPath()
	{
		if (!Directory.Exists(Path.GetDirectoryName(_recordPath)))
		{
			Directory.CreateDirectory(Path.GetDirectoryName(_recordPath)!);
		}
	}
}
