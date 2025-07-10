using System.Text.Json.Serialization;
using Walter.Models.Interfaces;

namespace Walter.Models;

internal class Record : IRecord
{
	public IList<IScript> ScriptList { get; set; } = [];
}
