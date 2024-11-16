using System.Text.RegularExpressions;

namespace mmc.toolkit.Extensions.Common;

public static class StringExtensions
{
    /// <summary>
    /// Converts a string to kebab case string
    /// Uppercase abbreviations are NOT allowed
    /// </summary>
    /// <param name="str">SampleText</param>
    /// <returns>Sample-Text</returns>
    public static string KebabCase(this string str)
    {
        return string.Join("-", Regex.Split(str, @"(?<!^)(?=[A-Z])"));
    }

    /// <summary>
    /// Converts a string to kebab case string
    /// Uppercase abbreviations are allowed
    /// </summary>
    /// <param name="str">SampleText</param>
    /// <returns>Sample-Text</returns>
    public static string KebabCaseABBV(this string str)
    {
        return string.Join("-", Regex.Split(str, @"(?<!^)(?=[A-Z](?![A-Z]|$))"));
    }

    /// <summary>
    /// Converts a string to a human readable string with spaces
    /// Uppercase abbreviations are NOT allowed
    /// </summary>
    /// <param name="str">SampleText</param>
    /// <returns>Sample Text</returns> 
    public static string SentenceCase(this string str)
    {
        return string.Join(" ", Regex.Split(str, @"(?<!^)(?=[A-Z])"));
    }

    /// <summary>
    /// Converts a string to a human readable string with spaces
    /// Uppercase abbreviations are allowed
    /// </summary>
    /// <param name="str">SampleText</param>
    /// <returns>Sample Text</returns>
    public static string SentenceCaseABBV(this string str)
    {
        return string.Join(" ", Regex.Split(str, @"(?<!^)(?=[A-Z](?![A-Z]|$))"));
    }
}


/* Sourced from https://stackoverflow.com/questions/4488969/split-a-string-by-capital-letters.
var r = new Regex(@"(?<=[A-Z])(?=[A-Z][a-z]) | (?<=[^A-Z])(?=[A-Z]) | (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);
return r.Replace(s, " ");
*/