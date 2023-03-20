using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace TaskNinja.Models
{
    public class TaskModel
    { 
        [DisplayName("ID")]
        public ObjectId _id { get; set; }

        [Required]
        [DisplayName("User Id")]
        public string userID { get; set; }

        [Required]
        [DisplayName("Task Name")]
        public string taskName { get; set; }

        [Required]
        [DisplayName("Status")]
        public string status { get; set; }

        public TaskModel(dynamic id, string userID, string taskName, bool status)
        {
            _id = id;
            this.userID = userID;
            this.taskName = taskName;
            this.status = status;
        }

        public TaskModel()
        {
        }
    }
}

