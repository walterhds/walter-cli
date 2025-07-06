using DotMake.CommandLine;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Walter.Repositories.Interfaces;
using Walter.Wrappers.Interfaces;
using Record = Walter.Models.Record;

namespace WalterCli.IntegrationTests.Commands;

public class Register
{


	[Fact]
	public void ShouldRegisterSuccessfully()
	{
		// Arrange
		IRecordRepository recordRepository = Substitute.For<IRecordRepository>();
		IConsoleWrapper consoleWrapper = Substitute.For<IConsoleWrapper>();
		recordRepository.GetRecord().Returns(new Record()
		{
			ScriptList = []
		});
		Cli.Ext.ConfigureServices(services =>
		{
			services
				.AddSingleton<ISerializer, Walter.Wrappers.Serializer>()
				.AddSingleton(_ => recordRepository)
				.AddSingleton(_ => consoleWrapper)
				;
		});
		string[] args = ["register", "TestScript", "/path/to/script"];

		// Act
		Cli.Run<Walter.Commands.Root.RootCommand>(args);

		// Assert
		consoleWrapper.Received(1).WriteLine(Arg.Any<string>());
	}
}
