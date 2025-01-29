using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal class MCQQuestion:Question
    {
        
        public MCQQuestion(string? HeaderOfQuestion, string? BodyOfQuestion, int Mark,int Correct):base(HeaderOfQuestion, BodyOfQuestion, Mark,Correct) 
        {
          

        }

      

        public override void ShowQuestion()
        {
            Console.WriteLine($"{this.BodyOfQuestion}  Mark : {this.Mark}\n");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(this.answerList[i].ToString());

            }
        }
    }
}
