using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class CourseDao
    {
        public static List<Course> GetAllCourse()
        {
            List<Course> list = new List<Course>();
            try
            {
                using(var context = new PRN231_StudentMGTContext())
                {
                    var courses = context.Courses.Include(c => c.Enrollments).Include(u => u.Users).ToList();
                    foreach (var c in courses)
                    {
                        list.Add(c);
                    }
                }
            }catch(Exception)
            {
                throw new Exception("Not found");
            }
            return list;
        }

        public static Course GetCourseById(int id) 
        {
            Course course = new Course();
            try
            {
                using (var context = new PRN231_StudentMGTContext())
                {
                    course = context.Courses.Include(e => e.Enrollments).Where(c => c.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return course;
        }

        public static void SaveCourse(CourseDto course)
        {
            try
            {
                using (var context = new PRN231_StudentMGTContext())
                {
                    var courseEntity = new Course() 
                    {
                        Id = course.Id,
                        CourseCode = course.CourseCode,
                        CourseName = course.CourseName,
                        InstructorName = course.InstructorName,
                        Credits = course.Credits
                    };
                    context.Courses.Add(courseEntity);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception("Save fail");
            }
        }

        public static void UpdateCourse(Course course)
        {
            try
            {
                using (var context = new PRN231_StudentMGTContext())
                {
                    context.Entry<Course>(course).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception("Update fail");
            }
        }

        public static IEnumerable<Course> GetAllCourseByStudentId(int studentId)
        {
            List<Course> list = new List<Course>();
            try
            {
                using (var context = new PRN231_StudentMGTContext())
                {
                    var user = context.Users.Where(u => u.Id == studentId).FirstOrDefault();
                    var courses = context.Courses.Include(c => c.Enrollments).Include(u => u.Users).Where(u => u.Users.Contains(user)).ToList();
                    foreach (var c in courses)
                    {
                        list.Add(c);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Not found");
            }
            return list;
        }

        public static void DeleteCourse(Course course)
        {
            try
            {
                using (var context = new PRN231_StudentMGTContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var c = context.Courses.Include(c => c.Users).Include(e => e.Enrollments).SingleOrDefault(c => c.Id == course.Id);

                        var userCourse = c.Users.ToList();
                        foreach (var uc in userCourse)
                        {
                            c.Users.Remove(uc);
                        }
                        var enrollmentCourse = context.Enrollments.Where(a => a.CourseId == course.Id).ToList();
                        foreach (var ac in enrollmentCourse)
                        {
                            context.Enrollments.Remove(ac);
                        }
                        context.Courses.Remove(c);

                        if (context.SaveChanges() > 0)
                        {
                            transaction.Commit();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Delete fail");
            }
        }
    }
}
