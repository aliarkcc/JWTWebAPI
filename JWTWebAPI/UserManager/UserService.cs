using JWTWebAPI.Entity;
using System.Collections.Generic;
using System.Linq;

namespace JWTWebAPI.UserManager
{
    public class UserService : IUserService
    {
        public User AuthenticateUser(string email, string password)
        {
            return users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
        public List<OperationClaim> GetClaims(User user)
        {
            IEnumerable<OperationClaim> result = from operationClaim in operationClaims
                         join userOperationClaim in userOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();

        }
        private readonly List<User> users = new List<User>()
        {
            new User()
            {
                Id = 1,
                FirstName="Mehmet Ali",
                LastName="Arkac",
                Email="markac@developtica.com",
                Password="123123", //Burada Normalde Hashleme işlemi olması gerekli
            }
        };
        private readonly List<OperationClaim> operationClaims = new List<OperationClaim>()
        {
            new OperationClaim()
            {
                Id=1,
                Name="admin"
            }
        };
        private readonly List<UserOperationClaim> userOperationClaims = new List<UserOperationClaim>()
        {
            new UserOperationClaim()
            {
                Id=1,
                OperationClaimId=1,
                UserId=1
            }
        };
    }
}
