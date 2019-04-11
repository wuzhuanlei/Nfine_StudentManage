using NFine.Application.StudentManage;
using NFine.Code;
using NFine.Domain.Entity.StudentManage;
using System.Web.Mvc;

namespace NFine.Web.Areas.UniversityManage.Controllers
{
    [HandlerLogin]
    public class StudentController : ControllerBase
    {
        private StudentApp studenApp = new StudentApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Code.Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = studenApp.GetList(pagination, keyword),
                pagination.total,
                pagination.page,
                pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = studenApp.GetForm(keyValue);
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
        public ActionResult Info()
        {
            return View();
        }
    }
}
