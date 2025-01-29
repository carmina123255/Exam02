using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal abstract  class Question:IComparable<Question>
    {
        public string? HeaderOfQuestion { get; set; }
        public string? BodyOfQuestion { get; set; }
        public int Mark { get; set; }
        public Answer[] answerList { get; set; }
        public int CorrectAnswer { get; set; }
        public static int TotalGrade = 0;

        public Question(string? HeaderOfQuestion, string? BodyOfQuestion, int Mark, int CorrectAnswer)
        {
            this.HeaderOfQuestion = HeaderOfQuestion;
            this.BodyOfQuestion = BodyOfQuestion;
            this.Mark = Mark;
            this.CorrectAnswer = CorrectAnswer;
            TotalGrade += Mark;
            
            answerList = new Answer[5];

        }


        public bool CheckAnswer(int correct)
        {
            return CorrectAnswer == correct;
        }

        public int CompareTo(Question? other)
        {
            return Mark.CompareTo(other?.Mark);
        }

        public abstract void ShowQuestion();
        
      
        
       
    }
}
