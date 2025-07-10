namespace Walter.Exceptions;

internal abstract class ExceptionBase(string message) : Exception(message)
{
	public override string ToString()
	{
		return this.Serialize();
	}
}
