using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Features.Metrics.Application;

public class UpdateProductMetricScore
{
    public class Command : IRequest
    {
        public long ProductId { get; set; }
        public int Score { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly ShopDbContext _dbContext;

        public Handler(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var productDb = await _dbContext.Products.Include(x => x.Metric)
                .SingleAsync(x => x.Id == request.ProductId, cancellationToken);

            productDb.Metric.Score = (productDb.Metric.Score + request.Score) / productDb.Reviews.Count;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}