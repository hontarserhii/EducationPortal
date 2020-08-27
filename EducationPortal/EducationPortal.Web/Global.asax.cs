using EducationPortal.Core;
using EducationPortal.BL;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Reflection;
using EducationPortal.BL.Services;
namespace EducationPortal.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();

            IoCService.Register(container);
            //container.Register<IEducationPortalContext, DAL.Context.EducationPortalContext>(Lifestyle.Singleton);
            //container.Register<IEFRepository, DAL.Repository.Repository>(Lifestyle.Singleton);

            container.Register<IPasswordHasher, BL.Services.UserServices.PasswordHasherService>(Lifestyle.Singleton);
            container.Register<IUser, BL.Services.UserServices.UserService>(Lifestyle.Singleton);
            container.Register<ICourse, BL.Services.CourseServices.CourseService>(Lifestyle.Singleton);
            container.Register<IMaterial, BL.Services.MaterialServices.MaterialService>(Lifestyle.Singleton);
            container.Register<Core.Interfaces.ISkill, BL.Services.SkillService.SkillService>(Lifestyle.Singleton);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
