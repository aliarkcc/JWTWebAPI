using JWTWebAPI.Entity;

namespace JWTWebAPI.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
