using System.Text.Json;
using System.Text.Json.Serialization;
using Walter.Models;
using Walter.Models.Interfaces;
using Walter.Wrappers.Interfaces;

namespace Walter.Shared.Converters;

internal class ScriptConverter()
	: JsonConverter<IScript>
{
	public override IScript? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return JsonSerializer.Deserialize<Script>(ref reader, options);
	}

	public override void Write(Utf8JsonWriter writer, IScript value, JsonSerializerOptions options)
	{
		JsonSerializer.Serialize(writer, (Script)value, options);
	}
}
