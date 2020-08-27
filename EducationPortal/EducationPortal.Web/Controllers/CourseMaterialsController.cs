using EducationPortal.Core;
using EducationPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducationPortal.Web.Controllers
{
    public class CourseMaterialsController : Controller
    {
        private readonly ICourse courseService;

        private readonly IMaterial materialService;

        private int CurrentMaterial {get; set;}

        private PaginationModel PaginationModel { get; set; }

        private const decimal countOfItemsOnPage = 10;
        private const int defaultCurrentPage = 1;

        public CourseMaterialsController(ICourse courseService, IMaterial materialService)
        {
            this.courseService = courseService;
            this.materialService = materialService;

            var countOfItems = (decimal)this.courseService.Count();

            this.PaginationModel = new PaginationModel
            {
                CountOfItems = (int)countOfItems,
                CountOfItemsOnPage = (int)countOfItemsOnPage,
                CountOfPages = (int)Math.Ceiling(countOfItems / countOfItemsOnPage),
                CurrentPage = defaultCurrentPage
            };
        }

        [HttpGet]
        public ActionResult GetMaterial(int id)
        {
            ViewBag.CurrentMaterialId = id;
            int courseId = Int32.Parse(HttpContext.Request.Cookies["courseId"].Value);
            var course = this.courseService.GetCourseById(courseId);
            return View(course.CourseBaseMaterials);
        }

        [HttpGet]
        public ActionResult Finished(int id)
        {
            int courseId = Int32.Parse(HttpContext.Request.Cookies["courseId"].Value);
            this.materialService.MaterialIsFinished(Int32.Parse(Session["UserId"].ToString()), ViewBag.CurrentMaterialId);
            return RedirectToAction("GetMaterial", "CourseMaterials");
        }

        [HttpPost]
        public ActionResult GetMaterial()
        {

            this.materialService.MaterialIsFinished(Int32.Parse(Session["UserId"].ToString()), ViewBag.CurrentMaterialId);
            return RedirectToAction("Course", "GetMaterial");
            return View();
        }

        [HttpGet]
        public ActionResult AddMaterials()
        {
            int courseId = Int32.Parse(HttpContext.Request.Cookies["courseId"].Value.ToString());
            var course = this.courseService.GetCourseById(courseId);
            List<MaterialModel> materials = new List<MaterialModel>();

            var dbMaterials = this.materialService.GetAllMaterials();
            var courseMaterials = course.CourseBaseMaterials;
            bool result = false;
            foreach (var m in dbMaterials)
            {
                foreach (var cm in courseMaterials)
                {

                    if (m.Id == cm.BaseMaterialId)
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }

                }
                if (result == false)
                materials.Add(new MaterialModel() { Id = m.Id, Name = m.Name });
            }
            ViewBag.Materials = materials;
            return PartialView(course);
        }

        [HttpPost]
        public ActionResult AddMaterials(int[] ids)
        {
            string courseId = HttpContext.Request.Cookies["courseId"].Value;
            courseService.AddSelectedMaterialsToCourse(Int32.Parse(courseId), ids.ToList());

            return PartialView();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}