﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IGradeService
    {
        IEnumerable<GradeDTO> GetAllGrades();
        StudentGradeDTO? GetGradeByStudent(int Id);
        void UpdateGradeStudent(int userId, int gradeId);
    }
}
