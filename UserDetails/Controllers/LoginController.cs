using UserDetails.Interfaces;
using UserDetails.Models;
using UserDetails.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace UserDetails.Controllers
{
    [Route("")]
    public class LoginController : Controller
    {
        private IUserRepository _usersRepository;

        public LoginController(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [Route("")]
        public IActionResult Index()
        {
            LoginViewModel _loginVM = new LoginViewModel();
            return View(_loginVM);
        }

        [HttpPost("")]
        public IActionResult Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                User user = _usersRepository.GetSingleByUserName(vm.UserName);

                if (user.Password == vm.Password)
                    return RedirectToAction(nameof(ListController.List), "List");

                else return View(nameof(Index), vm);
            }
            return View(nameof(Index), vm);
        }
    }
}