namespace Walter.Models.Interfaces;

public interface IRecord
{
	IList<IScript> ScriptList { get; }
}
