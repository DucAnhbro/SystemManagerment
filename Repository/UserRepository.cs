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
        public void DeleteUser(User u) => UserDao.DeleteUser(u);
        public List<User> GetAllUsers() => UserDao.GetAllUsers();

        public User GetUserById(int uId) => UserDao.GetUserById(uId);
        public void InsertUser(User u) => UserDao.InsertUser(u);
        public void UpdateProduct(User u) => UserDao.UpdateUser(u);

        public List<Role> GetAllRoles() => RoleDao.GetAllRoles();

        public Role GetRoleById(int roleId) => RoleDao.GetRoleById(roleId);
    }
}
