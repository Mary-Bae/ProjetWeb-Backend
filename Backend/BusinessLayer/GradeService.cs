using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Domain;
using ExceptionList;
using Microsoft.EntityFrameworkCore;
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

        public StudentGradeDTO? GetGradeByStudent(int Id)
        {
            return _gradeRepository.GetGradeByStudent(Id);
        }

        public void UpdateGradeStudent(int userId, int gradeId)
        {
            _gradeRepository.UpdGradeStudent(userId, gradeId);
        }



    }
}
