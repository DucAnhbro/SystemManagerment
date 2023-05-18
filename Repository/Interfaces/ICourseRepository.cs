﻿
using BusinessObject.DTO;
using BusinessObject.Models;

namespace Repository.Interfaces
{
    public interface ICourseRepository
    {
        public IEnumerable<Course> GetAllCourseByStudentId(int studentId);

        List<Course> GetAllCourse();
        Course GetCourseById(int courseId);
        void InsertCourse(CourseDto course);
        void UpdateCourse(Course course);
       void DeleteCourse(Course course);
    }
}
