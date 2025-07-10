using Test.Data;
using Walter.Models;
using Record = Walter.Models.Record;


namespace WalterCli.UnitTests.Helpers;

public class Serializer
{
	[Fact]
	public void ShouldSerializeAndDeserializeObject()
	{
		// Arrange
		var original = new Script("TestScript", "/path/to/script");
		var record = new Record
		{
			ScriptList = [original]
		};
		var serializer = new Walter.Wrappers.Serializer();

		// Act
		string serialized = serializer.Serialize(record);
		var deserialized = serializer.Deserialize<Record>(serialized);

		// Assert
		Assert.NotNull(deserialized);
		Assert.Single(deserialized.ScriptList);
		Assert.Equal(original.Name, deserialized.ScriptList[0].Name);
		Assert.Equal(original.Path, deserialized.ScriptList[0].Path);
	}

	[Fact]
	public void ShouldDeserializeFromJson()
	{
		// Arrange
		var content = ResourceManager.GetResource("RecordWithScriptListNotEmpty.json");
		var serializer = new Walter.Wrappers.Serializer();

		// Act
		var deserialized = serializer.Deserialize<Record>(content);

		// Assert
		Assert.NotNull(deserialized);
		Assert.NotEmpty(deserialized.ScriptList);
		Assert.Equal("calc", deserialized.ScriptList[0].Name);
		Assert.Equal("C:\\repos\\run-calc.ps1", deserialized.ScriptList[0].Path);
	}
}
