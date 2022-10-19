using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamXTestAPI.Models.EFModels;

namespace ExamXTestAPI.Models
{
    public class Topic:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }

        public Topic()
        {

        }
    }
}

