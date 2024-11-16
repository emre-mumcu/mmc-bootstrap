using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

// https://github.com/ridercz/Altairis.TagHelpers

[HtmlTargetElement("assembly-version", TagStructure = TagStructure.NormalOrSelfClosing)]
public class AssemblyVersionTagHelper : TagHelper
{
    public DateTimeKind TimeKind { get; set; } = DateTimeKind.Utc;

    public string TimeFormat { get; set; } = "g";

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        /*         output.TagName = "span";
                output.TagMode = TagMode.SelfClosing;
                output.AddClass("badge", HtmlEncoder.Default);
                output.AddClass("text-bg-light", HtmlEncoder.Default); */

        output.Content.AppendHtml("Additional custom content");

        /*         var path = System.Reflection.Assembly.GetEntryAssembly()?.Location;

                if(!string.IsNullOrEmpty(path))
                {
                    FileInfo fi = new FileInfo(path);
                    output.Content.SetContent(@$"{fi.LastWriteTimeUtc.ToString("yyyyMMdd-HHmmss")}-{fi.Length}");
                }
                else
                {
                    output.Content.SetContent(System.Reflection.Assembly.GetEntryAssembly()?.GetName()?.Version?.ToString());
                } */
    }
}