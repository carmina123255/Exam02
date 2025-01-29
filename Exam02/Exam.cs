using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Exam02
{
    internal abstract class Exam
    {
        public TimeOnly TimeOfExam { get; set; }
        public int NumberOfQuestion { get; set; }
        public List<Question> QuestionList { get; set; }
        public FinalExam? finalExam { get; set; }
        public PracticalExam? practicalExam { get; set; }

        public Exam(TimeOnly TimeOfExam, int NumberOfQuestion)
        {
            this.TimeOfExam = TimeOfExam;
            this.NumberOfQuestion = NumberOfQuestion;
            QuestionList = new List<Question>();
        }
        public Exam()
        {
        }

        public abstract void ShowExam();

        public void TakeExam()
        {
            
            Console.WriteLine(TimeOfExam);
            Console.WriteLine(NumberOfQuestion.ToString());
            List<int> list = new List<int>();
            char ans;
            do
            {
                Console.WriteLine("Do You want to start Exam Y/N");

            } while (!char.TryParse(Console.ReadLine(), out ans));
            char toLower = char.ToLower(ans);
            if (toLower == 'n')
            {
                return;
            }
            else if (toLower == 'y')
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                int totalMark = 0;
                
                Console.WriteLine();
                Console.WriteLine("------------ Exam is started ----------");

                Console.WriteLine();
                foreach (var question in QuestionList)
                {
                    question.ShowQuestion();
                    Console.WriteLine();
                    int ansId = 0; bool flag = false;
                    if (question is TrueFalseQuestion)
                    {
                        if (stopwatch.Elapsed > TimeOfExam.ToTimeSpan())
                        {
                            Console.WriteLine("==== Time is Ended ====");
                            break;
                        }
                        do
                        {
                            Console.WriteLine("Enter Answer Id [1 for True | 2 for False ] ");
                            flag = int.TryParse(Console.ReadLine(), out ansId);
                        } while (flag && (ansId != 1 && ansId != 2));
                    }
                    else if (question is MCQQuestion)
                    {
                        do
                        {
                            Console.WriteLine("Enter Answer Id [1 for OptionA | 2 for OptionB |3 For OptionC ] ");
                            flag = int.TryParse(Console.ReadLine(), out ansId);
                        } while (flag && (ansId != 1 && ansId != 2 && ansId != 3));
                    }


                    list.Add(ansId);
                    if (question.CheckAnswer(ansId))
                    {
                        totalMark += question.Mark;
                    }

                }
                int i = 0;
                stopwatch.Stop();
                Console.WriteLine();
                Console.WriteLine("=================================================");
                foreach (var question in QuestionList)
                {
                    if (i >= list.Count) break;
                    Console.WriteLine($"{question.BodyOfQuestion}  : \n");
                    Console.WriteLine($"Your Answer Id :{question.answerList[list[i] - 1].ToString()}\n");
                    Console.WriteLine($"Corect Answer Id : {question.answerList[question.CorrectAnswer - 1].ToString() ?? "NO ANSWER"}\n");
                    i++;
                }
                Console.WriteLine();
                Console.WriteLine("**************************");
                Console.WriteLine();

                ShowExam();
                Console.WriteLine($"Your grade is : {totalMark} from {Question.TotalGrade}");
                Console.WriteLine($"Time : {stopwatch.Elapsed.ToString("mm\\:ss")}");

               
            }
        }
    }
}


