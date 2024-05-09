using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UnrollService : IUnrollService
    {
        private readonly IUnrollRepository _unrollRepository;
        public UnrollService(IUnrollRepository unrollRepository)
        {
            _unrollRepository = unrollRepository;
        }
        public List<CourseStudentDTO> GetCoursesByStudent(int id)
        {
            return _unrollRepository.GetCoursesByStudent(id);
        }

        public void AddUnrollement(int userId, int courseId)
        {
                _unrollRepository.AddUnrollement(userId, courseId);
        }
    }
}
