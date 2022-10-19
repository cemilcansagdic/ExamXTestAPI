using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamXTestAPI.Models.EFModels
{
    public class TeacherStudents
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }

        public Subject Subject { get; set; }

        public TeacherStudents()
        {

        }
    }
}

