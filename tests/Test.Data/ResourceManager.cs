namespace Test.Data;

public class ResourceManager
{
	public static string GetResource(string resourceName)
	{
		var assembly = typeof(ResourceManager).Assembly;
		var resourcePath = assembly.GetManifestResourceNames()
			.FirstOrDefault(name => name.EndsWith(resourceName, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentException($"Resource '{resourceName}' not found.");
		using var stream = assembly.GetManifestResourceStream(resourcePath) ?? throw new InvalidOperationException($"Could not open stream for resource '{resourceName}'.");
		using var reader = new StreamReader(stream);
		return reader.ReadToEnd();
	}
}
