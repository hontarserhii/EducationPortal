using EducationPortal.Core;
using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.BL.Services.MaterialServices
{
    public class MaterialService : IMaterial
    {
        private readonly IEFRepository repository;

        public MaterialService(IEFRepository repository)
        {
            this.repository = repository;
        }

        public int CreateVideoMaterial(VideoMaterial videoMaterial)
        {
            int id = this.repository.Create<BaseMaterial>(new VideoMaterial
            {
                Name = videoMaterial.Name,
                Duration = videoMaterial.Duration,
                Quality = videoMaterial.Quality
            });
            return id;
        }

        public int CreateArticleMaterial(ArticleMaterial articleMaterial)
        {
            int id = this.repository.Create<BaseMaterial>(new ArticleMaterial
            {
                Name = articleMaterial.Name,
                Published = articleMaterial.Published,
                Link = articleMaterial.Link
            });
            return id;
        }

        public int CreateBookMaterial(BookMaterial bookMaterial)
        {
            int id = this.repository.Create<BaseMaterial>(new BookMaterial
            {
                Name = bookMaterial.Name,
                Author = bookMaterial.Author,
                Format = bookMaterial.Format,
                Issued = bookMaterial.Issued,
                Page = bookMaterial.Page
            });
            return id;
        }

        public IEnumerable<BaseMaterial> GetAllMaterials()
        {
            var materials = this.repository.GetAll<BaseMaterial>(m => true).ToList();
            if (materials != null)
                return materials;
            else
                return null;
        }

        public void MaterialIsFinished(int userId, int baseMaterialId)
        {
            User user = this.repository.FirstOrDefault<User>(u => u.Id == userId);
            var materials = user.UserMaterials.ToList();
            var material = materials.FirstOrDefault(m => m.BaseMaterialId == baseMaterialId);

            if (material != null)
            {
                materials.Remove(material);
                material.IsFinished = true;
                materials.Add(material);
                user.UserMaterials = materials;
            }

            this.repository.Update<User>(user);
        }
    }
}
