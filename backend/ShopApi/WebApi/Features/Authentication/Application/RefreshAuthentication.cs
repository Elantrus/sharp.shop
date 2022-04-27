using Core.Services;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.Exceptions;

namespace WebApi.Features.Authentication.Application;

public class RefreshAuthentication
{
    public class Command : IRequest<Result>
    {
        public Guid RefreshToken { get; set; }
        public string DeviceId { get; set; }
    }

    public class Result
    {
        public string Token { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly ShopDbContext _dbContext;
        private readonly ITokenService _tokenService;
        public Handler(ShopDbContext dbContext, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }
        
        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var customerDb = await _dbContext.Customers.SingleOrDefaultAsync(customer =>
                                 customer.RefreshToken == request.RefreshToken, cancellationToken)
                             ?? throw new RefreshAuthenticationFailedException();
            
            if(request.DeviceId != customerDb.DeviceId) throw new RefreshAuthenticationFailedException();
            
            if(customerDb.LastLoginDateTime?.AddDays(1) > DateTime.Now)  throw new RefreshAuthenticationFailedException();

            return new Result
            {
                Token = _tokenService.GenerateToken(customerDb)
            };
        }
    }

}