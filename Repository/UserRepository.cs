using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess;
using Repository.Interfaces;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        public User checkLogin(string email, string password) => UserDao.checkLogin(email, password);

        public string GetRoleByEmail(string email) => UserDao.GetRoleByEmail(email);

        public User GetUserByEmail(string email) => UserDao.GetUserByEmail(email);
        public void DeleteUser(User user) => UserDao.DeleteUser(user);
        public List<User> GetAllUsers() => UserDao.GetAllUsers();

        public User GetUserById(int userId) => UserDao.GetUserById(userId);

        public void InsertUser(AddNewUserDto userDto) => UserDao.InsertUser(userDto);
        public void UpdateUser(User user) => UserDao.UpdateUser(user);

        public List<Role> GetAllRoles() => RoleDao.GetAllRoles();

        public Role GetRoleById(int roleId) => RoleDao.GetRoleById(roleId);
    }
}
