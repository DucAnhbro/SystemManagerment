﻿using BusinessObject.Models;
using DataAccess;
using Repository.Interfaces;

namespace Repository
{
    public class CourseRepository :ICourseRepository
    {
        public void DeleteCourse(Course course) => CourseDao.DeleteCourse(course);

        public List<Course> GetAllCourse() => CourseDao.GetAllCourse();

        public IEnumerable<Course> GetAllCourseByStudentId(int studentId) => CourseDao.GetAllCourseByStudentId(studentId);


        public Course GetCourseById(int courseId) => CourseDao.GetCourseById(courseId);

        public void InsertCourse(Course course) => CourseDao.SaveCourse(course);

        public void UpdateCourse(Course course) => CourseDao.UpdateCourse(course);
    }
}
