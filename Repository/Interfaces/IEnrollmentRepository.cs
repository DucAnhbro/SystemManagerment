using BusinessObject.Models;

namespace Repository.Interfaces
{
    public interface IEnrollmentRepository
    {
        void DeleteEnrollment(Enrollment enrollment);
    }
}
