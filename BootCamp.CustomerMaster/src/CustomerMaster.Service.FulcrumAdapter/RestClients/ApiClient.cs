﻿using System;
using System.Threading.Tasks;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;
using Xlent.Lever.Libraries2.Core.Logging;

namespace CustomerMaster.Service.FulcrumAdapter.RestClients
{
    /// <summary>
    /// Client for publishing events.
    /// </summary>
    public class ApiClient : BaseClient, IApiClient
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ApiClient(string baseUri) : base(baseUri, GetCredentials())
        {
        }

        private static ServiceClientCredentials GetCredentials()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task PublishAsync(Guid id, JObject eventBody)
        {
            var relativeUrl = $"api/Publish/{id}";
            await RestClient.PostAsync<string, JObject>(relativeUrl, eventBody);
        }

        /// <inheritdoc />
        public void Log(LogSeverityLevel logSeverityLevel, string message)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task LogAsync(LogInstanceInformation message)
        {
            var relativeUrl = "api/Logs";
            await RestClient.PostNoResponseContentAsync(relativeUrl, message);
        }
    }
}