using Infrastructure.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.Exceptions;

namespace WebApi.Features.Product.Application;

public static class GetProductMetrics
{
    public class Command : IRequest<Result>
    {
        public long Id { get; set; }
    }

    public class Result
    {
        public long Id { get; set; }
        public long TotalSales { get; set; }
        public double Score { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly ShopDbContext _dbContext;
        public Handler(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result> Handle(Command queryRequest, CancellationToken cancellationToken)
        {
            var productDb = await _dbContext.Products
                .SingleOrDefaultAsync(product => product.Id == queryRequest.Id) ?? throw new ProductNotFoundException(queryRequest.Id);

            var result = productDb.Metrics.Adapt<Result>();

            return result;
        }
    }
}