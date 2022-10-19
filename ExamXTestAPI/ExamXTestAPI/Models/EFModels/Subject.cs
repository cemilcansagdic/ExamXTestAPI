using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamXTestAPI.Models.EFModels;

namespace ExamXTestAPI.Models
{
    public class Subject:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Topic> Topics { get; set; }
        public List<TeacherSubject> TeacherSubjects { get; set; }

        public Subject()
        {
        }
    }
}

