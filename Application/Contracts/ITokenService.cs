using Domain.Entities;

namespace Application.Contracts
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
