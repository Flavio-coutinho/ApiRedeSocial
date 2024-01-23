using ApiRedeSocial.Models;

namespace ApiRedeSocial.Repository
{
    public interface IUserRepository
    {
        public void Save(User user);

        public bool VerifyEmail(string email);
        User GetUserByLoginPassword(string email, string password);
        User GetUserById(int id);
        public void RefreshUser(User user);
        List<User> GetUserName(string name);
    }
}
