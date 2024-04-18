using System.Runtime.CompilerServices;

namespace LR2SchoolOlimpic.Models;

public class Jury
{
    public enum JuryState
    {
        NotCalculateResults,
        CalculateGradeList,
        CalculateRating
    }
    public List<Student> GradeList = new List<Student>();
    public List<Student> AboveAverageStudents { get;}= new List<Student>();
    public List<Student> winners = new List<Student>();
    public List<Student> prizeWinners = new List<Student>();

    public JuryState State = JuryState.NotCalculateResults;
    public void CreateGradeList(Participants participants)
    {
        if (State == JuryState.NotCalculateResults)
        {
            foreach (var student in participants.Students)
            {
                GradeList.Add(student);
            }

            State = JuryState.CalculateGradeList;
        }
        else throw new WrongStateException("Жюри уже подсчитали результаты");
    }

    public void CalculateGradeListRegular()
    {
        if (State == JuryState.CalculateGradeList)
        {
            double averageGrade = GradeList.Average(student => student.Work.Grade);
            List<Student> aboveAverageStudents = GradeList.Where(student => student.Work.Grade > averageGrade).ToList();
            State = JuryState.CalculateRating;
        }
        else throw new WrongStateException("Жюри еще не подсчитали результаты");
    }

    public void CalculateGradeListLastPhase()
    {
        if (State == JuryState.CalculateGradeList)
        {
       
            List<Student> sortedList = GradeList.OrderByDescending(student => student.Work.Grade).ToList();

       
            int totalParticipants = sortedList.Count;
            int winnersCount = (int)Math.Ceiling(totalParticipants * 0.08); // 8% лучших
            int prizeWinnersCount = (int)Math.Ceiling(totalParticipants * 0.30); // 30% лучших

     
            winners = sortedList.Take(winnersCount).ToList();
            prizeWinners = sortedList.Skip(winnersCount).Take(prizeWinnersCount)
                .Where(student => student.Work.Grade >= 50).ToList(); // Только те, у кого баллов не менее 50
            State = JuryState.CalculateRating;
            foreach (var student in winners)
            {
                student.SetWinnerStage();
            }

            foreach (var student in prizeWinners)
            {
                student.SetWinnerStage();
            }
        } else throw new WrongStateException("Жюри еще не подсчитали результаты");
    }

    public void SetNotCalculateResults()
    {
        State = JuryState.NotCalculateResults;
    }
    public class WrongStateException : Exception
    {
        public WrongStateException(string message) : base(message)
        {
        }
    }
}