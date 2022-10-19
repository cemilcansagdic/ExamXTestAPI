using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamXTestAPI.Models.EFModels
{
    public class LoginLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int UserID { get; set; }
        public string TriedPassword { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public bool Success { get; set; }

        public LoginLog()
        {
        }
    }
}

