using UserDetails.Interfaces;
using UserDetails.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserDetails.Controllers
{
    [Route("")]
    public class ListController : Controller
    {
        private IUserRepository _usersRepository;

        public ListController(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [Route("List")]
        public IActionResult List()
        {
            ListViewModel lvm = new ListViewModel();
            lvm.UserList = _usersRepository.GetAll().ToList();
            return View(lvm);
        }

        [Route("Delete/{user}")]
        public IActionResult Delete(int user)
        {
            _usersRepository.Remove(user);
            return RedirectToAction(nameof(List));
        }
    }
}
