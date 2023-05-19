using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EnrollmentDao
    {
        public static void DeleteEnrollment(Enrollment enrollment)
        {
            try
            {
                using (var context = new PRN231_StudentMGTContext())
                {
                    var e = context.Enrollments.FirstOrDefault(c => c.UserId == enrollment.UserId);
                    if(e == null)
                    {
                        throw new Exception("not found");
                    }
                    context.Enrollments.Remove(e);
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
