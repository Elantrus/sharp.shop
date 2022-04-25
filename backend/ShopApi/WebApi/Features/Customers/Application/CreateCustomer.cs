using Core.Domain.Entities;
using Infrastructure.Data;
using MediatR;
using WebApi.Exceptions;

namespace WebApi.Features.Customers.Application;

public class CreateCustomer
{
    public class Command : IRequest
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
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
            var emailExistsInCustomers = _dbContext.Customers.Any(customer => customer.Email.Equals(request.Email.ToLower()));

            if (emailExistsInCustomers) throw new EmailAlreadyExistsException();

            var createdCustomer = new Customer(request.Name, request.SurName, request.Email, request.Password);
            
            _dbContext.Add(createdCustomer);

            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}