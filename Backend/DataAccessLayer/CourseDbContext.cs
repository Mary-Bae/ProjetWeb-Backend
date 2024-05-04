using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CourseDbContext : DbContext
    {
        public virtual DbSet<Course> Courses {get; set;} //Creation de table course
        public virtual DbSet<User> Users { get; set;} //Creation de table User
        public virtual DbSet<CourseStudent> CourseStudents { get; set;} //Creation de table CourseStudent
        public virtual DbSet<Role> Roles { get; set;} //Creation de table Role
        public virtual DbSet<Grade> Grades { get; set;} //Creation de table Grade
        public virtual DbSet<GradeStudent> GradeStudents { get; set;} //Creation de table GradeStudents
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
        {
        }
    }
}
