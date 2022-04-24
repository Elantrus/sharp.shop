using Infrastructure.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Features.Product.Application;

public static class GetLatestProduct
{
    public class Command : IRequest<Result>
    {
        
    }

    public class Result
    {
        public string Id { get; protected set; }
        public string Description { get; protected set; }
        public double Price { get; protected set; }
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
            var latestProduct = await _dbContext.Products
                .OrderByDescending(product => product.Id)
                .FirstAsync(cancellationToken);

            return latestProduct.Adapt<Result>();
        }
    }
}