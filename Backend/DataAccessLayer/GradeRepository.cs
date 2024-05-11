using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using ExceptionList;
using Models;

namespace DataAccessLayer
{
    public class GradeRepository : IGradeRepository
    {
        private readonly CourseDbContext _context;

        public GradeRepository(CourseDbContext dbContext)
        {
            _context = dbContext;
        }
        public IEnumerable<GradeDTO> GetAllGrades()
        {
            return _context.Grades
            .Select(g => new GradeDTO
            {
                Id = g.Id,
                GradeName = g.GradeName
            })
        .ToList();
        }

        public StudentGradeDTO? GetGradeByStudent(int id)
        {
            // Jointure externe entre Users et GradeStudents
            var student = (from u in _context.Users
                           join gs in _context.GradeStudents on u.Id equals gs.UserId into grades
                           from g in grades.DefaultIfEmpty()  // Inclut les étudiants même sans grade
                           where u.Id == id && u.Role.RoleName == "student"
                           select new StudentGradeDTO
                           {
                               UserId = u.Id,
                               Username = u.Username,
                               GradeName = g.Grade != null ? g.Grade.GradeName : null,
                               GradeId = g.Grade != null ? g.Grade.Id : 0
                           }).FirstOrDefault();

            return student;
        }

        public void UpdGradeStudent(int userId, int gradeId)
        {
            var gradeStudent = _context.GradeStudents.FirstOrDefault(gs => gs.UserId == userId);
            if (gradeStudent != null)
            {
                // Mise à jour du grade existant
                gradeStudent.GradeId = gradeId;
            }
            else
            {
                // Création d'un nouvel enregistrement de grade
                var newGradeStudent = new GradeStudent
                {
                    UserId = userId,
                    GradeId = gradeId
                };
                _context.GradeStudents.Add(newGradeStudent);
            }
            _context.SaveChanges();
        }
        public void DelGradeStudent(int userId)
        {
            var gradeStudent = _context.GradeStudents.FirstOrDefault(gs => gs.UserId == userId);
            if (gradeStudent != null)
            {
                _context.GradeStudents.Remove(gradeStudent);
                _context.SaveChanges();
            }
        }
    }
}
