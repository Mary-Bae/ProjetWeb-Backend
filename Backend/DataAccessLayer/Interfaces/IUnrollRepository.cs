using Domain;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IUnrollRepository
    {
        List<CourseStudentDTO> GetCoursesByStudent(int id);
        void AddUnrollement(int userId, int courseId);
        void DelUnrollement(int userId, int courseId);
        List<CourseStudentWithNameDTO> GetStudentsByCourse(int courseId);

    }
}
