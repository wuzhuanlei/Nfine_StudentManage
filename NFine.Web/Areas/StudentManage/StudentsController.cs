using System.Web.Mvc;

namespace NFine.Web.Areas.StudentManage.Controllers
{
    [HandlerLogin]
    public class StudentsController : ControllerBase
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    }
}
