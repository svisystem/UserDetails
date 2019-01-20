using UserDetails.Interfaces;
using UserDetails.Models;
using UserDetails.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace UserDetails.Controllers
{
    [Route("")]
    public class DetailsController : Controller
    {
        private IUserRepository _usersRepository;

        private DetailsViewModel _dvm;

        public DetailsController(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [Route("Add")]
        public IActionResult Details()
        {
            _dvm = new DetailsViewModel();
            return View(_dvm);
        }

        [HttpPost("Add")]
        public IActionResult Save(DetailsViewModel vm)
        {
            bool accept;

            if (vm.User.Id != null)
            {
                accept = vm.CurrentPassword == _usersRepository.GetSingleById((int)vm.User.Id).Password;
                vm.User.Password = vm.CurrentPassword;
            }
            else accept = true;

            if (ModelState.IsValid && accept)
            {
                if (!string.IsNullOrEmpty(vm.PasswordCheck))
                    vm.User.Password = vm.PasswordCheck;

                if (vm.User.Id != null)
                    _usersRepository.UdateSingle(vm.User);
                else
                    _usersRepository.AddSingle(vm.User);

                return RedirectToAction(nameof(ListController.List), "List");
            }
            return View(nameof(Details), vm);
        }

        [Route("Edit/{user}")]
        public IActionResult Edit(int user)
        {
            _dvm = new DetailsViewModel(_usersRepository.GetSingleById(user));
            return View(nameof(Details), _dvm);
        }
    }
}
