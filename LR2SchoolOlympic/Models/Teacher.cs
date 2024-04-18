using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LR2SchoolOlimpic.Models
{
    public enum TeacherState
    {
        PreparingStudents,
        NotPreparingStudents
    }
    internal class Teacher(string name, string surname)
    {

        public string Name { get; } = name;
        public string Surname { get; } = surname;
        public TeacherState State { get; set; } = TeacherState.NotPreparingStudents;
        public Task PreparationPlan { get; set; }

        public void CreatePreparationPlan(string title, int quantityOfQuestions)
        {
            PreparationPlan = new Task(title, quantityOfQuestions);
            State = TeacherState.PreparingStudents;
        }

        public void CheckStudentsResults()
        {
            State = TeacherState.NotPreparingStudents;
        }
    }
}
