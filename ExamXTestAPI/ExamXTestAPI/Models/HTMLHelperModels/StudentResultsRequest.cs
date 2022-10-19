using System;
using System.Collections.Generic;

namespace ExamXTestAPI.Models.HTMLHelperModels
{
    public class StudentResultsRequest
    {
        public int Studentid { get; set; }
        public int Subjectid { get; set; }
        public List<string> Topics { get; set; }

        public StudentResultsRequest()
        {

        }
    }
}

