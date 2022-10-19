using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamXTestAPI.Models.EFModels;

namespace ExamXTestAPI.Models
{
    public class User:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public User()
        {

        }

        public User(string username, string password, string fullname)
        {
            Username = username;
            Password = password;
            FullName = fullname;
        }


    }
}

