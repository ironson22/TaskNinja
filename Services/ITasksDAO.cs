using System;
using TaskNinja.Models;

namespace TaskNinja.Services
{
    /// <summary>
    /// Interface <c>ITasksDAO</c> provides the outline for a Data Access Object for Tasks
    /// <br></br>
    /// Author(s): Gabriel Cepleanu
    /// <br></br>
    /// Version: 0.1
    /// </summary>
    public interface ITasksDAO
	{
        /// <summary>
        /// Method <c>GetAllTasks</c> returns all tasks from the database.
        /// </summary>
        /// <returns>List of Task objects</returns>
        public Task<List<TaskModel>> GetAllTasks();

        /// <summary>
        /// Method <c>GetUserTasks</c> returns all tasks matching a given user ID.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>List of Task objects</returns>
        public Task<List<TaskModel>> GetUserTasks(string userId);

        /// <summary>
        /// Method <c>GetTask</c> returns a task with the matching ID.
        /// </summary>
        /// <param name="id">Task ID</param>
        /// <returns>Task object</returns>
        public Task<TaskModel> GetTask(string id);

        /// <summary>
        /// Method <c>AddTask</c> adds a new task entry to the database.
        /// </summary>
        /// <param name="task">New task</param>
        /// <returns>Method status</returns>
        public Task<bool> AddTask(TaskModel task);

        /// <summary>
        /// Method <c>UpdateTask</c> updates an existing task entry from the database.
        /// </summary>
        /// <param name="updated">Updated task</param>
        /// <returns>Method status</returns>
        public Task<bool> UpdateTask(TaskModel updated);

        /// <summary>
        /// Method <c>DeleteTask</c> removes an existing task from the database.
        /// </summary>
        /// <param name="id">Task ID</param>
        /// <returns>Method status</returns>
        public Task<bool> DeleteTask(string id);

	}
}

