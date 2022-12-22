namespace EF_Students
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
        public Lecture()
        {
        }
        public Lecture(string name)
        {
            Name = name;
            Departments = new List<Department>();
        }
    }
}