using System;
using System.Collections.Generic;
using System.Text;

namespace OnThisDay.TodayEvents.Services
{
    public class TodayEventService : Protos.
    {
        ]
        public override async Task<GetResponse> Get(GetRequest request, ServerCallContext context)
        {
            if (!Guid.TryParse(request.TraderId, out var traderId))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "traderId must be a UUID"));
            }

            var portfolio = await _repository.GetAsync(traderId, request.PortfolioId);

            return new GetResponse
            {
                Portfolio = Portfolio.FromRepositoryModel(portfolio)
            };
        }

        public override async Task<GetAllResponse> GetAll(GetAllRequest request, ServerCallContext context)
        {
            if (!Guid.TryParse(request.TraderId, out var traderId))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "traderId must be a UUID"));
            }

            var portfolios = await _repository.GetAllAsync(traderId);

            var response = new GetAllResponse();
            response.Portfolios.AddRange(portfolios.Select(Portfolio.FromRepositoryModel));

            return response;
        }
    }
}
