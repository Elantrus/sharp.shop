using Core.Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Features.Reviews.Application;

public class CreateReview
{
    public class Command : IRequest
    {
        public Guid CustomerId { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
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
            var customerDb = await _dbContext.Customers.SingleOrDefaultAsync(customer => customer.Id == request.CustomerId, cancellationToken);
            var review = new Review(request.Score, request.Description, request.Title);

            review.Customer = customerDb;

            _dbContext.Reviews.Add(review);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}