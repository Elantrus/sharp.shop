using Core.Domain.Entities;

namespace Core.Services;

public interface ITokenService
{
    string GenerateToken(Customer customerDb);
}