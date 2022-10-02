using JWTWebAPI.Entity;

namespace JWTWebAPI.UserManager
{
    public interface IUserService
    {
        User AuthenticateUser(string firstName, string password);
        List<OperationClaim> GetClaims(User user);
    }
}