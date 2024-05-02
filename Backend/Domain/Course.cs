using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Course
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Level Level { get; set; }
        public int LevelId { get; set; }
        public string Schedule { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }

    }
}
