using NFine.Domain.Entity.StudentManage;
using NFine.Domain.IRepository.StudentManage;
using NFine.Repository.StudentManage;
using System.Collections.Generic;
using System.Linq;

namespace NFine.Application.StudentManage
{
    public class StudentApp
    {
        private IStudentRepository service = new StudentRepository();
        public List<StudentEntity> GetList()
        {
            return service.IQueryable().ToList();
        }
    }
}
