using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core
{
    public interface ICourse
    {
        int CreateCourse(string name, string description);

        void EditCourse(string name, string description);

        void AddMaterialToCourse(int courseId, int baseMaterialId);

        void AddSkillToCourse(int courseId, int skillId);

        void AddSelectedMaterialsToCourse(int courseId, List<int> selectedMaterials);

        List<Course> GetCourses(int countOfItemsOnPage, int currentPageIndex, string courseName);

        int Count();

        Course GetCourseById(int id);

        Course GetCourseWithProgress(int userId, int courseId);

        void StartCourse(int userId, int courseId);

        void CourseIsFinished(int userId, int courseId);

        int GetPassPercentage(int userId, int courseId);
    }
}
