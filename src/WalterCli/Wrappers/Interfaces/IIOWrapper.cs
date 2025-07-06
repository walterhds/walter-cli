namespace Walter.Wrappers.Interfaces;
internal interface IIOWrapper
{
	bool FileExists(string filePath);
	string FileReadAllText(string filePath);
	void FileWriteAllText(string filePath, string content);
	bool DirectoryExists(string directoryPath);
	void DirectoryCreate(string directoryPath);
}
