using Domain;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ICourseRepository
    {
        IEnumerable<CourseDTO> GetAll();
        CourseDTO? Get(int id);
        Course? GetCourseForUpdate(int id);
        void AddCourse(Course course);
        void DeleteCourse(int id);
        void UpdateCourse(Course course);

    }
}
