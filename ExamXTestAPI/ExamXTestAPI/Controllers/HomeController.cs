using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExamXTestAPI.Models;
using ExamXTestAPI.Models.DTO;
using ExamXTestAPI.Models.EFModels;
using ExamXTestAPI.Models.HTMLHelperModels;
using ExamXTestAPI.Models.Result;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamXTestAPI.Controllers
{
    [ApiController]
    [Route("")]
    [EnableCors("MyPolicy")]
    public class HomeController : Controller
    {
        public static List<User> users = new List<User>
        {
            new User("MehmetCan","0192","Mehmet Can Diri"),
            new User("Cemilcan","1293","Cemilcan Sağdıç"),
            new User("Şükrü","3214","Şükrü Yiğit")
        };
        private ExamXContext _Context;

        public List<Question> ShuffleQuestionAnswers(List<Question> questions)
        {
            List<Question> shuffledQuestions = new List<Question>();
            foreach (var item in questions)
            {
                //Work In Progress
            }
            return shuffledQuestions;
        }


        public HomeController(ExamXContext Context)
        {
            _Context = Context;

            /*
           TeacherSubject subjects = new TeacherSubject();

           Subject subject = Context.Subjects.First();
           Teacher teacher = Context.Teachers.First();

           subjects.Teacher = teacher;
           subjects.TeacherID = teacher.ID;
           subjects.Subject = subject;
           subjects.SubjectId = subject.ID;

           Context.Add(subjects);
           Context.SaveChanges();
            */


            /* Teacher teacher = Context.Teachers.Where(x => x.Username.Equals("Şükrü")).Include(x=>x.TeacherSubjects).First();
             TeacherSubject ts = new TeacherSubject();

             ts.Teacher = teacher;
             ts.TeacherID = teacher.ID;
             Subject subject = Context.Subjects.Where(x => x.Name.Equals("Mathematics")).Include(x=>x.Topics).First();
             ts.Subject = subject;
             ts.SubjectId = subject.ID;
             teacher.TeacherSubjects.Add(ts);
             Context.SaveChanges();*/
        }

        public IActionResult Index()
        {
            return RedirectToAction("SendQuestions");
        }

       [EnableCors("MyPolicy")]
       [HttpPost("/api/addUser")]
        public void AddNewUser([FromBody]User user)
        {
            _Context.Users.Add(user);
            _Context.SaveChanges();
        }

        public UserResult loginWithCredentials(string username, string password)
        {
            UserResult result = new UserResult();
            try
            {
                List<User> users = _Context.Users.ToList();
                User user = users.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).First();
                if (user == null)
                {
                    result.Success = false;
                    result.Message = "Kullanıcı Bulunamadı!";
                    return result;
                }
                result.UserID = user.ID;
                result.FullName = user.FullName;
                result.Role = user.GetType().ToString().Split('.').Last();
                result.Message = "Kullanıcı Bulundu!";
                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = "Bir Hata Oluştu: " + ex.Message;
                result.Success = false;
                return result;
            }
        }


        [EnableCors("MyPolicy")]
        [HttpPost("/api/SendQuestions")]
        public IEnumerable<Question> SendQuestions([FromBody]Subject cat)
        {
            List<Question> questiondata = _Context.Questions.Include(x=>x.PotentialAnswers).Where(x => x.Subject.ID == cat.ID).ToList();
                return questiondata;
        }

        [EnableCors("MyPolicy")]
        [HttpPost]
        [Route("/api/send")]
        public QuizResult GetTest([FromBody]QuizSubmit submittedQuiz )
        {
            submittedQuiz.User = _Context.Users.Where(x => x.ID == submittedQuiz.User.ID).First();
            QuizResult result = submittedQuiz.GetQuizResult();
            result.Subject = _Context.Subjects.Where(x => x.ID == submittedQuiz.SubjectID).First();
            _Context.QuizResults.Add(result);
            _Context.SaveChanges();
            return result;
        }

        [EnableCors("MyPolicy")]
        [HttpPost]
        [Route("/api/getquizresults")]
        public List<QuizResult> GetQuizResults([FromBody]string name)
        {
            return _Context.QuizResults.Where(x => x.QuizTaker.Equals(name)).ToList();
        }

        [EnableCors("MyPolicy")]
        [HttpPost]
        [Route("/api/getsubjectquizresults")]
        public List<QuizResult> GetQuizResultsWithSubject([FromBody]StudentResultsRequest request)
        {
            return _Context.QuizResults
                .Where(x => x.QuizTaker.ID == request.Studentid && x.Subject.ID == request.Subjectid)
                .Include(x=>x.AnsweredQuestions)
                .Include(x=>x.QuizTaker)
                .ToList();
        }

        [EnableCors("MyPolicy")]
        [HttpPost]
        [Route("/api/getteacherstudents")]
        public List<StudentSubjectsDTO> GetTeacherStudents([FromBody]int id)
        {
            List<TeacherStudents> students = _Context.TeacherStudents.Where(x => x.TeacherID == id).Include(x=>x.Subject).Include(x=>x.Student).ToList();

            List<StudentSubjectsDTO> dto = new List<StudentSubjectsDTO>();

            foreach (var item in students)
            {
                StudentSubjectsDTO d = new StudentSubjectsDTO();
                d.StudentID = item.StudentID;
                d.StudentName = item.Student.FullName;
                d.SubjectID = item.Subject.ID;
                d.SubjectName = item.Subject.Name;
                dto.Add(d);
            }

            return dto;
        }

        [EnableCors("MyPolicy")]
        [HttpPost]
        [Route("/api/getstudentquizresult")]
        public QuizResult GetQuizResult([FromBody] int quizid)
        {
            return _Context.QuizResults.Where(x => x.ID == quizid).Include(x => x.AnsweredQuestions).First();
        }

        [EnableCors("MyPolicy")]
        [HttpPost]
        [Route("/api/getstudentresults")]
        public List<QuizResult> GetStudentQuizResults([FromBody]int studentid)
        {
            return _Context.QuizResults.Where(x => x.QuizTaker.ID == studentid).Include(x => x.AnsweredQuestions).Include(x=>x.QuizTaker.ID).Include(x=>x.QuizTaker.FullName).ToList();
        }

        [EnableCors("MyPolicy")]
        [HttpPost]
        [Route("/api/getstudentresultsbysubject")]
        public List<QuizResult> GetStudentQuizResultsBySubject([FromBody] StudentResultsRequest request)
        {
            List<QuizResult> res =  _Context.QuizResults
                .Where(x => x.QuizTaker.ID == request.Studentid && x.Subject.ID == request.Subjectid)
                .Include(x => x.AnsweredQuestions)
                .Include(x=>x.QuizTaker)
                .ToList();

            return res;
        }


        /*[EnableCors("MyPolicy")]
        [HttpPost]
        [Route("/api/getsubjecttopicquizresults")]
        public List<QuizResult> GetQuizResultWithSubjectAndTopic([FromBody] StudentResultsRequest request)
        {
            List<QuizResult> results =  _Context.QuizResults.Where(x => x.QuizTaker.Equals(request.studentname) && x.Subject.Equals(request.subject)).ToList();
            //Test Edilicek
            List<QuizResult> filteredByTopics = results.Where(x => x.AnsweredQuestions.Select(x => x.Question).Select(x => x.Topic).ToList().Intersect(request.Topics).Any()).ToList();
            return filteredByTopics;
        }*/

        [EnableCors("MyPolicy")]
        [HttpPost]
        [Route("/api/questionadd")]
        public bool AddQuestionToDB([FromBody]Question question)
        {
            int sid = question.Subject.ID;
            int tid = question.Topic.ID;
            question.Owner = _Context.Teachers.Where(x=>x.ID == question.Owner.ID).First();
            question.Topic = _Context.Topics.Where(x=>x.ID == tid).First();
            question.Subject = _Context.Subjects.Where(x=>x.ID == sid).First();
            //Eklerken Topic ve Subject için ayar yapılacak
            _Context.Questions.Add(question);
            _Context.SaveChanges();
            return true;
          
        }

        [EnableCors("MyPolicy")]
        [HttpPost]
        [Route("/api/teachersubjects")]
        public List<Subject> GetTeacherSubjects([FromBody] int id)
        {
            List<Subject> Subjects = _Context.TeacherSubjects.Where(x => x.TeacherID == id).Include(x=>x.Subject.Topics).Select(x => x.Subject).ToList();
            return Subjects;
        }

        [EnableCors("MyPolicy")]
        [HttpPost]
        [Route("/api/getstudentsubjects")]
        public List<Subject> GetStudentSubjects([FromBody]int id)
        {
            List<Subject> subjects = _Context.TeacherStudents.Where(x => x.StudentID == id).Include(x=>x.Subject).Select(x => x.Subject).ToList();
            return subjects;
        }

        //Alternatif
        [EnableCors("MyPolicy")]
        [HttpPost]
        [Route("/api/loginCredentials")]
        public UserResult LoginUser([FromBody]User user)
        {
            //return users.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
            return loginWithCredentials(user.Username, user.Password);
        }
    }
}

