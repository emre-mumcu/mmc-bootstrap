using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using mmc.bootstrap.v5.Contexts;

namespace mmc.bootstrap.v5.Components.Carousel;

public class CarouselItem
{
	public string ImageUrl { get; set; } = null!;
	public string? Caption { get; set; }
	public string? Text { get; set; }
}

[HtmlTargetElement("mmc-carousel", TagStructure = TagStructure.NormalOrSelfClosing)]
public class CarouselTagHelper : TagHelper
{
	public List<CarouselItem>? Items { get; set; }
	public List<string>? Images { get; set; }
	public bool Indicators { get; set; } = false;
	public bool Fade { get; set; } = false;
	public bool Ride { get; set; } = false;
	public bool Dark { get; set; } = false;
	public int Interval { get; set; } = 0;

	public override void Process(TagHelperContext context, TagHelperOutput output)
	{
		string? carouselId = output.Attributes.FirstOrDefault(attribute => attribute.Name == "id")?.Value?.ToString();

		if (string.IsNullOrEmpty(carouselId))
		{
			carouselId = Guid.NewGuid().ToString();
			output.Attributes.Add("id", carouselId);
		}

		// context.Items.Add(typeof(CarouselContext), new CarouselContext() { Id = accordionId });
		context.Items[typeof(CarouselContext)] = new CarouselContext() { Id = carouselId };

		output.TagName = "div";

		output.TagMode = TagMode.StartTagAndEndTag;

		output.AddClass("carousel", HtmlEncoder.Default);

		output.AddClass("slide", HtmlEncoder.Default);
				
		output.AddClass(Dark ? "carousel-dark" : "", HtmlEncoder.Default);

		output.AddClass(Fade ? "carousel-fade" : "", HtmlEncoder.Default);

		if(Ride) output.Attributes.Add("data-bs-ride", "carousel");

		var innerContent = new TagBuilder("div");
		{
			innerContent.AddCssClass("carousel-inner");
		}

		if(Items == null && Images != null)
		{
			Items = Images.Select(i => new CarouselItem { ImageUrl = i, Caption = null, Text = null } ).ToList();
		} 

		if (Items != null)
		{
			if (Indicators)
			{
				var indicators = new TagBuilder("div");
				{
					indicators.AddCssClass("carousel-indicators");

					foreach (var (ci, index) in Items.Select((value, ci) => (value, ci)))
					{
						var indicatorButton = new TagBuilder("button");
						{
							indicatorButton.Attributes.Add("type", "button");
							indicatorButton.Attributes.Add("data-bs-target", $"#{carouselId}");
							indicatorButton.Attributes.Add("data-bs-slide-to", $"{index}");
							if(index==0)
							{
								indicatorButton.AddCssClass("active");
								indicatorButton.Attributes.Add("aria-current", "true");
							}
							indicatorButton.Attributes.Add("aria-label", $"Slide {index}");
						}

						indicators.InnerHtml.AppendHtml(indicatorButton);
					}
				}

				output.PreContent.AppendHtml(indicators);
			}

			foreach (var (ci, index) in Items.Select((value, ci) => (value, ci)))
			{
				var itemContent = new TagBuilder("div");
				{
					itemContent.AddCssClass("carousel-item");
					itemContent.AddCssClass(index == 0 ? "active" : "");
					itemContent.InnerHtml.AppendHtml(@$"<img src=""{ci.ImageUrl}"" class=""d-block w-100"" alt=""{ci.Caption ?? $"Image {index}"}"">");
					if(Interval > 0) itemContent.Attributes.Add("data-bs-interval", $"{Interval}");
					if(ci.Caption != null || ci.Text != null)
					{
						var caption = new TagBuilder("div");
						{
							caption.AddCssClass("carousel-caption");
							caption.AddCssClass("d-none");
							caption.AddCssClass("d-md-block");
							caption.InnerHtml.AppendHtml(@$"<h5>{ci.Caption}</h5>");
							caption.InnerHtml.AppendHtml(@$"<p>{ci.Text}</p>");
						}
						itemContent.InnerHtml.AppendHtml(caption);
					}
				}

				innerContent.InnerHtml.AppendHtml(itemContent);
			}
		}

		output.Content.AppendHtml(innerContent);

		var prevControl = new TagBuilder("button");
		{
			prevControl.AddCssClass("carousel-control-prev");

			prevControl.Attributes["type"] = "button";
			prevControl.Attributes["data-bs-target"] = $"#{carouselId}";
			prevControl.Attributes["data-bs-slide"] = $"prev";

			prevControl.InnerHtml.AppendHtml($@"<span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>");
			prevControl.InnerHtml.AppendHtml($@"<span class=""visually-hidden"">Previous</span>");
		}

		var nextControl = new TagBuilder("button");
		{
			nextControl.AddCssClass("carousel-control-next");

			nextControl.Attributes["type"] = "button";
			nextControl.Attributes["data-bs-target"] = $"#{carouselId}";
			nextControl.Attributes["data-bs-slide"] = $"next";

			nextControl.InnerHtml.AppendHtml($@"<span class=""carousel-control-next-icon"" aria-hidden=""true""></span>");
			nextControl.InnerHtml.AppendHtml($@"<span class=""visually-hidden"">Next</span>");
		}

		output.Content.AppendHtml(prevControl);
		output.Content.AppendHtml(nextControl);

	}
}