using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual User? Student { get; set; }
    }
}
