using Walter.Models.Interfaces;

namespace Walter.Models;

internal class Script(
	string name,
	string path)
		: IScript
{
	public string Name { get; set; } = name;

	public string Path { get; set; } = path;
}
