using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLiteTest.Models
{
    public class UserAnswers
    {
        public int Id { get; set; }
        public int AnswerID { get; set; }
        public Answer Answer { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }
    }
}
