using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Students
{
    public class Student
    {
        public int Id { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public string FullName { get; set; }
        public string City { get; set; }
        public int Phone { get; set; }
        public Student()
        {
        }
        public Student(string fullName, string city, int phone)
        {
            FullName = fullName;
            City = city;
            Phone = phone;
        }
    }
}