using System.Reflection;
using Walter.Exceptions;

namespace WalterCli.UnitTests.Exceptions;

public class ErrorCode
{
	private static readonly string _namespace = typeof(ErrorCodeAttribute).Namespace!;
	private static readonly IList<Type> _exceptionTypeList = [.. typeof(ErrorCodeAttribute)
			.Assembly
			.GetTypes()
			.Where(t =>
				t.IsClass
				&& !t.Name.Equals(nameof(ErrorCodeAttribute))
				&& !t.IsAbstract
				&& t.Namespace is not null && t.Namespace.Equals(_namespace))];

	private static readonly IList<short> _errorCodeList = [.. _exceptionTypeList
		.Where(t => t.GetCustomAttribute<ErrorCodeAttribute>() is not null)
		.Select(t => t.GetCustomAttribute<ErrorCodeAttribute>()!.Code)
		.OrderBy(c => c)];

	[Fact]
	public void ShouldNameEndsWithException()
	{
		Assert.True(_exceptionTypeList.All(exception => exception.Name.EndsWith("Exception")));
	}

	[Fact]
	public void ShouldHaveExceptionErrorCodeAttribute()
	{
		foreach (Type type in _exceptionTypeList)
		{
			Assert.NotNull(type.GetCustomAttribute<ErrorCodeAttribute>());
		}
	}

	[Fact]
	public void ShouldHaveUniqueErrorCodes()
	{
		var duplicates = _errorCodeList
			.GroupBy(c => c)
			.Where(g => g.Count() > 1)
			.Select(g => g.Key)
			.ToList();
		Assert.Empty(duplicates);
	}

	[Fact]
	public void ShouldHaveSequentialErrorCodes()
	{
		if (_errorCodeList.Count == 0)
		{
			return;
		}

		short minCode = _errorCodeList.Min();

		for (int i = 0; i < _errorCodeList.Count; i++)
		{
			Assert.Equal((short)(minCode + i), _errorCodeList[i]);
		}
	}
}
