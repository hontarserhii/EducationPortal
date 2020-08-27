using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EducationPortal.BL.Services.CourseServices;
using EducationPortal.Core;
using EducationPortal.Web.Models;

namespace EducationPortal.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourse courseService;

        private readonly IMaterial materialService;

        private PaginationModel PaginationModel { get; set; }

        private const decimal countOfItemsOnPage = 10;
        private const int defaultCurrentPage = 1;

        public CourseController(ICourse courseService, IMaterial materialService)
        {
            this.courseService = courseService;
            this.materialService = materialService;

            var countOfItems = (decimal)this.courseService.Count();

            this.PaginationModel = new PaginationModel { CountOfItems = (int)countOfItems,
                CountOfItemsOnPage = (int)countOfItemsOnPage,
                CountOfPages = (int)Math.Ceiling(countOfItems / countOfItemsOnPage),
                CurrentPage = defaultCurrentPage
            };
        }

        [HttpGet]
        public ActionResult Course(int id)
        {
            //bool result = true;
            //try
            //{
            //    var id = HttpContext.Request.Cookies["courseId"].Value;
            //}
            //catch
            //{
            //    result = false;
            //}

            //if (result != false)
            //{
            //    int courseId = Int32.Parse(HttpContext.Request.Cookies["courseId"].Value);
            //    var course = this.courseService.GetCourseById(courseId);
            //    return View(course);
            //}
            //else
            //    return View();
            var course = this.courseService.GetCourseById(id);
            HttpContext.Response.Cookies["courseId"].Value = id.ToString();
            return View(course);
        }

        [HttpPost]
        public ActionResult Course()
        {
            bool result = true;
            try
            {
                var id = HttpContext.Request.Cookies["courseId"].Value;
            }
            catch
            {
                result = false;
            }

            if (result != false)
            {
                int courseId = Int32.Parse(HttpContext.Request.Cookies["courseId"].Value);
                var course = this.courseService.GetCourseById(courseId);
                return View(course);
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult CreateFullCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFullCourse(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateCourse()
        {
            CourseCreatingModel courseModel = new CourseCreatingModel
            {
                Name = "",
                Description = ""
            };
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourse(CourseCreatingModel courseModel)
        {
            int id = this.courseService.CreateCourse(courseModel.Name, courseModel.Description);
            HttpContext.Response.Cookies["courseId"].Value = id.ToString();
            return RedirectToAction("Course", "Course", id.ToString());

            return View();
        }

        [HttpGet]
        public ActionResult EditCourse(int id)
        { 
            var course = this.courseService.GetCourseById(id);
            
            if (course != null)
            {
                CourseCreatingModel courseModel = new CourseCreatingModel
                {
                    Name = course.Name,
                    Description = course.Description
                };
                return View(courseModel);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditCourse(CourseCreatingModel book)
        {
            this.courseService.EditCourse(book.Name, book.Description);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult AddMaterials()
        {
            List<MaterialModel> materials = new List<MaterialModel>();
            var dbMaterials = this.materialService.GetAllMaterials();
            foreach (var m in dbMaterials)
            {
                materials.Add(new MaterialModel() { Id = m.Id, Name = m.Name });
            }
            return PartialView(materials);
        }

        [HttpPost]
        public ActionResult AddMaterials(int[] ids)
        {
            string courseId = HttpContext.Request.Cookies["courseId"].Value;
            courseService.AddSelectedMaterialsToCourse(Int32.Parse(courseId), ids.ToList());

            return PartialView();
        }

        public ActionResult AddCourse()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddNewMaterial()
        {
            List<MaterialModel> materials = new List<MaterialModel>();
            var dbMaterials = this.materialService.GetAllMaterials();
            foreach (var m in dbMaterials)
            {
                materials.Add(new MaterialModel() { Id = m.Id, Name = m.Name });
            }
            return PartialView(materials);
        }

        [HttpPost]
        public ActionResult AddNewMaterial(int[] ids)
        {
            string courseId = HttpContext.Request.Cookies["courseId"].Value;
            courseService.AddSelectedMaterialsToCourse(Int32.Parse(courseId), ids.ToList());

            return PartialView();
        }

        [HttpGet]
        public ActionResult Subscribe()
        {
            int courseId = Int32.Parse(HttpContext.Response.Cookies["courseId"].Value);
            if (courseId > 0)
            {
                this.courseService.StartCourse(Int32.Parse(Session["UserId"].ToString()), courseId);
                return RedirectToAction("GetMaterial","CourseMaterials");
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult Materials(int id)
        {
            var course = this.courseService.GetCourseById(id);
            return View(course.CourseBaseMaterials.ToList());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            HttpContext.Response.Cookies["courseId"].Value = id.ToString();
            if (id > 0)
            {
                var course = this.courseService.GetCourseById(id);
                CourseBaseInfoModel courseBaseInfo = new CourseBaseInfoModel
                {
                    Id = course.Id,
                    Description = course.Description,
                    Name = course.Name,
                    CountOfMaterials = course.CourseBaseMaterials.Count(),
                    CountOfSubs = course.UserCourses.Count()
                };
                return PartialView(courseBaseInfo);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult Details()
        {
            int courseId = Int32.Parse(HttpContext.Response.Cookies["courseId"].Value);
            if (courseId > 0)
            {
                this.courseService.StartCourse(Int32.Parse(Session["UserId"].ToString()), courseId);
                return PartialView();
            }
            else
            {
                return HttpNotFound();
            }
        }


        [HttpGet]
        public ActionResult Index()
        {
            var countOfItems = (decimal)this.courseService.Count();
            var courses = this.courseService.GetCourses(PaginationModel.CountOfItemsOnPage, PaginationModel.CurrentPage, "");
            var courseInfo = new List<CourseBaseInfoModel>();
            foreach (var c in courses)
            {
                c.CourseBaseMaterials.Count();
                c.UserCourses.Count();
                courseInfo.Add(new CourseBaseInfoModel { Id = c.Id,
                    Name = c.Name,
                    CountOfMaterials = c.CourseBaseMaterials.Count(),
                    CountOfSubs = c.UserCourses.Count() });
            }
            return View(courseInfo);
        }
        [HttpPost]
        public ActionResult Index(string name)
        {
            var courses = this.courseService.GetCourses(PaginationModel.CountOfItemsOnPage, PaginationModel.CurrentPage, name);
            var courseInfo = new List<CourseBaseInfoModel>();
            foreach (var c in courses)
            {
                c.CourseBaseMaterials.Count();
                c.UserCourses.Count();
                courseInfo.Add(new CourseBaseInfoModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    CountOfMaterials = c.CourseBaseMaterials.Count(),
                    CountOfSubs = c.UserCourses.Count()
                });
            }
            return View(courseInfo);
        }
    }
}