using Microsoft.EntityFrameworkCore;
using student_api.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_api.Services
{
  public class StudentService : IStudentService
  {
    private readonly StudentAdminContext context;

    public StudentService(StudentAdminContext context)
    {
      this.context = context;
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
      // Problem 1. Not showing Address and Gender Object
      // return context.Student.ToList();
      
      // Solution 1. Show Address and Gender Object
      return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
      
      // Problem 2. Why doesnt this works?
      //var students = context.Student.FromSqlRaw($"GetStudents").Include(nameof(Gender)).Include(nameof(Address)).AsEnumerable<Student>().ToList();
      //return students;

    }
  }
}
