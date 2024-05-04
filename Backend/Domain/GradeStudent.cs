using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GradeStudent
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Grade Grade { get; set; }
        public int GradeId { get; set; }
    }
}
