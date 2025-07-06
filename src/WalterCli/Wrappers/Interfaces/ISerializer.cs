namespace Walter.Wrappers.Interfaces;
internal interface ISerializer
{
	T Deserialize<T>(string content) where T : class;
	string Serialize<T>(T obj) where T : class;
}
