using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2SchoolOlimpic.Models
{
    public class Participants(List<Student> students)
    {
        public enum ParticipantsState
        {
            NotPreparingTask,
            TakeTask,
            SolveTask
        }
        public List<Student> Students { get; set; } = students;
        public Task Task { get; set; }

        public ParticipantsState State = ParticipantsState.NotPreparingTask;
        public void TakeTask(Task task)
        {
            if (State == ParticipantsState.NotPreparingTask)
            {
                this.Task = task;
                State = ParticipantsState.TakeTask;
            } else throw new WrongStateException("Участники еще не получили задания");
        }
        public void SolveTask()
        {
            if (State == ParticipantsState.TakeTask)
            {
                if (Task != null)
                {
                    foreach (var student in Students)
                    {
                        student.SolveTask(Task);
                    }
                }
                State = ParticipantsState.SolveTask;
            }
            else throw new WrongStateException("Участники еще не получили задания");
        }
        public class WrongStateException : Exception
        {
            public WrongStateException(string message) : base(message)
            {
            }
        }
    }
}
