using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal class PracticalExam:Exam
    {
        
            public PracticalExam(TimeOnly timeOnly, int NumberofQuestion) :base(timeOnly, NumberofQuestion) { }
        public override void ShowExam()
        {
            Console.WriteLine("Practical Exam:");
            Console.WriteLine();
            Console.WriteLine("Correct Answers");
            int i = 1;
            foreach (var question in QuestionList)
            {
                Console.WriteLine($"Question {i} \n Answer : {question.answerList[question.CorrectAnswer-1]}\n");
                i++;
            }
           
        }
        
    }

    }

