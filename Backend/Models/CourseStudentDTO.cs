using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CourseStudentDTO
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
    }

    public class CourseStudentWithNameDTO
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public string Username { get; set; }
        public string CourseName { get; set; }
    }
}
