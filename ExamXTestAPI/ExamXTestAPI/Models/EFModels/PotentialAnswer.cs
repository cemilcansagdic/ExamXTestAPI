using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamXTestAPI.Models.EFModels
{
    public class PotentialAnswer:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Answer { get; set; }

        public PotentialAnswer()
        {

        }
    }
}

