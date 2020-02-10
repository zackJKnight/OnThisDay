using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using OnThisDay.TodayEventData.Models;
using OnThisDay.TodayEvents.Protos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnThisDay.TodayEvents.Services
{
    public class TodayEventService : Protos.TodaysEvents.TodaysEventsBase
    {
        private readonly ITodayEventRepository _repository;

        public TodayEventService(ITodayEventRepository repository)
        {
            _repository = repository;
        }

        [Authorize]
        public override async Task<GetResponse> Get(GetRequest request, ServerCallContext context)
        {
            if (string.IsNullOrEmpty(request.todayEventName)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Today Event Name must be a valid string."));
            }

            var portfolio = await _repository.GetTodayEventByNameAsync(request.todayEventName);

            return new GetResponse
            {
                TodaysEvents = TodaysEvents.FromRepositoryModel(portfolio)
            };
        }

        public override async Task<GetAllResponse> GetAll(GetAllRequest request, ServerCallContext context)
        {

            var todayEvents = await _repository.GetAllAsync(request.TodaysEventsId);

            var response = new GetAllResponse();
            response.TodayEvents.AddRange(todayEvents.Select(TodaysEvents.FromRepositoryModel));

            return response;
        }
    }
}
