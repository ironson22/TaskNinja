using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskNinja.Models;
using TaskNinja.Services;

namespace TaskNinja.Controllers
{
    /// <summary>
    /// Class <c>LoginController</c> contains the endpoints for logging in users
    /// <br></br>
    /// Author(s): Gabriel Cepleanu
    /// <br></br>
    /// Version: 0.1
    /// </summary>
    public class LoginController : Controller
    {
        private IUsersDAO usersDAO;

        public LoginController()
        {
            usersDAO = new UsersDAO();
        }
        public IActionResult Index()
        {
            UserModel user = new UserModel();
            return View(user);
        }

        /// <summary>
        /// Method <c>ProcessLogin</c> uses the Users DAO to authenticate the given credentials.
        /// </summary>
        /// <param name="user">User credentials</param>
        /// <returns>Response page</returns>
        [HttpPost]
        public async Task<IActionResult> ProcessLogin(UserModel user)
        {
            // use DAO to check if credentials are valid
            if (await usersDAO.Login(user))
            {
                //TODO Sprint 2: Redirect to Tasks page and remove ViewBag reference
                ViewBag.message = "Login Successful!";
            }
            else
            {
                ViewBag.message = "Login Failed.";
            }
            return View("Index", user);
        }
    }
}