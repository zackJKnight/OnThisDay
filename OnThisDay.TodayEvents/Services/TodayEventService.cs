using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using OnThisDay.TodayEventData;
using OnThisDay.TodayEvents.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnThisDay.TodayEvents.Services
{
    public class TodayEventService : Protos.TodayEventsService.TodayEventsServiceBase
    {
        private readonly ITodayEventRepository _repository;

        public TodayEventService(ITodayEventRepository repository)
        {
            _repository = repository;
        }

       // [Authorize]
        public override async Task<GetAllResponse> GetAll(GetAllRequest request, ServerCallContext context)
        {
            var today = await _repository.GetEventsFromFileAsync(request.TodayEventListId);

            var response = new GetAllResponse();
            response.Today = new Today();

            response.Today.Id = today.Id;
            response.Today.TodayEventListId = today.TodayEventListId.ToString();
            response.Today.TodayEvents.AddRange(today.TodayEventList.Select(TodayEvent.FromRepositoryModel));

            return response;
        }
    }
}
