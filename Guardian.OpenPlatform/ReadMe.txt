A .Net client library for the Guardian Content API

Example usage:

var contentApi = new OpenPlatformSearch();
var response = contentApi.ContentSearch(new ContentSearchParameters
            {
                TagFilter = new List<string> { "tone/reviews" },  //reviews only
                ShowFields = new List<string> { "show-fields=body,star-rating" },
                ShowTags = new List<string> { "all" },
                From = from,
                PageSize = _apiPageSize,
                PageIndex = page

            });

foreach (var content in response.Results)
{
    Console.WriteLine(content.WebTitle);
}


Check the unit tests for more detailed usage or contact me via github.