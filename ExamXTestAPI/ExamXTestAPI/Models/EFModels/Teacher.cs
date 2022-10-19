using System;
using System.Collections.Generic;

namespace ExamXTestAPI.Models.EFModels
{
    public class Teacher:User
    {
        public List<TeacherSubject> TeacherSubjects { get; set; }

        public List<TeacherStudents> TeacherStudents { get; set; }



        public Teacher()
        {
        }
    }
}

