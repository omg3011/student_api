using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using student_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_api.Controllers
{
  [ApiController]
  public class StudentController : Controller
  {
    private readonly IStudentService studentService;
    private readonly IMapper mapper;

    public StudentController(IStudentService studentService, IMapper mapper)
    {
      this.studentService = studentService;
      this.mapper = mapper;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<IActionResult> GetStudentsAsync()
    {
      var dataModelStudents = await studentService.GetStudentsAsync();

      //-- W/ Auto Mapper: Map dataModel->student into domainModel->student
      return Ok(mapper.Map<List<DomainModels.Student>>(dataModelStudents));

      //-- W/o Auto Mapper zxczxczc
      //var domainModelStudents = new List<DomainModels.Student>();
      //foreach (var student in dataModelStudents)
      //{
      //  domainModelStudents.Add(new DomainModels.Student()
      //  {
      //     Id = student.Id,
      //     FirstName = student.FirstName,
      //     LastName = student.LastName,
      //     DateOfBirth = student.DateOfBirth,
      //     Email = student.Email,
      //     Mobile = student.Mobile,
      //     ProfileImageUrl = student.ProfileImageUrl,
      //     GenderId = student.GenderId,
      //     Address = new DomainModels.Address()
      //     {
      //       Id = student.Address.Id,
      //       PhysicalAddress = student.Address.PhysicalAddress,
      //       PostalAddress = student.Address.PostalAddress,
      //       StudentId = student.Address.StudentId
      //     },
      //     Gender = new DomainModels.Gender()
      //     {
      //       Id= student.Gender.Id,
      //       Description = student.Gender.Description,
      //     }
      //  });
      //}
      //return Ok(domainModelStudents);
    }
  }
}
