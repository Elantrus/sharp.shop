using Core.Domain.Entities;
using Infrastructure.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Features.Reviews.Application;

public class GetReviews
{
    public class Command : IRequest<Result>
    {
        
    }

    public class Result
    {
        public IReadOnlyCollection<ReviewResult> Reviews { get; set; }
    }

    public class ReviewResult
    {
        public long Id { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string CustomerName { get; set; }
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
            var reviewsDb = await _dbContext.Reviews
                .Include(x => x.Customer)
                .ToListAsync(cancellationToken);
            
            TypeAdapterConfig<Review, ReviewResult>
                .NewConfig()
                .Map(dest => dest.CustomerName,
                    src => $"{src.Customer.Name} {src.Customer.SurName}");
            
            return new Result
            {
                Reviews = reviewsDb.Adapt<IReadOnlyCollection<ReviewResult>>()
            };
        }
    }
}