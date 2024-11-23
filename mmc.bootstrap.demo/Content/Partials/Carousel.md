# Properties

The Carousel component has several properties as shown below.

##### dark Property (`bool`)
Use dark property to change the carousel for darker controls, indicators, and captions. Controls are inverted compared to their default white fill with the filter CSS property.

##### items Property (`List<CarouselItem>?`)
This is the main data source for Carousel which is of type `List<CarouselItem>?`. The list element should contain `CarouselItem` objects which holds the ImageUrl, Caption and Text properties.

##### images Property (`List<string>?`)
This is the auxilary data source for Carousel which is of type `List<string>?`. The list element should contain urls of the images.

##### indicators Property  (`bool`)
You can add indicators to the carousel, alongside the previous/next controls. The indicators let users jump directly to a particular slide.

##### fade Property  (`bool`)
Fade property lets the carousel to animate slides with a fade transition instead of a slide.

##### ride Property  (`bool`)
You can make your carousels autoplay on page load by setting the ride property to set true.

##### interval Property (`int`)
Interval property is to change the amount of time to delay between automatically cycling to the next item.