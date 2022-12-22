using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Students
{
    public class DepartmentRepository
    {
        DepartmentContext context = new DepartmentContext();
       public string ShowDepartmentStudents(int depId)
        {
            Console.WriteLine($"Students of department {depId}:");
            var student = context.Students.Single(s => s.DepartmentId == depId).FullName;
            foreach (var item in student)
            {
                Console.WriteLine(item);
            }
            return student;
        }
    }
}
