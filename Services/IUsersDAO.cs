using System;
using TaskNinja.Models;
namespace TaskNinja.Services
{
    /// <summary>
    /// Interface <c>IUsersDAO</c> provides the outline for a Data Access Object for UserModels
	/// <br></br>
    /// Author(s): Gabriel Cepleanu
	/// <br></br>
    /// Version: 0.1
    /// </summary>
    public interface IUsersDAO
	{
		/// <summary>
		/// Method <c>GetUsers</c> returns a list of all users from the database asynchronously
		/// </summary>
		/// <returns>List of UserModel objects</returns>
		public Task<List<UserModel>> GetUsers();

		/// <summary>
		/// Method <c>GetUserByID</c> returns a user with the matching ID
		/// </summary>
		/// <param name="id">User ID</param>
		/// <returns>UserModel object</returns>
		public Task<UserModel> GetUserByID(string id);

		/// <summary>
		/// Registers a new user and saves the information to the database asynchronously
		/// </summary>
		/// <param name="user">New User</param>
		/// <returns>Status String</returns>
		public Task<string> RegisterUser(UserModel user);

		/// <summary>
		/// Authenticates a given UserModel by username and password using the database asynchronously
		/// </summary>
		/// <param name="user">User information</param>
		/// <returns>Status</returns>
		public Task<bool> Login(UserModel user);

	}
}

