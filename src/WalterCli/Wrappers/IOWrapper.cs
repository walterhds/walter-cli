using Walter.Wrappers.Interfaces;

namespace Walter.Wrappers;
internal class IOWrapper : IIOWrapper
{
	public void DirectoryCreate(string directoryPath) => Directory.CreateDirectory(directoryPath);
	public bool DirectoryExists(string directoryPath) => Directory.Exists(directoryPath);
	public bool FileExists(string filePath) => File.Exists(filePath);
	public string FileReadAllText(string filePath) => File.ReadAllText(filePath);
	public void FileWriteAllText(string filePath, string content) => File.WriteAllText(filePath, content);
}
