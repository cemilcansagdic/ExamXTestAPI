using System;
using System.Collections.Generic;

namespace ExamXTestAPI.Models.EFModels
{
    public class Student:User
    {
        public List<TeacherStudents> TeacherStudents { get; set; }

        public Student()
        {
        }
    }
}

