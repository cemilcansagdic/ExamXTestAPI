using System;
using System.Reflection.Emit;
using ExamXTestAPI.Models.EFModels;
using Microsoft.EntityFrameworkCore;

namespace ExamXTestAPI.Models
{
    public class ExamXContext:DbContext
    {
        public DbSet<AnsweredQuestion> AnsweredQuestions { get; set; }
        public DbSet<PotentialAnswer> PotentialAnswers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TeacherStudents> TeacherStudents { get; set; }
        public DbSet<LoginLog> LoginLogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            {
                modelBuilder.Entity<User>()
                    .HasDiscriminator<string>("Type")
                    .HasValue<User>("User")
                    .HasValue<Student>("Student")
                    .HasValue<Teacher>("Teacher");
            }

            modelBuilder.Entity<TeacherSubject>()
            .HasKey(bc => new { bc.TeacherID, bc.SubjectId });

            modelBuilder.Entity<TeacherSubject>()
                .HasOne<Subject>(bc => bc.Subject)
                .WithMany(b => b.TeacherSubjects)
                .HasForeignKey(bc => bc.SubjectId);

            modelBuilder.Entity<TeacherSubject>()
               .HasOne<Teacher>(bc => bc.Teacher)
               .WithMany(b => b.TeacherSubjects)
               .HasForeignKey(bc => bc.TeacherID);

            modelBuilder.Entity<TeacherStudents>()
           .HasKey(bc => new { bc.TeacherID, bc.StudentID });

            modelBuilder.Entity<TeacherStudents>()
                .HasOne<Student>(bc => bc.Student)
                .WithMany(b => b.TeacherStudents)
                .HasForeignKey(bc => bc.StudentID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TeacherStudents>()
               .HasOne<Teacher>(bc => bc.Teacher)
               .WithMany(b => b.TeacherStudents)
               .HasForeignKey(bc => bc.TeacherID)
               .OnDelete(DeleteBehavior.NoAction);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public ExamXContext(DbContextOptions<ExamXContext> options) : base(options)
        {

           

        }
    }
}

