using Microsoft.AspNetCore.Mvc;
using TaskNinja.Models;
using TaskNinja.Services;

namespace TaskNinja.Controllers
{
    /// <summary>
    /// Class <c>RegistrationController</c> contains the endpoints for regestering new users
    /// <br></br>
    /// Author(s): Charles Davis
    /// <br></br>
    /// Version: 0.1
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class RegistrationController : Controller
    {
        /// <summary>
        /// The users DAO
        /// </summary>
        private IUsersDAO usersDAO;
        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationController"/> class.
        /// </summary>
        public RegistrationController()
        {
            this.usersDAO = new UsersDAO();
        }

        /// <summary>
        /// GET: /Registration
        /// <br></br>
        /// Author(s): Charles Davis
        /// </summary>
        /// <returns>Registration View</returns>
        public IActionResult Index()
        {
            // Create user model to send to registration page
            UserModel user = new UserModel();
            // Send user model and view to page
            return View(user);
        }
        /// <summary>
        /// Processes the registration using UserDAO to register a new user into DB.
        /// <br></br>
        /// Author(s): Charles Davis
        /// </summary>
        /// <param name="user">The user to be registered.</param>
        /// <returns>Response page</returns>
        [HttpPost]
        public async Task<IActionResult> ProcessRegistration(UserModel user)
        {
            // Checks to see if model is valid
            if(ModelState.IsValid)
            {
                // Wait for registration to complete
                if(await usersDAO.RegisterUser(user) == UsersDAO.msgSUCCESS) 
                {
                    ViewBag.message = "Registration Success!";
                    // Send usermodel to registration success view
                    return View("Index", user);
                }
                // If registration failed
                else
                {
                    ViewBag.message = "Registration Failed!";
                    // Send usermodel back to registration view
                    return View("Index", user);
                }
            }
            // If model is not valid
            else
            {
                ViewBag.message = "Registration Failed: Invald Model!";
                // Send usermodel back to registration view
                return View("Index", user);
            }
        }
    }
}
