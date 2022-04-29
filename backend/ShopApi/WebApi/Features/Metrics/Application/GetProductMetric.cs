using Core.Domain.Entities;
using Infrastructure.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Features.Metrics.Application;

public class GetProductMetric
{
    public class Command : IRequest<Result>
    {
    }

    public class Result
    {
        public double Score { get; set; }
    }


    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly ShopDbContext _dbContext;

        public Handler(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var productDb = await _dbContext.Products.Include(x => x.Metric).OrderByDescending(product => product.Id)
                .FirstAsync(cancellationToken);

            return productDb.Metric.Adapt<Result>();
        }
    }
}