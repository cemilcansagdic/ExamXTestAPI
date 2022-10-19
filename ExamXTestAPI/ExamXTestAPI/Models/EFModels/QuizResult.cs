using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamXTestAPI.Models.EFModels;

namespace ExamXTestAPI.Models
{
    public class QuizResult:IEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public List<AnsweredQuestion> AnsweredQuestions { get; set; }
        public Subject Subject { get; set; }
        public int Score { get; set; }
        public User QuizTaker { get; set; }

       
    }
}

