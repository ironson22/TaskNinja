using System;
using TaskNinja.Models;
namespace TaskNinja.Services
{
    public interface ITaskDAO
    {
        /// <summary>
        /// Method <c>GetTaskByID</c> returns a task with the matching UserID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>UserModel Object</returns>
        public Task<TaskModel> GetTaskById(string id);
    }
}
