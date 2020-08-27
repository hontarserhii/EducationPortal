using EducationPortal.Core;
using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.BL.Services.CourseServices
{
    public class CourseService : ICourse
    {
        private readonly IEFRepository repository;

        const string StatusDone = "Done";
        const string StatusInProgress = "InProgress";

        public CourseService(IEFRepository repository)
        {
            this.repository = repository;
        }

        public int CreateCourse(string name, string description)
        {
            int id = this.repository.Create<Course>(new Course
            {
                Name = name,
                Description = description,
            });
            return id;
        }

        public void EditCourse(string name, string description)
        {
            this.repository.Update<Course>(new Course
            {
                Name = name,
                Description = description,
            });
        }

        public void AddMaterialToCourse(int courseId, int baseMaterialId)
        {
            Course course = this.repository.FirstOrDefault<Course>(c => c.Id == courseId);
            course.CourseBaseMaterials.Add(new CourseBaseMaterials() { CourseId = courseId, BaseMaterialId = baseMaterialId });
            this.repository.Update<Course>(course);
        }

        public void AddSkillToCourse(int courseId, int skillId)
        {
            Course course = this.repository.FirstOrDefault<Course>(c => c.Id == courseId);
            course.CourseSkills.Add(new CourseSkills() { CourseId = courseId, SkillId = skillId });
            this.repository.Update<Course>(course);
        }

        public void AddSelectedMaterialsToCourse(int courseId, List<int> selectedMaterialsId)
        {
            Course course = this.repository.FirstOrDefault<Course>(c => c.Id == courseId);
            course.CourseBaseMaterials.Clear();
            foreach (var id in selectedMaterialsId)
            {
                course.CourseBaseMaterials.Add(new CourseBaseMaterials() { CourseId = courseId, BaseMaterialId = id });
            }
            this.repository.Update<Course>(course);
        }

        public Course GetCourseById(int id)
        {
            return repository.FirstOrDefault<Course>(course => course.Id == id);
        }

        public List<Course> GetCourses(int countOfItemsOnPage, int currentPageIndex, string courseName)
        {
            if (courseName == "")
            return this.repository.GetBlock<Course>(c => true, currentPageIndex * countOfItemsOnPage - countOfItemsOnPage, countOfItemsOnPage).ToList();
            else
                return this.repository.GetBlock<Course>(c => c.Name.ToLower().Contains(courseName.ToLower()), currentPageIndex * countOfItemsOnPage - countOfItemsOnPage, countOfItemsOnPage).ToList();
        }

        public Course GetCourseWithProgress(int userId, int courseId)
        {
            Course course = this.repository.FirstOrDefault<Course>(c => c.Id == courseId);
            User user = this.repository.FirstOrDefault<User>(u => u.Id == userId);
            var courseBaseMaterials = course.CourseBaseMaterials;
            var userMaterials = user.UserMaterials;
            foreach (var cms in courseBaseMaterials)
            {
                foreach (var ums in userMaterials)
                {
                    if (cms.BaseMaterialId == ums.BaseMaterialId)
                    {
                        cms.IsFinished = true;
                    }
                }
            }
            courseBaseMaterials.OrderBy(m => m.Number);
            course.CourseBaseMaterials = courseBaseMaterials;
            this.repository.Update<Course>(course);
            foreach (var cms in courseBaseMaterials)
            {
                if (cms.IsFinished == true)
                    course.CourseBaseMaterials.Remove(cms);
            }
            return course;
        }

        public void StartCourse(int userId, int courseId)
        {
            Course course = this.repository.FirstOrDefault<Course>(c => c.Id == courseId);
            User user = this.repository.FirstOrDefault<User>(u => u.Id == userId);
            user.UserCourses.Add(new UserCourses { CourseId = courseId, Status = StatusInProgress, BeginningDate = DateTime.Now});
        }

        public void CourseIsFinished(int userId, int courseId)
        {
            User user = this.repository.FirstOrDefault<User>(u => u.Id == userId);

            Course course = this.repository.FirstOrDefault<Course>(c => c.Id == courseId);

            var userSkills = user.UserSkills;
            foreach(var cs in course.CourseSkills)
            {
                foreach(var us in userSkills)
                {
                    if (cs.SkillId == us.SkillId)
                        us.Rate += cs.Rate;
                    else
                    {
                        us.Rate = cs.Rate;
                        userSkills.Add(new UserSkills { Skill = cs.Skill, UserId = userId });
                    }
                }
            }
            user.UserSkills = userSkills;

            var userCourse = user.UserCourses.FirstOrDefault(c => c.CourseId == courseId);
            
            user.UserCourses.Remove(userCourse);

            userCourse.Status = StatusDone;
            user.UserCourses.Add(userCourse);


            this.repository.Update<User>(user);
        }

        public int GetPassPercentage(int userId, int courseId)
        {
            var user = this.repository.FirstOrDefault<User>(u => u.Id == userId);
            var userMaterials = user.UserMaterials;

            var course = this.repository.FirstOrDefault<Course>(u => u.Id == courseId);
            var courseMaterials = course.CourseBaseMaterials;

            var countCourseMaterials = courseMaterials.Count;
            int countIsFinished = 0;
            foreach (var cm in courseMaterials)
            {
                foreach(var um in userMaterials)
                {
                    if(cm.BaseMaterialId == um.BaseMaterialId && um.IsFinished == true)
                    {
                        countIsFinished++;
                    }
                }
            }
            int result = countIsFinished / 
                ;
            return 0;
        }

        public int Count()
        {
            return this.repository.Count<Course>(c => true);
        }
    }
}
