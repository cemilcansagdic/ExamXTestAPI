using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamXTestAPI.Models.EFModels;

namespace ExamXTestAPI.Models
{
    public class Question:IEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public List<PotentialAnswer> PotentialAnswers { get; set; }
        public string CorrectAnswer { get; set; }
        public Topic Topic { get; set; }
        public Subject Subject { get; set; }
        public Teacher Owner { get; set; }

        public Question()
        {
           
        }

    }
}

