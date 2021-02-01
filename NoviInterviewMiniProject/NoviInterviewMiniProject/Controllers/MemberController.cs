using NoviInterviewMiniProject.Services;
using System.Web.Mvc;

namespace NoviInterviewMiniProject.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberViewHelper _memberViewHelper;

        public MemberController(IMemberViewHelper memberViewHelper)
        {
            _memberViewHelper = memberViewHelper;
        }

        public ActionResult Index(string searchQuery)
        {
            var data = _memberViewHelper.GetViewData(searchQuery);

            return View(data);
        }
    }
}