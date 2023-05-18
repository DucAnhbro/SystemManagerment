using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDao
    {
        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                using(var context = new PRN231_StudentMGTContext())
                {
                    users = context.Users.Include(x => x.Role).ToList();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return users;
        }

        public static User GetUserById(int userId)
        {
            User user = new User();
            try
            {
                using (var context = new PRN231_StudentMGTContext())
                {
                    user = context.Users.Include(x => x.Role).FirstOrDefault(x => x.Id == userId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
        public static void InsertUser(User user)
        {
            try
            {
                using (var context = new PRN231_StudentMGTContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception("Add fail");
            }
        }
        public static void UpdateUser(User user)
        {
            try
            {
                using (var context = new PRN231_StudentMGTContext())
                {
                    context.Entry<User>(user).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception("Update fail");
            }
        }
        //TOFIX
       
        public static User checkLogin(string email, string password)
        {
            User user = new User();
            try
            {
                using (var context = new PRN231_StudentMGTContext())
                {
                    user = context.Users.Where(u => u.Password.Equals(password) && u.Email.Equals(email)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public static string GetRoleByEmail(string email)
        {
            string role = "";
            try
            {
                using (var context = new PRN231_StudentMGTContext())
                {
                    role = context.Users.Include(u => u.Role).Where(u => u.Email.Equals(email)).Select(u => u.Role.Name).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return role;
        }

        public static User GetUserByEmail(string email)
        {
            User user = new User();
            try
            {
                using (var context = new PRN231_StudentMGTContext())
                {
                    user = context.Users.Where(u => u.Email.Equals(email)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
    }
}
