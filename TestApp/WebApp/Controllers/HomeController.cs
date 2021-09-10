using AutoMapper;
using BusinessLogic.Manage;
using BusinessLogic.Services;
using BusinessLogic.ViewModel;
using Common.Enums;
using DataAccess.Abstracts;
using Rotativa;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        #region fields
        private IBranchService branchService;
        private IRepresentativeService representativeService;
        #endregion

        #region ctor
        public HomeController(IBranchService branchService, IRepresentativeService representativeService)
        {
            this.branchService = branchService;
            this.representativeService = representativeService;

        }
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateBranch()
        {


            return View();
        }

        [HttpPost]
        public ActionResult CreateBranch(BranchCreateModel branch, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    branch.FileName = SaveFile(file);
                }

                var representativeId = representativeService.Create(branch.Representative);
                branchService.Create(branch, representativeId);
                TempData["Success"] = "Added Successfully!";

                return RedirectToAction("GetAllAppeals");
            }

            else return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        public string SaveFile(HttpPostedFileBase file)
        {
            string fileName = $"{Path.GetFileNameWithoutExtension(file.FileName)}" +
                $"-{Guid.NewGuid().ToString("D").Substring(0, 8)}" +
                $"{Path.GetExtension(file.FileName)}";

            string subPath = Path.Combine(Server.MapPath("~/UploadedFiles"));

            if (!Directory.Exists(subPath))
            {
                Directory.CreateDirectory(subPath);
            }

            string path = Path.Combine(subPath, fileName);

            file.SaveAs(path);
            return fileName;
        }


        public ActionResult GetAllAppeals()
        {
            ViewBag.Workers = users;
            var applies = branchService.GetAll();
            return View(applies);
        }

        public ActionResult Confirm(string id)
        {
            ViewBag.Workers = users;
            var branch = branchService.Get(id);
            return PartialView("~/Views/Shared/_ModalPartialView.cshtml", branch);
        }

        [HttpPost]
        public ActionResult Confirm(BranchUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Workers = users;
                model.UserId = model.UserId;
                model.Status = Status.Processing.ToString();
                branchService.Update(model);
            }

            return RedirectToAction("GetAllAppeals");
        }

        public ActionResult Details(string id)
        {
            var branch = branchService.Get(id);
            return View(branch);
        }

        public ActionResult PrintPartialViewToPdf(string id)
        {
            var branch = branchService.Get(id);
            var report = new PartialViewAsPdf("~/Views/Shared/_DetailBranchPartialView.cshtml", branch);
            return report;
        }


        List<UserViewModel> users = new List<UserViewModel>()
            {
                new UserViewModel()
                {
                    Id=2,
                    UserName="Worker"
                }
            };

    }
}