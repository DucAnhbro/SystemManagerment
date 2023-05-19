using BusinessObject.Models;
using DataAccess;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        public void DeleteEnrollment(Enrollment enrollment) => EnrollmentDao.DeleteEnrollment(enrollment);
    }
}
