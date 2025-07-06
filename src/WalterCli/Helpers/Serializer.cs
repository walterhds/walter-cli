using System.Text.Json;
using Walter.Helpers.Interfaces;

namespace Walter.Helpers;

public class Serializer : ISerializer
{
	private readonly JsonSerializerOptions _options = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
		WriteIndented = false,
		DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
	};

	public string Serialize<T>(T obj)
		where T : class
	{
		return JsonSerializer.Serialize(obj, _options);
	}

	public T Deserialize<T>(string json)
		where T : class
	{
		return JsonSerializer.Deserialize<T>(json, _options) ?? throw new InvalidOperationException("Deserialization failed.");
	}
}
