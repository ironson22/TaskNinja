using System;
using Microsoft.AspNetCore.Mvc;
using TaskNinja.Models;
using TaskNinja.Services;

using MongoDB.Bson;
using Microsoft.AspNetCore.DataProtection;

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
            if ( await usersDAO.Login(user) )
            {
                ViewBag.message = "Login Successful!";

                string uid = await usersDAO.GetUserIDByLogin(user);
                if(uid == UsersDAO.msgUSERNOTFOUND)
                {
                    ViewBag.message += " Error: Session Var Not Created<User not found>!";
                }
                else
                {
                    // Set session uid
                    UserSessionHandler.SetUID(HttpContext.Session, new ObjectId(uid));
                    ViewBag.message += " Session Var Created!";
                }

                //TODO Sprint 2: Redirect to Tasks page and remove ViewBag reference
            }
            else
            {
                ViewBag.message = "Login Failed.";
            }
            return View("Index", user);
        }
    }
}