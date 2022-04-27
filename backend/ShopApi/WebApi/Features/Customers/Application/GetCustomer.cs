using Core.Domain.Entities;
using Infrastructure.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.Exceptions;
using WebApi.Features.Products.Application;

namespace WebApi.Features.Customers.Application;

public class GetCustomer
{
    public class Command : IRequest<Result>
    {
        public Guid Id { get; set; }
    }

    public class Result
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
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
            var customerDb = await _dbContext.Customers
                .SingleOrDefaultAsync(customer => customer.Id == request.Id, cancellationToken) ?? throw new InvalidCustomerException();

            return customerDb.Adapt<Result>();
        }
    }
}