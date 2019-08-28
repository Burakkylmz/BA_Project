using BAProject.BLL.Services;
using BAProject.DAL.DAL.Context;
using BAProject.DAL.DAL.Repositories.Abstract;
using BAProject.DAL.DAL.Repositories.Concrete;
using BAProject.DAL.DAL.UnitOfWork.Abstract;
using BAProject.DAL.DAL.UnitOfWork.Concrete;
using BAProject.Model.Model.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BAProject.UI.Controllers
{
    public class TestController : Controller
    {
        BAProjeContext _dbContext;
        IUnitOfWork _uow;
        IRepository<Category> _categoryRepository;

        UserService _userRepository;

        public TestController(BAProjeContext dbContext)
        {
            _dbContext = dbContext;
            _uow = new EFUnitOfWork(_dbContext);
            _categoryRepository = new EFRepository<Category>(_dbContext);
            //Veya alttaki gibi bir logic kurulabilir:
            _userRepository = new UserService(dbContext);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Category data)
        {
            _categoryRepository.Add(data);
            int stage = _uow.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult AddPerson()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(AppUser data) //Veya VM/DTO olabilir.
        {
            data.Password = _userRepository.GenerateNewPassword();
            data.BirthDate = new System.DateTime(1900, 10, 10);

            _userRepository.Add(data);
            int stage = _uow.SaveChanges();
            return View();
        }

    }
}