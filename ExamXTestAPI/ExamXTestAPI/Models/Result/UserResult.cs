using System;
namespace ExamXTestAPI.Models.Result
{
    public class UserResult:Result
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }

        public UserResult()
        {
        }
    }
}

