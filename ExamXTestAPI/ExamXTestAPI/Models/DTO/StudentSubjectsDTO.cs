using System;
namespace ExamXTestAPI.Models.DTO
{
    public class StudentSubjectsDTO
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        public StudentSubjectsDTO()
        {
        }
    }
}

