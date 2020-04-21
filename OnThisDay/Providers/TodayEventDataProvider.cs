using Grpc.Core;
using Grpc.Net.Client;
using OnThisDay.TodayEvents.Protos;
using OnThisDay.WPFClient.Helpers;
using OnThisDay.WPFClient.Providers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnThisDay.WPFClient.Providers
{
    public class TodayEventDataProvider : IDataProvider
    {
        private string _dataProviderErrorMessage;
        private bool _dataProviderErrorIsVisible;
        private object _dataProviderDefaultErrorMessage;

        public List<TodayEventLookup> TodayEventLookups { get; }

        public TodayEventDataProvider()
        {
            TodayEventLookups = new List<TodayEventLookup>();
        }

        public async Task<TodayEventLookup> GetTodayEventByName(string name)
        {
            if (!TodayEventLookups.Any())
            {
                TodayEventLookups.AddRange(await this.GetEventsFromFileAsync().ConfigureAwait(false));
            }
            return TodayEventLookups.Where(todayEvent => todayEvent.Name == name).FirstOrDefault();
        }
        public async Task<IEnumerable<TodayEventLookup>> GetEventsFromFileAsync()
        {
            string ServerAddress = Environment.GetEnvironmentVariable("SERVER_ADDRESS");

            var channel = GrpcChannel.ForAddress(ServerAddress);
            var todayEvents = new TodayEventsService.TodayEventsServiceClient(channel);

            try
            {
                var request = new GetAllRequest();
                var response = await todayEvents.GetAllAsync(request);
                foreach (var todayEvent in response.TodayEvents)
                {
                    TodayEventLookups.Add(new TodayEventLookup()
                    {
                        Name = todayEvent.Name,
                        Description = todayEvent.Description,
                        Detail = todayEvent.Detail
                    });
                }
            }
            catch (RpcException e)
            {
                _dataProviderErrorMessage = $"{_dataProviderDefaultErrorMessage}{Environment.NewLine}{e.ToString()}";
                _dataProviderErrorIsVisible = true;
            }

            return TodayEventLookups; 
        }

        public async Task<IEnumerable<TodayEventLookup>> DownloadHeadlinesAsync(int selectedYear = 1980)
        {
            var result = new List<TodayEventLookup>();
            string ServerAddress = Environment.GetEnvironmentVariable("SERVER_ADDRESS");

            var channel = GrpcChannel.ForAddress(ServerAddress);
            var headlineClient = new HeadlineService.HeadlineServiceClient(channel);

            try
            {
                var request = new DownloadRequest();
                request.Year = selectedYear;

                var response = await headlineClient.DownloadHeadlinesAsync(request);
                foreach (var headline in response.Headlines)
                {
                    result.Add(new TodayEventLookup
                    {
                        Name = $"{headline.Main.Truncate(15)}...",
                        Description = headline.Main,
                        Detail = headline.Pubdate,
                        Id = new Random().Next(0, int.MaxValue)
                    });
                }
            }
            catch
            {
                throw;
            }
            return result;
            
        }
    }
}
