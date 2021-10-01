using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SQLiteTest.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Username { get; set; }
        public Boolean IsAdmin { get; set; }
        public string Password { get; set; }
        public ICollection<UserAnswers> UserAnswers { get; set; }
    }
}
