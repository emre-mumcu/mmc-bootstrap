using System;

namespace mmc.toolkit.Extensions.Common;

public static class FileExtensions
{
	public static string GetStringContent(this FileInfo file)
	{
		if(file.Exists)
		{
			// return new StreamReader(file.FullName).ReadToEnd(); // Locks the file!!!
			return System.IO.File.ReadAllText(file.FullName);
		}
		else
		{
			// return string.Empty;
			return $"File not found: {file.FullName}";
		}
	}
}
