
using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Interfaces;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
   
    public class AdminController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository = new CourseRepository();

        public AdminController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public IActionResult GetAllCourse()
        {
            List<Course> courses = _courseRepository.GetAllCourse();
            List<CourseDto> courseDtos = new List<CourseDto>();
            foreach (var course in courses)
            {
                CourseDto courseDto = new CourseDto()
                {
                    Id = course.Id,
                    CourseCode = course.CourseCode,
                    CourseName = course.CourseName,
                    InstructorName = course.InstructorName,
                    Credits = course.Credits
                };
                courseDtos.Add(courseDto);
            }
            return Ok(courseDtos);
        }

        [HttpGet("{courseId}")]
        public IActionResult GetCourseById(int courseId)
        {
            Course course = _courseRepository.GetCourseById(courseId);
            CourseDto courseDto = new CourseDto()
            {
                Id = course.Id,
                CourseCode = course.CourseCode,
                CourseName = course.CourseName,
                InstructorName = course.InstructorName,
                Credits = course.Credits
            };
            return Ok(courseDto);
        }

        [HttpPost]
        public IActionResult InsertNewCourse(AddNewCourseDto course)
        {
            try
            {
                _courseRepository.InsertCourse(course);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCourse(CourseDto course)
        {
            try
            {
                _courseRepository.UpdateCourse(course);
            }
            catch (Exception )
            {
                throw new Exception("Update fail");
            }
            return Ok();
        }

        [HttpDelete("{courseId}")]
        public IActionResult DeleteCourse(int courseId)
        {
            var course = _courseRepository.GetCourseById(courseId);
            if (course == null)
            {
                return NotFound();
            }
            var enrollments = course.Enrollments.Where(a => a.CourseId == courseId).ToList();
            if(enrollments.Count == 0)
            {
                return BadRequest("Not found");
            }
            _courseRepository.DeleteCourse(course);

            return Ok();
        }
    }
}
