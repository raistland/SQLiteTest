using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SQLiteTest.Models
{
    public class Question
    {
       [Required]
        public int Id { get; set; }
      
        public string Text { get; set; }
        
        public ICollection<Answer> Answers { get; set; }

    }
}
