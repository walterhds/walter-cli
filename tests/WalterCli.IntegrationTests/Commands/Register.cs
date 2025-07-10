using DotMake.CommandLine;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Walter.Repositories.Interfaces;
using Walter.Wrappers.Interfaces;
using Xunit.Abstractions;
using Record = Walter.Models.Record;

namespace WalterCli.IntegrationTests.Commands;

public class Register(ITestOutputHelper outputHelper)
{
	private readonly ITestOutputHelper _outputHelper = outputHelper;

	[Fact]
	public void ShouldRegisterSuccessfully()
	{
		// Arrange
		IRecordRepository recordRepository = Substitute.For<IRecordRepository>();
		IConsoleWrapper consoleWrapper = Substitute.For<IConsoleWrapper>();
		IConsoleWrapper consoleWrapperMock = new Mocks.ConsoleWrapperMock(
			_outputHelper,
			consoleWrapper
		);
		IIOWrapper ioWrapper = Substitute.For<IIOWrapper>();
		string scriptPath = "/path/to/script";
		ioWrapper.FileExists(scriptPath).Returns(true);
		recordRepository.GetRecord().Returns(new Record()
		{
			ScriptList = []
		});

		Cli.Ext.ConfigureServices(services =>
		{
			services
				.AddSingleton<ISerializer, Walter.Wrappers.Serializer>()
				.AddSingleton(_ => recordRepository)
				.AddSingleton(_ => consoleWrapperMock)
				.AddSingleton(_ => ioWrapper)
				;
		});
		string[] args = ["register", "TestScript", scriptPath];

		// Act
		Cli.Run<Walter.Commands.Root.RootCommand>(args);

		// Assert
		consoleWrapper.Received(1).WriteLine(Arg.Any<string>());
	}
}
