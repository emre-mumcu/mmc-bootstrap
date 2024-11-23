using System;
using Markdig;
using Markdig.Renderers;

namespace mmc.toolkit.Extensions.Common;

// dotnet add package Markdig
public static class MarkdownExtensions
{
    public static string Markdown2Html(this FileInfo file)
    {
		if (file.Exists)
		{
			// string content = new StreamReader(file.FullName).ReadToEnd(); // Locks the file!!!
			string content = System.IO.File.ReadAllText(file.FullName);

			var pipeline = new MarkdownPipelineBuilder()
				.UseAdvancedExtensions()
				.Build();

			return Markdown.ToHtml(content, pipeline);
		}
		else
		{
			// return string.Empty;
			return $"File not found: {file.FullName}";
		}
    }



    /// <summary>
    /// Allows the ImplicitParagraph property to be set by the user
    /// </summary>
    public static string Markdown2HtmlImplicit(this FileInfo file)
    {
		if (file.Exists)
		{
			// string content = new StreamReader(file.FullName).ReadToEnd(); // Locks the file!!!
			string content = System.IO.File.ReadAllText(file.FullName);

			var pipeline = new MarkdownPipelineBuilder()
				.UseAdvancedExtensions()
				.Use<ImplicitParagraphExtension>()
				.Build();

			using StringWriter writer = new StringWriter();
			{
				HtmlRenderer renderer = new HtmlRenderer(writer);
				renderer.ImplicitParagraph = true;
				pipeline.Setup(renderer);
				renderer.Render(Markdown.Parse(content, pipeline));
				writer.Flush();

				return writer.ToString();
			}
		}
		else
		{
			// return string.Empty;
			return $"File not found: {file.FullName}";
		}
    }
}

public class ImplicitParagraphExtension : IMarkdownExtension
{
    /*  
        // either   
        var builder = new MarkdownPipelineBuilder();
        builder.Extensions.Add(new MyParagraphExtension());
        var pipeline = builder.Build(); 

        // or
        var pipeline = new MarkdownPipelineBuilder()
        .UseAdvancedExtensions()
        .Use<ImplicitParagraphExtension>()
        .Build();
    */

    public void Setup(MarkdownPipelineBuilder pipeline) 
    { 
        
    }

    public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
    {
        
    }
}
