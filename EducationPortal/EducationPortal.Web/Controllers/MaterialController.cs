using EducationPortal.Core;
using EducationPortal.Core.Entities;
using EducationPortal.WEB.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducationPortal.Web.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterial materialService;

        private readonly ICourse courseService;

        public MaterialController(IMaterial materialService, ICourse courseService)
        {
            this.materialService = materialService;
            this.courseService = courseService;
        }


        [HttpGet]
        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBook(BookModel bookModel)
        {
            int id = this.materialService.CreateBookMaterial(new BookMaterial { Name = bookModel.Name,
            Format = bookModel.Format,
            Page = bookModel.Page,
            Issued = bookModel.Issued});
            int courseId = Int32.Parse(HttpContext.Request.Cookies["courseId"].Value);
            courseService.AddMaterialToCourse(courseId, id);
            return RedirectToAction("Course", "Course", courseId.ToString());
            return View();
        }

        [HttpGet]
        public ActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateArticle(ArticleModel articleModel)
        {
            int id = this.materialService.CreateArticleMaterial(new ArticleMaterial
            {
                Name = articleModel.Name,
                Published = articleModel.Published,
                Link = articleModel.Link
            });
            int courseId = Int32.Parse(HttpContext.Request.Cookies["courseId"].Value);
            courseService.AddMaterialToCourse(courseId, id);
            return RedirectToAction("Course", "Course", courseId.ToString());
            return View();
        }

        [HttpGet]
        public ActionResult CreateVideo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateVideo(VideoModel videoModel)
        {
            int id = this.materialService.CreateVideoMaterial(new VideoMaterial
            {
                Name = videoModel.Name,
                Duration = videoModel.Duration,
                Quality = videoModel.Quality
            });
            int courseId = Int32.Parse(HttpContext.Request.Cookies["courseId"].Value);
            courseService.AddMaterialToCourse(courseId, id);
            return RedirectToAction("Course", "Course", courseId.ToString());
            return View();
        }
    }
}