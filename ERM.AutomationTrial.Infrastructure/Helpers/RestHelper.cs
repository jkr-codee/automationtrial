using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERM.AutomationTrial.Infrastructure.Entity;
using Newtonsoft.Json;
using RestSharp;


namespace ERM.AutomationTrial.Infrastructure.Helpers
{
    /// <summary>
    /// Rest API Helper class to set the endpoint using Restsharp client and
    /// get the JSON data from the API and deserialize using newtonsoft json serializer
    /// </summary>
    public class RestHelper
    {
        public RestClient _restClient;

        /// <summary>
        /// Sets the endpoint for restsharp client
        /// </summary>
        /// <param name="endpointUrl">Rest API endpoint url</param>
        public void SetEndpoint(string endpointUrl)
        {
            _restClient = new RestClient(endpointUrl);
        }

        /// <summary>
        /// Get the data from REST API and deserialize using type T
        /// </summary>
        /// <typeparam name="T">Generic type T</typeparam>
        /// <returns>Deserialized List of objects of type T</returns>
        public List<T> GetData<T>()
        {
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = _restClient.Execute(request);
            return JsonConvert.DeserializeObject<List<T>>(response.Content);
        }

    }
}
