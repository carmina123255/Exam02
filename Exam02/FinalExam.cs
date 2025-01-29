using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal class FinalExam:Exam
    {
        public FinalExam( TimeOnly timeOnly,int NumberofQuestion) :base(timeOnly,NumberofQuestion) { }
        public override void ShowExam()
        {
            Console.WriteLine("Final Exam:");
            Console.WriteLine();int j = 0;
            foreach (var question in QuestionList)
            {
                Console.WriteLine($"Question - {j+1} : {question.BodyOfQuestion}\n");
                foreach(var item in question.answerList)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
                j++;
               
            }
           
        }
    }
    }

