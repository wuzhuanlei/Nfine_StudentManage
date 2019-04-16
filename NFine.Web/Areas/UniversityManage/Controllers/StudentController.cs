using NFine.Application.StudentManage;
using NFine.Code;
using NFine.Code.Excel;
using NFine.Domain.Entity.StudentManage;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.Mvc;

namespace NFine.Web.Areas.UniversityManage.Controllers
{
    [HandlerLogin]
    public class StudentController : ControllerBase
    {
        private StudentApp studenApp = new StudentApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Code.Pagination pagination, string queryJson)
        {
            var data = new
            {
                rows = studenApp.GetList(pagination, queryJson),
                pagination.total,
                pagination.page,
                pagination.records
            };
            return Content(data.ToJson());
        }

       
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(StudentEntity studentEntity, string keyValue)
        {
            studenApp.SubmitForm(studentEntity, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            studenApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }

        [HttpGet]
        public ActionResult ImportForm()
        {
            return View();
        }

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult WriteToExcel(string keyword)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Account");
            dt.Columns.Add("Name");
            dt.Columns.Add("Sex");
            dt.Columns.Add("Political");
            dt.Columns.Add("Profession");
            dt.Columns.Add("CampusCode");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Birthday");
            dt.Columns.Add("Birthplace");
            dt.Columns.Add("Telephone");
            dt.Columns.Add("ClassCode");
            dt.Columns.Add("Counselor");
            dt.Columns.Add("CounselorPhone");
            dt.Columns.Add("DepartmentName");
            dt.Columns.Add("DormitoryCode");
            dt.Columns.Add("EntryGrade");
            dt.Columns.Add("Hobby");
            dt.Columns.Add("LawRest");
            dt.Columns.Add("MaritalStatus");
            dt.Columns.Add("F_CreatorTime");
            dt.Columns.Add("F_CreatorUserId");
            dt.Columns.Add("F_DeleteMark");
            dt.Columns.Add("F_DeleteTime");
            dt.Columns.Add("F_DeleteUserId");
            dt.Columns.Add("F_Description");
            dt.Columns.Add("F_EnabledMark");
            dt.Columns.Add("F_LastModifyTime");
            dt.Columns.Add("F_LastModifyUserId");

            List<StudentEntity> dataList = studenApp.GetList(keyword);
            foreach (var item in dataList)
            {
                DataRow dr = dt.NewRow();
                dr["Account"] = item.Account;
                dr["Name"] = item.Name;
                dr["Sex"] = item.Sex;
                dr["Political"] = item.Political;
                dr["Profession"] = item.Profession;
                dr["Telephone"] = item.Telephone;
                dr["Phone"] = item.Phone;
                dr["CampusCode"] = item.CampusCode;
                dr["Birthday"] = item.Birthday;
                dr["CensusType"] = item.CensusType;
                dr["Birthplace"] = item.Birthplace;
                dr["CertificateType"] = item.CertificateType;
                dr["CertificateCode"] = item.CertificateCode;
                dr["ClassCode"] = item.ClassCode;
                dr["Counselor"] = item.Counselor;
                dr["CounselorPhone"] = item.CounselorPhone;
                dr["DepartmentName"] = item.DepartmentName;
                dr["DormitoryCode"] = item.DormitoryCode;
                dr["EntryGrade"] = item.EntryGrade;
                dr["Hobby"] = item.Hobby;
                dr["LawRest"] = item.LawRest;
                dr["MaritalStatus"] = item.MaritalStatus;
                dr["F_CreatorTime"] = item.F_CreatorTime;
                dr["F_CreatorUserId"] = item.F_CreatorUserId;
                dr["F_DeleteMark"] = item.F_DeleteMark;
                dr["F_DeleteTime"] = item.F_DeleteTime;
                dr["F_DeleteUserId"] = item.F_DeleteUserId;
                dr["F_Description"] = item.F_Description;
                dr["F_EnabledMark"] = item.F_EnabledMark;
                dr["F_LastModifyTime"] = item.F_LastModifyTime;
                dr["F_LastModifyUserId"] = item.F_LastModifyUserId;
                dt.Rows.Add(dr);
            }
            NPOIExcel npoiexel = new NPOIExcel();

            string fileDir = DateTime.Now.ToString("yyyyMMdd");
            string fileName = "G" + Guid.NewGuid().ToString("N") + ".xls";
            string destDir = Server.MapPath(@"/XlsTemp") + "\\" + fileDir + "\\";
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }
            npoiexel.ToExcel(dt, "学生信息", "Sheet1", destDir + fileName);
            return Content("/XlsTemp/" + fileDir + "/" + fileName);
        }
    }
}

