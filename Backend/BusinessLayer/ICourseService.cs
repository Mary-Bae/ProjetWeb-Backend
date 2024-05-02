using Domain;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ICourseService
    {
        IEnumerable<CourseDTO> GetAll();
        public CourseDTO? Get(int id);
        void AddCourse(CourseCreateDTO courseDto);
        void DeleteCourse(int id);
        void UpdateCourse(int id, CourseUpdateDTO courseDto);
    }
}
