using Core.Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.Exceptions;
using WebApi.Features.Metrics.Application;

namespace WebApi.Features.Reviews.Application;

public class CreateReview
{
    public class Command : IRequest
    {
        public Guid CustomerId { get; set; }
        public long ProductId { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly ShopDbContext _dbContext;
        private readonly IMediator _mediator;
        public Handler(ShopDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }
        
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var customerDb = await _dbContext.Customers.SingleOrDefaultAsync(customer => customer.Id == request.CustomerId, cancellationToken) ?? throw new InvalidCustomerException();

            var productDb = await _dbContext.Products.OrderByDescending(product => product.Id).FirstAsync(cancellationToken) ?? throw new ProductNotFoundException(request.ProductId);
            
            var review = new Review(request.Score, request.Description, request.Title)
            {
                Customer = customerDb,
                Product = productDb
            };

            _dbContext.Reviews.Add(review);

            await _dbContext.SaveChangesAsync(cancellationToken);

            var updateScoreCommand = new UpdateProductMetricScore.Command()
            {
                ProductId = productDb.Id,
                Score = request.Score
            };

            await _mediator.Send(updateScoreCommand, cancellationToken);

            return Unit.Value;
        }
    }
}