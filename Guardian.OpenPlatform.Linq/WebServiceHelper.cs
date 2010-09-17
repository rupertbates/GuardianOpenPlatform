using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.OpenPlatform.Linq.Results;
using Guardian.OpenPlatform.Results;

namespace Guardian.OpenPlatform.Linq
{
        internal static class WebServiceHelper
        {

            internal static Content[] GetContent(List<string> searchTerms)
            {
                // Limit the total number of Web service calls.
                
            }

            private static Place[] CallGetPlaceListMethod(string location)
            {
                TerraServiceSoapClient client = new TerraServiceSoapClient();
                PlaceFacts[] placeFacts = null;

                try
                {
                    // Call the Web service method "GetPlaceList".
                    placeFacts = client.GetPlaceList(location, numResults, mustHaveImage);

                    // If there are exactly 'numResults' results, they are probably truncated.
                    if (placeFacts.Length == numResults)
                        throw new Exception("The results have been truncated by the Web service and would not be complete. Please try a different query.");

                    // Create Place objects from the PlaceFacts objects returned by the Web service.
                    Place[] places = new Place[placeFacts.Length];
                    for (int i = 0; i < placeFacts.Length; i++)
                    {
                        places[i] = new Place(
                            placeFacts[i].Place.City,
                            placeFacts[i].Place.State,
                            placeFacts[i].PlaceTypeId);
                    }

                    // Close the WCF client.
                    client.Close();

                    return places;
                }
                catch (TimeoutException timeoutException)
                {
                    client.Abort();
                    throw;
                }
                catch (System.ServiceModel.CommunicationException communicationException)
                {
                    client.Abort();
                    throw;
                }
            }
        }
    
}
