using BusinessObject.DTO;
using BusinessObject.Models;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int userId);
        void DeleteUser(User user);
        void InsertUser(AddNewUserDto userDto);
        void UpdateUser(AddNewUserDto userDto);
        public User checkLogin(string email, string password);
        public string GetRoleByEmail(string email);
        public User GetUserByEmail(string email);
        List<Role> GetAllRoles();
        Role GetRoleById(int rid);
    }
}
