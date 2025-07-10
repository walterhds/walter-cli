namespace Walter.Exceptions;

[ErrorCode(10002)]
internal class ScriptAlreadyRegisteredException(string script)
	: ExceptionBase($"Script '{script}' is already registered.")
{ }
