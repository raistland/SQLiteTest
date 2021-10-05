using Microsoft.EntityFrameworkCore;
using SQLiteTest.Models;

namespace SQLiteTest
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UserAnswers> UserAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .HasOne<Question>(b => b.Question)
                .WithMany(p => p.Answers)
                .HasForeignKey(k => k.QuestionID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserAnswers>()
                .HasKey(k => new { k.AnswerID, k.UserID });
            modelBuilder.Entity<UserAnswers>()
                .HasOne(k => k.Answer)
                .WithMany(k => k.UserAnswers)
                .HasForeignKey(k => k.AnswerID);
            modelBuilder.Entity<UserAnswers>()
                .HasOne(k => k.User)
                .WithMany(k => k.UserAnswers)
                .HasForeignKey(k => k.UserID);

            modelBuilder.Entity<Question>()
              .HasData(
                  new Question
                  {
                      Id = 1,
                      Text = @"Soru 1"
                  },
                  new Question { Id = 2, Text = "Soru 2" });

            modelBuilder.Entity<Answer>()
                .HasData(
                new Answer
                {
                    Id = 1,
                    Text = "Cevap 1",
                    IsTrue = false,
                    SelectedTime = 1,
                    QuestionID = 1
                },
                new Answer
                {
                    Id = 2,
                    Text = "Cevap 2",
                    IsTrue = false,
                    SelectedTime = 0,
                    QuestionID = 1
                },
                new Answer
                {
                    Id = 3,
                    Text = "Cevap 3",
                    IsTrue = true,
                    SelectedTime = 0,
                    QuestionID = 1
                }

                );

            modelBuilder.Entity<User>()
                .HasData
                (new User

                {
                    IsAdmin = true,
                    Name = "Admin User",
                    Password = "admin",
                    UserName = "admin"
                },
                new User
                {
                    IsAdmin = false,
                    Name = "End User 1",
                    Password = "enduser1",
                    UserName  = "enduser"
                }
                );

            
        }
    }
}