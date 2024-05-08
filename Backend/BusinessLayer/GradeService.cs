using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Domain;
using Models;

namespace BusinessLayer
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }
        public IEnumerable<GradeDTO> GetAllGrades()
        {
            return _gradeRepository.GetAllGrades();
        }

        public StudentGradeDTO GetGradeByStudent(int Id)
        {
            return _gradeRepository.GetGradeByStudent(Id);
        }
        public void AddGradeStudent(UpdStudentGradeDTO studentGrade)
        {
           
            var user = new UpdStudentGradeDTO
            {
                UserId = studentGrade.UserId,
                GradeId = studentGrade.GradeId,
            };

            _gradeRepository.AddGradeStudent(user);
        }
    }
}
