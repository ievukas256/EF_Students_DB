using EF_Students;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;

DepartmentContext context = new DepartmentContext();
//CreateNewDepartment();
//AddToDepartment();
//CreateLectureAndAddingToDepartment(5);
//CreateStudentAddingDepartmentAndLectures();
//UpdateStudentDepartment();

//ShowDepartmentStudents(6);
//ShowDepartmentLectures();
//ShowLecturesByStudent();


void CreateNewDepartment()
{
    var department = new Department("IT");

    department.Lectures.Add(new Lecture { Name = "C# programming" });
    department.Lectures.Add(new Lecture { Name = "Java"  });
    department.Lectures.Add(new Lecture { Name = "UI" });
    department.Students.Add(new Student { FullName = "Julius Balsys", City = "Vilnius", Phone = 860584512 });
    department.Students.Add(new Student { FullName = "Inga Baldziute", City = "Kaunas", Phone = 860561212 });
    department.Students.Add(new Student { FullName = "Monika Kardyte", City = "Telsiai", Phone = 867861218 });

    context.Departments.Add(department);
    context.SaveChanges();
}
void UpdateStudentDepartment()
{
    var student = context.Students.First(s => s.Id == 7);
    student.DepartmentId = 5;
    context.SaveChanges();
}
void ShowDepartmentStudents(int depId)
{
    Console.WriteLine($"Students of department {depId}:");
    var students = context.Students.Where(s => s.DepartmentId == depId).Select(sa => sa.FullName);
    foreach (var item in students)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine("---------------");
}
void CreateStudentAddingDepartment()
{
    var student = new Student { FullName = "Rytis Laikus", City="Kaunas",Phone=864525689 ,DepartmentId = 4 };
    context.Students.Add(student);
    context.SaveChanges();
}
void ShowDepartmentLectures()
{
    Console.WriteLine("Lectures of department 6:");

    var result = context.Departments.Include(d => d.Lectures).Single(d => d.Id == 6);
    var lectures = result.Lectures;
    foreach (var item in lectures)
    {
        Console.WriteLine(item.Name);
    }
    Console.WriteLine("---------------");
}
void ShowLecturesByStudent()
{
    Console.WriteLine("Lectures of Student id 8:");
    var studentDep = context.Students.Where(x => x.Id == 8).Select(x => x.DepartmentId).FirstOrDefault();
    var result = context.Departments
        .Include(d => d.Lectures)
        .Include(d => d.Students)
        .Where(x => x.Id == studentDep)
        .FirstOrDefault();
   
    var lectures = result.Lectures;
    foreach (var item in lectures)
    {
        Console.WriteLine(item.Name);
    }
    Console.WriteLine("---------------");
}

void AddToDepartment()
{
    var student = context.Students.Where(s => s.Id == 9).First();
    var lecture = context.Lectures.Where(l => l.Id == 17).First();

    var department = context.Departments.Where(d => d.Id == 4).Include(x=>x.Students).Include(y=>y.Lectures).First();
    department.Students.Add(student);
    department.Lectures.Add(lecture);
   
    context.Departments.Update(department);
    context.SaveChanges();
}
void CreateLectureAndAddingToDepartment(int depId)
{
    var lecture = new Lecture {Name="English"};
    var dep = context.Departments.Where(d => d.Id == depId).Include(x => x.Lectures).First();
    dep.Lectures.Add(lecture);
    context.Departments.Update(dep);
    context.SaveChanges();
}





