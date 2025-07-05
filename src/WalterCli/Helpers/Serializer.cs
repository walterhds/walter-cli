using System.Text.Json;

namespace Walter.Helpers;

public class Serializer
{
	public static Serializer Instance { get; } = new Serializer();

	private Serializer()
	{ }

	private readonly JsonSerializerOptions _options = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
		WriteIndented = false,
		DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
	};

	public string Serialize<T>(T obj)
	{
		return JsonSerializer.Serialize(obj, _options);
	}

	public T Deserialize<T>(string json)
	{
		return JsonSerializer.Deserialize<T>(json, _options) ?? throw new InvalidOperationException("Deserialization failed.");
	}
}
