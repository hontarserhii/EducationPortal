using EducationPortal.BL.Services;
using EducationPortal.BL.Services.CourseServices;
using EducationPortal.BL.Services.MaterialServices;
using EducationPortal.BL.Services.SkillService;
using EducationPortal.BL.Services.UserServices;
using EducationPortal.Core;
using EducationPortal.Core.Entities;
using EducationPortal.Core.Interfaces;
using EducationPortal.PL.DTO;
using PL.Core;
using PL.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.PL
{
    public class UserPage
    {
        public IUser UserService { get; set; }
        public ICourse CourseService { get; set; }
        public IMaterial MaterialService { get; set; }
        public ISkill SkillService { get; set; }

        public UserSession UserSession { get; set; }

        UserData userData;
        CourseDTO CourseDTO;
        Course Course { get; set; }
        ArticleMaterial ArticleMaterial {get; set;}
        VideoMaterial VideoMaterial { get; set; }
        BookMaterial BookMaterial { get; set; }
        Skill Skill { get; set; }

        public UserPage(IUser userService, ICourse courseService, IMaterial materialService, ISkill skillService) 
        {
            this.UserService = userService;
            this.CourseService = courseService;
            this.MaterialService = materialService;

            this.userData = new UserData();
            this.CourseDTO = new CourseDTO();
            this.ArticleMaterial = new ArticleMaterial();
            this.BookMaterial = new BookMaterial();
            this.VideoMaterial = new VideoMaterial();
            this.Course = new Course();
            this.UserSession = new UserSession();
            this.Skill = new Skill();
            UserSession.Id = -1;
           
            //this.PasswordHasherService = passwordHasherService;
        }
        public void Execute(int command)
        {
            switch (command)
            {
                case 1:
                    DisplayRegForm();
                    bool isReg = UserService.Registrate(new User
                    {
                        FirstName = userData.FirstName,
                        LastName = userData.LastName,
                        Age = userData.Age,
                        Email = userData.Email,
                        Login = userData.Login,
                        Password = userData.Password
                    });
                    if (isReg == true)
                    {
                        Console.WriteLine("Вы зарегались");
                    }
                    else
                        Console.WriteLine("Вы не зарегались");
                    break;
                case 2:
                    DisplayLoginForm();
                    int idAuthUser = UserService.Authorizate(userData.Login, userData.Password);
                    UserSession.Id = idAuthUser;
                    if ( idAuthUser >= 0)
                    {
                        Console.WriteLine("Вы вошли в систему");
                        UserSession.Id = idAuthUser;
                    }
                    else
                        Console.WriteLine("Неверный пароль или логин");
                    break;
            }
            if (UserSession.Id >= 0)
            {
                switch (command)
                {
                    case 3:

                        if (UserSession.Id >= 0)
                        {
                            DisplayCourseCreatingForm();
                            CourseDTO.Id = CourseService.CreateCourse(
                                Course.Name,
                                Course.Description
                            );
                            if (CourseDTO.Id >= 0)
                            {
                                Console.WriteLine("Курс создан");
                            }
                            else
                                Console.WriteLine("Курс не создан");
                        }
                        break;
                    case 4:
                        if (UserSession.Id >= 0)
                        {
                            PrintMaterailsCommands();
                            int numberOfMaterial = SelectCommand();
                            if(numberOfMaterial == 1)
                            {
                                DisplayArticleCreatingForm();
                                ArticleMaterial.Id = MaterialService.CreateArticleMaterial(new ArticleMaterial
                                {
                                    
                                    Name = ArticleMaterial.Name,
                                    Link = ArticleMaterial.Link,
                                    Published = ArticleMaterial.Published
                                });

                                CourseService.AddMaterialToCourse(CourseDTO.Id, ArticleMaterial.Id);
                            }
                            if (numberOfMaterial == 2)
                            {
                                DisplayVideoCreatingForm();
                                MaterialService.CreateVideoMaterial(new VideoMaterial
                                {
                                    Name = VideoMaterial.Name,
                                    Duration = VideoMaterial.Duration,
                                    Quality = VideoMaterial.Quality
                                });
                                
                            }
                            if (numberOfMaterial == 3)
                            {
                                DisplayBookCreatingForm();
                                MaterialService.CreateBookMaterial( new BookMaterial
                                {
                                    Name = BookMaterial.Name,
                                    Author = BookMaterial.Author,
                                    Format = BookMaterial.Format,
                                    Issued = BookMaterial.Issued,
                                    Page = BookMaterial.Page
                                });
                            }
                        }
                        break;
                    case 5:
                        foreach (var m in MaterialService.GetAllMaterials())
                        {
                            PrintMaterial(m);
                        }
                        break;
                    case 6:
                        DisplaySkillCreatingForm();
                        SkillService.CreateSkill("Skill1");
                        break;
                    case 7:
                        //DisplaySkillCreatingForm();
                        CourseService.GetCourseWithProgress(UserSession.Id, CourseDTO.Id);
                        break;
                }
            }
        }
       
        public void PrintCommands()
        {
            Console.WriteLine("Выберите команду:");
            Console.WriteLine("1) Регистрация");
            Console.WriteLine("2) Авторизация");

            if (UserSession.Id >= 0)
            {
                Console.WriteLine("3) Добавить курс");
                Console.WriteLine("4) Добавить новый материал в курс");
                Console.WriteLine("5) Добаить существующий материал в курс");
                Console.WriteLine("6) Добавить скиллы");
            }
            
        }
        public void PrintMaterial(BaseMaterial baseMaterial)
        {
            Console.WriteLine(baseMaterial.Id + ") " + baseMaterial.Name);
        }

        public void PrintMaterailsCommands()
        {
            if (UserSession.Id >= 0)
            {
                Console.WriteLine("1) Статьи:");
                Console.WriteLine("2) Видео");
                Console.WriteLine("3) Ссылки");
                Console.WriteLine("Укажите номер типа метериала");
            }
        }
        public int SelectCommand()
        {
            return Int32.Parse(Console.ReadLine());
        }
        public void DisplayRegForm()
        {
            Console.WriteLine("Имя:");
            userData.FirstName = Console.ReadLine();
            Console.WriteLine("Фамилия:");
            userData.LastName = Console.ReadLine();
            Console.WriteLine("Возраст:");
            userData.Age = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Почта:");
            userData.Email = Console.ReadLine();
            Console.WriteLine("Логин:");
            userData.Login = Console.ReadLine();
            Console.WriteLine("Пароль:");
            userData.Password = Console.ReadLine();
        }

        public void DisplayLoginForm()
        {
            Console.WriteLine("Логин:");
            userData.Login = Console.ReadLine();
            Console.WriteLine("Пароль:");
            userData.Password = Console.ReadLine();
        }

        public void DisplayVideoCreatingForm()
        {
            Console.WriteLine("Название:");
            VideoMaterial.Name = Console.ReadLine();
            Console.WriteLine("Продолжительность:");
            VideoMaterial.Duration = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Качество:");
            VideoMaterial.Quality = Console.ReadLine();
        }

        public void DisplayBookCreatingForm()
        {
            Console.WriteLine("Название:");
            BookMaterial.Name = Console.ReadLine();
            Console.WriteLine("Автор:");
            BookMaterial.Author = Console.ReadLine();
            Console.WriteLine("Формат:");
            BookMaterial.Format = Console.ReadLine();
            Console.WriteLine("Количество страниц:");
            BookMaterial.Page = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Год издания:");
            BookMaterial.Issued = Convert.ToDateTime(Console.ReadLine());
        }

        public void DisplayArticleCreatingForm()
        {
            Console.WriteLine("Название:");
            ArticleMaterial.Name = Console.ReadLine();
            Console.WriteLine("Дата публикации:");
           
            Console.WriteLine("Ссылка:");
            ArticleMaterial.Link = Console.ReadLine();
        }

        public void DisplayCourseCreatingForm()
        {
            Console.WriteLine("Название курса:");
            Course.Name = Console.ReadLine();
            Console.WriteLine("Описание:");
            Course.Description = Console.ReadLine();
        }

        public void DisplayMaterialAddingForm()
        {
            Console.WriteLine("Список материалов:");
            Course.Name = Console.ReadLine();
            Console.WriteLine("Описание:");
            Course.Description = Console.ReadLine();
        }

        public void DisplaySkillCreatingForm()
        {
            Console.WriteLine("Название:");
            Skill.Name = Console.ReadLine();
        }

        public void Update()
        {
            while (true)
            {
                PrintCommands();
                int command = SelectCommand();
                Console.Clear();
                Execute(command);
            }
        }
    }
}
