namespace Models
{
    public class CourseDTO
    {
        public string Name { get; set; }
        public string LevelName { get; set; }
        public string Schedule { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
    }
    public class CourseCreateDTO
    {
        public string Name { get; set; }
        public int LevelId { get; set; }
        public string Schedule { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
    }
    public class CourseUpdateDTO
    {
        public string Name { get; set; }
        public int LevelId { get; set; }
        public string Schedule { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
    }
}