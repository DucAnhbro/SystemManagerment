using BusinessObject.Models;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int uId);
        void DeleteUser(User user);
        void InsertUser(User user);
        void UpdateProduct(User user);
        public User checkLogin(string email, string password);
        public string GetRoleByEmail(string email);
        public User GetUserByEmail(string email);
        List<Role> GetAllRoles();
        Role GetRoleById(int rid);
    }
}
