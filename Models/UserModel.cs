using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace TaskNinja.Models
{
	public class UserModel
	{
		[DisplayName("ID")]
		public ObjectId _id { get; set; }

		[Required]
		[DisplayName("First Name")]
		public string firstName { get; set; }

		[Required]
		[DisplayName("Last Name")]
		public string lastName { get; set; }

		[Required]
		[DisplayName("Email Address")]
		public string email { get; set; }

		[Required]
		[DisplayName("Username")]
		public string username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[DisplayName("Password")]
		public string password { get; set; }

        public UserModel(dynamic id, string firstName, string lastName, string email, string username, string password)
        {
            _id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.username = username;
            this.password = password;
        }

        public UserModel()
		{
		}
	}
}

