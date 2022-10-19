using System;
using System.Collections.Generic;
using ExamXTestAPI.Models.EFModels;

namespace ExamXTestAPI.Models
{
    public class QuizSubmit
    {
        public List<AnsweredQuestion> QuizQuestions { get; set; }
        public User User { get; set; }
        public int SubjectID { get; set; }

        public QuizSubmit()
        {

        }

        public QuizResult GetQuizResult()
        {
            QuizResult result = new QuizResult();
                result.Score = 0;
                foreach (var item in QuizQuestions)
                {
                    if (item.CorrectAnswer.Equals(item.Selected))
                    {
                        result.Score++;
                    }
                }

                result.AnsweredQuestions = QuizQuestions;
         
                result.QuizTaker = User;

            return result;
            
        }
    }
}

