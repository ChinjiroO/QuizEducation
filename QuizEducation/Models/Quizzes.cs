using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace QuizEducation.Models
{
    public class Quizzes
    {
        public string id { get; set; }
        public string title { get; set; }
        public string imageUrl { get; set; }
        public string description { get; set; }
        public string createdBy { get; set; }
    }
}
