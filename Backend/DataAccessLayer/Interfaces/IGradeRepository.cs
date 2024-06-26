﻿using Domain;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IGradeRepository
    {
        IEnumerable<GradeDTO> GetAllGrades();
        StudentGradeDTO? GetGradeByStudent(int id);
        void UpdGradeStudent(int userId, int gradeId);
        void DelGradeStudent(int userId);
    }
}
