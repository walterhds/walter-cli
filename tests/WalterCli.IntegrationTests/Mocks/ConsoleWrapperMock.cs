using Walter.Wrappers.Interfaces;
using Xunit.Abstractions;

namespace WalterCli.IntegrationTests.Mocks;

internal class ConsoleWrapperMock(
	ITestOutputHelper testOutputHelper,
	IConsoleWrapper consoleWrapper)
		: IConsoleWrapper
{
	private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;
	private readonly IConsoleWrapper _consoleWrapper = consoleWrapper;

	public void WriteError(string message)
	{
		_consoleWrapper.WriteError(message);
		//_testOutputHelper.WriteLine(message);
	}
	public void WriteLine(string message)
	{
		_consoleWrapper.WriteLine(message);
		_testOutputHelper.WriteLine(message);
	}
}
