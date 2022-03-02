using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_api.Services
{
  public interface IStudentService
  {
    Task<List<DataModels.Student>> GetStudentsAsync();
  }
}
