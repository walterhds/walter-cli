namespace Walter.Exceptions;

[ErrorCode(10001)]
internal class ScriptNotFoundException(string script)
	: ExceptionBase($"Script '{script}' NOT found.")
{ }
