using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SQLiteTest.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsTrue { get; set; }
        public int SelectedTime { get; set; }

        public int QuestionID { get; set; }        
        public Question Question { get; set; }

    }
}