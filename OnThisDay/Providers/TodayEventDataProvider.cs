using Grpc.Core;
using Grpc.Net.Client;
using OnThisDay.TodayEvents.Protos;
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
            string ServerAddress = "https://localhost:5001";

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


    }
}
