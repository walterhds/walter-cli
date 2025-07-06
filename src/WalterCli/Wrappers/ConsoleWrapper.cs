using Walter.Wrappers.Interfaces;

namespace Walter.Wrappers;

internal class ConsoleWrapper : IConsoleWrapper
{
	public void WriteError(string message) => Console.Error.WriteLine(message);
	public void WriteLine(string message) => Console.WriteLine(message);
}
