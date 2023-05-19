using BusinessObject.DTO;
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
        public static void InsertUser(AddNewUserDto user)
        {
            try
            {
                using (var context = new PRN231_StudentMGTContext())
                {
                    var userEntity = new User()
                    {
                        RoleId = user.RoleId,
                        Username = user.Username,
                        Password = user.Password,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        DateOfBirth = user.DateOfBirth,
                        Gender = user.Gender,
                        Address = user.Address,
                        PhoneNumber = user.PhoneNumber,
                        Email = user.Email
                    };
                    context.Users.Add(userEntity);
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
                    context.Entry(user).State = EntityState.Modified;
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
                    user = context.Users.Where(u => u.Password.Equals(password) && u.Email.Equals(email)).FirstOrDefault()!;
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
                    return role;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static User GetUserByEmail(string email)
        {
            User user = new User();
            try
            {
                using (var context = new PRN231_StudentMGTContext())
                {
                    user = context.Users.Where(u => u.Email.Equals(email)).FirstOrDefault();
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteUser(User user)
        {
            try
            {
                using (var context = new PRN231_StudentMGTContext())
                {
                    //Todo: delete enrrolment 
                    var u = context.Users.SingleOrDefault(c => c.Id == user.Id);
                    var enrolment = context.Enrollments.SingleOrDefault(c => c.UserId == user.Id);
                    if(u!= null)
                    {
                       if(enrolment != null)
                        {
                            context.Enrollments.RemoveRange(enrolment);
                        }
                    }
                    context.Users.Remove(u);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception("Delete fail");
            }
        }
    }
}
