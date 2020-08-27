using EducationPortal.Core;
using EducationPortal.Core.Entities;
using EducationPortal.Core.Interfaces;
using EducationPortal.WEB.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducationPortal.Web.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkill skillService;

        private readonly ICourse courseService;

        public SkillController(ISkill skillService, ICourse courseService)
        {
            this.skillService = skillService;
            this.courseService = courseService;
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSkill(SkillModel skillkModel)
        {
            int id = this.skillService.CreateSkill(skillkModel.SkillName);
            int courseId = Int32.Parse(HttpContext.Request.Cookies["courseId"].Value);
            courseService.AddSkillToCourse(courseId, id);
            return RedirectToAction("Course", "Course");
            return View();
        }
    }
}