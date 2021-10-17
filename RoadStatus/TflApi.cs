using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;
using RoadStatus.Entities;

namespace RoadStatus
{
    public class TflApi
    {
        private Config _config;
        public TflApi(Config config)
        {
            _config = config;
        }

        public RoadResponse GetRoadStatus(string roadName)
        {
            roadName = roadName.ToUpper();
            var client = new RestClient("https://api.tfl.gov.uk/Road/");

            var request = new RestRequest(roadName, Method.GET, DataFormat.Json);

            request = AddApiParameters(request);

            var response = client.Get<List<RoadResponse>>(request);

            if (response.IsSuccessful)
            {
                return response.Data[0];
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception($"{roadName} is not a valid road");
            }

            throw new Exception($"There was an error while trying to retrieve the status for the {roadName}. {response.StatusDescription}");
        }

        private RestRequest AddApiParameters(RestRequest request)
        {
            request.AddQueryParameter("app_id", _config.AppId);
            request.AddQueryParameter("app_key", _config.ApiKey);

            return request;
        }
    }
}
