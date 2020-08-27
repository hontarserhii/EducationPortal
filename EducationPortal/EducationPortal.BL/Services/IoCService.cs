using EducationPortal.Core;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.BL.Services
{
    public class IoCService
    {
        public static void Register(Container container)
        {
            container.Register<IEducationPortalContext, DAL.Context.EducationPortalContext>(Lifestyle.Singleton);
            container.Register<IEFRepository, DAL.Repository.Repository>(Lifestyle.Singleton);
        }
    }
}
