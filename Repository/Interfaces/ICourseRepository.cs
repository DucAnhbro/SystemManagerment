
using BusinessObject.DTO;
using BusinessObject.Models;

namespace Repository.Interfaces
{
    public interface ICourseRepository
    {
        public IEnumerable<Course> GetAllCourseByStudentId(int studentId);

        List<Course> GetAllCourse();
        Course GetCourseById(int courseId);
        void InsertCourse(AddNewCourseDto course);
        void UpdateCourse(CourseDto course);
       void DeleteCourse(Course course);
    }
}
