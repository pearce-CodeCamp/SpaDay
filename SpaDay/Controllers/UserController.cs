using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;
using SpaDay.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        [HttpPost]
        [Route("/user")]
        public IActionResult SubmitAddUserForm(AddUserViewModel addUserViewModel)
        {
            // the model state is only going to be valid if we adhere to all the
            // requirements setup with the annotations in the AddUserViewModel
            if (ModelState.IsValid)
            {
                //check to see if Password and VerifyPassword match
                if (addUserViewModel.Password == addUserViewModel.VerifyPassword)
                {
                    User newUser = new User(
                        addUserViewModel.Username, 
                        addUserViewModel.Email,
                        addUserViewModel.Password
                    );

                    return View("Index", newUser);
                } else
                {
                    ViewBag.error = "Passwords didn't match!";
                    return View("Add");
                }
            }

            return View("Add");
        }

    }
}
