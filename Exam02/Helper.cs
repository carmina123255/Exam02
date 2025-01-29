using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal static class Helper
    {
        static Subject subject = new Subject() { Id = 101, SubjectName = "test" };
     
        static string? Header, Body;
        static int  NumberOfQuestion, ExamType = 0, Mark = 0, correctAnswer = 0;
        static bool flag = false;
       static TimeOnly time;
        public static void InformationExam()
        {
            //  string Header, Body; int time = 0, NumberOfQuestion, ExamType = 0, Mark = 0, correctAnswer = 0; bool flag = false;


            do
            {
                Console.WriteLine("Please Enter Type of Exam (1-Final Exam | 2-Practical Exam )");

            } while (!int.TryParse(Console.ReadLine(), out ExamType));


            if (ExamType != 1 && ExamType != 2)
            {
                Console.WriteLine("Invalid");
                return;
            }
            Console.WriteLine();
            int minutes = 0;
            do
            {
                Console.WriteLine("Enter Time of Exam ( from 30 Min to 80 Min )");
                flag = int.TryParse(Console.ReadLine(), out minutes);


            } while (flag && (minutes < 30 || minutes > 80));
            TimeSpan examd = TimeSpan.FromMinutes(minutes);
            time = TimeOnly.FromTimeSpan(examd);
            Console.WriteLine();
            do
            {
                Console.WriteLine("Number of Question");

            } while (!(int.TryParse(Console.ReadLine(), out NumberOfQuestion)));
            if(ExamType ==1)FExam();
            else if (ExamType ==2)PracticalExam();
        }
        //static TimeOnly timeOnly = new TimeOnly(0, time);
    
        /// /////////////////////////////////////////////////
       
        public static  void FExam()
        {
            FinalExam fExam = new FinalExam(time, NumberOfQuestion);
            for (int i = 0; i < NumberOfQuestion; i++)
            {
                int typeOfQuestion = 0;
                Console.WriteLine();
                do
                {
                    Console.WriteLine("Enter the type of Question (1-True|false 2-MCQ ) ");
                    flag = int.TryParse(Console.ReadLine(), out typeOfQuestion);
                } while (flag && (typeOfQuestion != 1 && typeOfQuestion != 2));

                if (typeOfQuestion == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter Header of Question ");
                    Header = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Enter Body Of Question");
                    Body = Console.ReadLine();
                    Console.WriteLine();
                    do
                    {
                        Console.WriteLine("Enter Mark ");

                    } while (!(int.TryParse(Console.ReadLine(), out Mark)));


                    do
                    {
                        Console.WriteLine("Enter ID of Correct Answer ");
                        flag = int.TryParse(Console.ReadLine(), out correctAnswer);
                    } while (flag && (correctAnswer != 1 && correctAnswer != 2));

                    TrueFalseQuestion TFQuestion = new TrueFalseQuestion(Header, Body, Mark, correctAnswer);//////////


                    TFQuestion.answerList[0] = new Answer(1,"True");
                    TFQuestion.answerList[1]=new Answer(2,"False");
                    fExam.QuestionList.Add(TFQuestion);
                }
                else if (typeOfQuestion == 2)
                {
                    Console.WriteLine("Enter Header of Question ");
                    Header = Console.ReadLine();
                    Console.WriteLine("Enter Body Of Question");
                    Body = Console.ReadLine();

                    {
                        Console.WriteLine("Enter Mark ");

                    } while (!(int.TryParse(Console.ReadLine(), out Mark))) ;


                    do
                    {
                        Console.WriteLine("Enter ID of Correct Answer ");
                        flag = int.TryParse(Console.ReadLine(), out correctAnswer);
                    } while (flag && (correctAnswer != 1 && correctAnswer != 2 && correctAnswer != 3));
                    MCQQuestion MQuestion = new MCQQuestion(Header, Body, Mark, correctAnswer);////
                    Console.WriteLine("Enter Choices");
                    Console.WriteLine();
                    Console.WriteLine("Enter choice 1");
                    MQuestion.answerList[0] = new Answer(1, Console.ReadLine());
                    Console.WriteLine("Enter choice 2");
                    MQuestion.answerList[1] = new Answer(2, Console.ReadLine());
                    Console.WriteLine("Enter choice 3");

                    MQuestion.answerList[2] = new Answer(3, Console.ReadLine());
                    fExam.QuestionList.Add(MQuestion);
                }
            }
            subject.CreateExam(fExam);
            Console.WriteLine();
            subject.SubjectInfo();
            fExam.TakeExam();
        }
       
        /// //////////////////
        
        public static void PracticalExam()
        {
           
            PracticalExam PExam = new PracticalExam(time, NumberOfQuestion);
            for (int i = 0; i < NumberOfQuestion; i++)
            {

                Console.WriteLine("Enter Header of Question ");
                Header = Console.ReadLine();
                Console.WriteLine("Enter Body Of Question");
                Body = Console.ReadLine();

                {
                    Console.WriteLine("Enter Mark ");

                } while (!(int.TryParse(Console.ReadLine(), out Mark))) ;


                do
                {
                    Console.WriteLine("Enter ID of Correct Answer ");
                    flag = int.TryParse(Console.ReadLine(), out correctAnswer);
                } while (flag && (correctAnswer != 1 && correctAnswer != 2 && correctAnswer != 3));
                MCQQuestion MQuestion = new MCQQuestion(Header, Body, Mark, correctAnswer);////
                Console.WriteLine("Enter Choices");
                Console.WriteLine();
                Console.WriteLine("Enter choice 1");
                MQuestion.answerList[0] = new Answer(1, Console.ReadLine());
                Console.WriteLine("Enter choice 2");
                MQuestion.answerList[1] = new Answer(2, Console.ReadLine());
                Console.WriteLine("Enter choice 3");

                MQuestion.answerList[2] = new Answer(3, Console.ReadLine());
                PExam.QuestionList.Add(MQuestion);

            }
            subject.CreateExam(PExam);
            subject.SubjectInfo();
            PExam.TakeExam();
        }
        ///////////////
        ///

      
    }
}
            
