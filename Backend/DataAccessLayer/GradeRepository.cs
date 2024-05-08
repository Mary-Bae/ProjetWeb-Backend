using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
