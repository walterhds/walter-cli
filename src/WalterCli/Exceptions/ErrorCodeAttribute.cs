namespace Walter.Exceptions;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal class ErrorCodeAttribute(short code) : Attribute
{
	public short Code { get; } = code;
}
