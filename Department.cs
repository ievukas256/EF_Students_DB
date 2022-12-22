using System;
using System.Collections.Generic;
using System.Linq;


namespace EF_Students
{
    public class Department
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<Lecture> Lectures { get; set; }
        public Department()
        {
        }
        public Department(string name)
        {
            Name = name;
            Students = new List<Student>();
            Lectures = new List<Lecture>();
        }
    }
}
