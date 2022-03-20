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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(User);
            }
            var user = _mapper.Map<User>(userModel);
            var result = await _userService.AddUser(user);
            _logger.LogInformation("Create() method");
            return View(User);
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var user = _userService.GetById(Id);
            var result = _mapper.Map<UserModel>(user);
            _logger.LogInformation("Edit() method");
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserModel usermodel)
        {
            var user = _mapper.Map<User>(usermodel);
            var result = await _userService.UpdateUser(user);
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