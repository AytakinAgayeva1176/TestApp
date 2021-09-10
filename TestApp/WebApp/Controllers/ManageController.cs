using BusinessLogic.Services;
using BusinessLogic.ViewModel;
using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Filter;

namespace WebApp.Controllers
{
    [Auth]
    public class ManageController : Controller
    {
        // GET: Manage

        private IBranchService branchService;
        public ManageController(IBranchService branchService)
        {
            this.branchService = branchService;
        }


        public ActionResult Index()
        {
            UserViewModel user = Session["Login"] as UserViewModel;

            var appeals = branchService.GetAll(user.Id);
            return View(appeals);

        }

        public ActionResult Details(string id)
        {
            var branch = branchService.Get(id);
            return View(branch);
        }



        public ActionResult Confirm(string id)
        {
            var branch = branchService.Get(id);
            UserViewModel user = Session["Login"] as UserViewModel;
            if (user.Role == UserRole.Admin.ToString())
            {
                branch.RegistrationDate = DateTime.Now.ToString("dd.MM.yyyy");
                branch.Status = Status.Confirmed.ToString();
            }
            else
            {
                branch.UserId = 1;
                branch.Status = Status.Checked.ToString();
            }

            branchService.Update(branch);
            return RedirectToAction("Index");
        }



        public ActionResult Reject(string id)
        {
            var branch = branchService.Get(id);
            branch.Status = Status.Rejected.ToString();
            branchService.Update(branch);
            return RedirectToAction("Index");
        }
    }
}