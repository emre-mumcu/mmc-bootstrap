using mmc.bootstrap.v5.Components.Carousel;

namespace mmc.bootstrap.demo.AppLib;

public class MockDataProvider
{
	public List<CarouselItem> CarouselItems => new List<CarouselItem>() {
		new CarouselItem { 
			ImageUrl="https://dummyimage.com/qvga/b/c&text=Image1", 
			Caption="First slide label", 
			Text="Some representative placeholder content for the first slide."
		},
		new CarouselItem { 
			ImageUrl="https://dummyimage.com/qvga/b/c&text=Image2", 
			Caption="Second slide label",
			Text="Some representative placeholder content for the second slide."
		},
		new CarouselItem { 
			ImageUrl="https://dummyimage.com/qvga/b/c&text=Image3", 
			Caption="Third slide label",
			Text="Some representative placeholder content for the third slide."
		},
	};

	public List<string> CarouselImages => new List<string>() {
		"https://dummyimage.com/qvga/b/c&text=Image1",
		"https://dummyimage.com/qvga/b/c&text=Image2",
		"https://dummyimage.com/qvga/b/c&text=Image3",
	};
}