using Azure.Storage.Blobs;
using Grpc.Core;
using Newtonsoft.Json;
using OnThisDay.TodayEventData.Models;
using OnThisDay.TodayEvents.Protos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnThisDay.TodayEvents.Services
{
    public class HeadlineService : Protos.HeadlineService.HeadlineServiceBase
    {
        private HttpClient httpClient;

        public HeadlineService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();

        }

        public override async Task<DownloadResponse> DownloadHeadlines(DownloadRequest request, ServerCallContext context)
        {
            int articlesFromYear = request.Year;
            var currentMonth = DateTime.Now.Month.ToString();

            var webRequest = await httpClient.GetAsync($"https://api.nytimes.com/svc/archive/v1/{articlesFromYear}/{currentMonth}.json?api-key={Startup.NytApiKey}");

            var content = webRequest.Content;
            var response = new DownloadResponse();
            var headlines = new List<TodayEventData.Models.Headline>();

            try
            {
                var jsonContent = JsonConvert.DeserializeObject<NYTDocs>(await content.ReadAsStringAsync());

                foreach (var headline in jsonContent.Response.Docs.Select(doc => doc.Headline))
                {

                    headlines.Add(headline);
                }
            }
            catch (JsonSerializationException ex)
            {
                Console.WriteLine(ex);
            }
            response.Headlines.AddRange(headlines.Select(Protos.Headline.FromRepositoryModel));
            return response;
        }
    }
}
