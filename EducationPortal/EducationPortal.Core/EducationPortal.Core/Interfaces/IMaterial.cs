using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core
{
    public interface IMaterial
    {
        int CreateVideoMaterial(VideoMaterial videoMaterial);

        int CreateArticleMaterial(ArticleMaterial articleMaterial);

        int CreateBookMaterial(BookMaterial bookMaterial);

        IEnumerable<CourseBaseMaterials> GetAllMaterialsByCourse(Course course);

        IEnumerable<BaseMaterial> GetAllMaterials();
    }
}
