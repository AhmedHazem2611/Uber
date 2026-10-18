using Uber.Models;

namespace Uber.Repos
{
    public interface IAuthRepo : IGenericRepo<User>
    {
        public string Login(User User);
        public User GetByName(string name);
    }
}
