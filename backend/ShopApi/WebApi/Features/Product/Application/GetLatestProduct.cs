using MediatR;

namespace WebApi.Features.Product.Application;

public static class GetLatestProduct
{
    public class Command : IRequest<Result>
    {
        
    }

    public class Result
    {
        public string ProductId { get; protected set; }
        public string ProductDescription { get; protected set; }
        public double ProductPrice { get; protected set; }
    }

    public class Handler : IRequestHandler<Command, Result>
    {
        public Task<Result> Handle(Command queryRequest, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}