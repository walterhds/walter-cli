using Walter.Exceptions;

namespace System;

internal static class ExceptionExtensions
{
	public static string GetErrorCode(this Exception exception)
	{
		if (exception is not null
			&& exception
				.GetType()
				.GetCustomAttributes(typeof(ErrorCodeAttribute), false) is ErrorCodeAttribute[] attributes
					&& attributes.Length > 0)
		{
			return attributes[0].Code.ToString();
		}
		return "Unknown error code";
	}

	public static string Serialize(this Exception exception)
	{
		return "[Error Code: " + exception.GetErrorCode() + "]\n" + exception.GetType().Name + ": " + exception.Message;
	}
}
