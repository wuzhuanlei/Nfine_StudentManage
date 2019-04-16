using NFine.Application.Enums;
using NFine.Code;
using NFine.Domain.Entity.StudentManage;
using NFine.Domain.IRepository.StudentManage;
using NFine.Repository.StudentManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NFine.Application.StudentManage
{
    public class StudentApp
    {
        private IStudentRepository service = new StudentRepository();

        public void SubmitForm(StudentEntity studentEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                studentEntity.Modify(keyValue);
                service.Update(studentEntity);
            }
            else
            {
                if (service.FindEntity(t => t.Account == studentEntity.Account) != null)
                {
                    throw new Exception($"已存在学号为{studentEntity.Account}的学生信息。");
                }
                if (!Regex.IsMatch(studentEntity.Telephone, @"^1(3|4|5|7|8|9)\d{9}$"))
                {
                    throw new Exception("手机号码格式不正确。");
                }
                studentEntity.Status = StudentStatus.NewCreate.ToString();
                studentEntity.Create();
                service.Insert(studentEntity);
            }
        }


        public void DeleteForm(string keyValue)
        {
            if (service.IQueryable().Count(t => t.F_Id.Equals(keyValue)) == 0)
            {
                throw new Exception("学生信息不存在。");
            }
            else
            {
                var studentEntity = service.FindEntity(keyValue);
                studentEntity.Status = StudentStatus.Abandon.ToString();
                studentEntity.F_DeleteTime = DateTime.Now;
                studentEntity.F_Description = "删除成功";
                var current = OperatorProvider.Provider.GetCurrent();
                if (current != null) { studentEntity.F_DeleteUserId = current.UserId; }
                studentEntity.Modify(keyValue);
                service.Update(studentEntity);
            }
        }
        private struct QueryItem
        {
            public string Condition { get; set; }
            public string Keyword { get; set; }
        }

        public List<StudentEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<StudentEntity>();
            if (!string.IsNullOrEmpty(queryJson))
            {
                QueryItem queryData = Newtonsoft.Json.JsonConvert.DeserializeObject<QueryItem>(queryJson);
                if (!queryData.IsEmpty())
                {
                    expression = expression.And(t => t.GetType().GetProperty(queryData.Condition).Name.Contains(queryData.Keyword));
                }
            }
            return service.FindList(expression, pagination);
        }
        public List<StudentEntity> GetList(string keyword)
        {
            var expression = ExtLinq.True<StudentEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_Id.Contains(keyword));
            }
            return service.FindList(expression.ToString());
        }

        public StudentEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
    }
}
