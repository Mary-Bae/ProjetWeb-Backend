﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StudentGradeDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string GradeName { get; set; }
        public int GradeId { get; set; }
    }
}
