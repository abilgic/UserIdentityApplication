using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserIdentityBAL.Services;
using UserIdentityDAL.Models;
using UserIdentityUI.Models;

namespace UserIdentityUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ILogger<HomeController> _logger;
        public HomeController(IMapper mapper, ILogger<HomeController> logger, IUserService userService)
        {
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var userlist = await _userService.GetAll();

            var result = _mapper.Map<List<User>, List<UserModel>>(userlist.ToList());
            _logger.LogInformation("Index() method");
            return View(result);
        }
        public IActionResult Create()
        {
            var places = new Places();
            ViewData["Cities"] = places.Cities;
            ViewData["Towns"] = places.Towns;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel userModel)
        {
            var places = new Places();
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }
            var ddlcitytext = places.Cities.Find(c => c.Value == userModel.City);
            userModel.City = ddlcitytext.Text;
            var ddltowntext = places.Towns.Find(c => c.Value == userModel.Town);
            userModel.Town = ddltowntext.Text;

            var user = _mapper.Map<User>(userModel);
            var result = await _userService.AddUser(user);
            _logger.LogInformation("Create() method");
            return View(userModel);
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var places = new Places();
            ViewData["Cities"] = places.Cities;
            ViewData["Towns"] = places.Towns;
            var user = await _userService.GetById(Id);

            var result = _mapper.Map<UserModel>(user);

            _logger.LogInformation("Edit() method");
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserModel usermodel)
        {
            var places = new Places();
            var ddlcitytext = places.Cities.Find(c => c.Value == usermodel.City);
            usermodel.City = ddlcitytext.Text;
            var ddltowntext = places.Towns.Find(c => c.Value == usermodel.Town);
            usermodel.Town = ddltowntext.Text;

            var useritem = await _userService.GetById(usermodel.Id);

            //User userdata = _mapper.Map<User>(usermodel);

            useritem.FirstName = usermodel.FirstName;
            useritem.LastName = usermodel.LastName;
            useritem.BirthDate = usermodel.BirthDate;
            useritem.Gender = usermodel.Gender;
            useritem.BirthPlace = usermodel.BirthPlace;
            useritem.City = usermodel.City;
            useritem.Town = usermodel.Town;
            useritem.Age = usermodel.Age;


            var result = await _userService.UpdateUser(useritem);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _userService.DeleteUser(Id);
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}