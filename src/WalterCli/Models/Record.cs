using System.Text.Json.Serialization;

namespace Walter.Models;

internal class Record
{
	[JsonPropertyName("scripts")]
	public IList<Script> ScriptList { get; set; } = [];
}
