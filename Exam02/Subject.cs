using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal class Subject
    {
        public int Id {  get; set; }
        public string? SubjectName { get; set; }
        public Exam Exam { get; set; }

        public Subject(int Id , string? SubjectName) {
        this.Id = Id;
         this.SubjectName = SubjectName;
         
        }
        public Subject()
        {
            
        }
        public void CreateExam(Exam exam)
        {
            Exam = exam;
        }
       

        public void SubjectInfo()
        {
            Console.WriteLine($"Subject ID: {Id}, Subject Name: {SubjectName}");
            
        }
    }
    }

