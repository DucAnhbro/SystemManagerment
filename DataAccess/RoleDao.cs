using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RoleDao
    {
        public static List<Role> GetAllRoles()
        {
            var listRoles = new List<Role>();
            try
            {
                using (var context = new PRN231_StudentMGTContext())
                {
                    listRoles = context.Roles.ToList();
                }
            }
            catch (Exception)
            {
                throw new Exception("Not found");
            }
            return listRoles;
        }
        public static Role GetRoleById(int roleId)
        {
            Role role = new Role();
            try
            {
                using (var context = new PRN231_StudentMGTContext())
                {
                    role = context.Roles.SingleOrDefault(x => x.Id == roleId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return role;
        }
    }
}
