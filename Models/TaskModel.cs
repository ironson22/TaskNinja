using System;
using MongoDB.Bson;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskNinja.Models
{
    /// <summary>
    /// Class <c>TaskModel</c> represents a Task object from the database.
    /// <br></br>
    /// Author(s): Gabriel Cepleanu
    /// <br></br>
    /// Version: 0.1
    /// </summary>
    public class TaskModel
	{
        [DisplayName("ID")]
        public ObjectId _id { get; set; }

        [DisplayName("User ID")]
        [Required]
        public ObjectId userId { get; set; }

        [Required]
        [DisplayName("Task Name")]
        public string taskName { get; set; }

        [Required]
        [DisplayName("Task Status")]
        public bool status { get; set; }

        public TaskModel(dynamic id, dynamic userId, string taskName, bool status)
        {
            _id = id;
            this.userId = userId;
            this.taskName = taskName;
            this.status = status;
        }

        public TaskModel()
		{
		}
	}
}

