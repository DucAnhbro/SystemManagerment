using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string? CourseCode { get; set; }
        public string? CourseName { get; set; }
        public string? InstructorName { get; set; }
        public int? Credits { get; set; }
    }
}
