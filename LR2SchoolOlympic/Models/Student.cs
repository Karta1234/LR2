

namespace LR2SchoolOlimpic.Models
{
    public class Student(string name, string surname)
    {
        public enum SrudentStage
        {
            Participant,
            Winner,
            prizeWinners
        }
        public string Name { get; set; } = name;
        public string Surname { get; set;} = surname;
        public SrudentStage Stage = SrudentStage.Participant;
        public Work Work { get; set; }

        internal void SolveTask(Task task)
        {
            this.Work = new Work();
            this.Work.SolveTask(task.QuantityOfQuestions);
        }

        public void SetWinnerStage()
        {
            Stage = SrudentStage.Winner;
        }

        public void SetPrizeWinnerStage()
        {
            Stage = SrudentStage.prizeWinners;
        }
    }
}