using System.Diagnostics;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LR2SchoolOlimpic.Models;

[TestFixture]
public class Test2
{
      [Test]
    public void HostingRegularOlympiadUseCaseTest()
    {
        string location = "Izhevsk";
        DateTime date = DateTime.Today;
        Console.WriteLine("Назначение даты и места олимпиады");
        OrganizitingCommittee organizitingCommittee = new OrganizitingCommittee(location, date);
        List<Student> list = new List<Student>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(new Student("John", " Doe"));
        }
        Console.WriteLine("Создание списка участников");
        Participants participants = new Participants(list);
        Assert.That(participants.Students, Is.EqualTo(list));
        
        organizitingCommittee.StartOlympiad();
        Console.WriteLine("Получение списка участников");
        organizitingCommittee.TakeListOfParticipants(participants);
        string title = "Math";
        int quantity = 100;
        Console.WriteLine("Создание заданий");
        organizitingCommittee.CentralCommission.CreateTask(title, quantity);
        Console.WriteLine("Раздача заданий");
        organizitingCommittee.GiveTaskToParticipants();
        Console.WriteLine("Решение заданий участниками");
        organizitingCommittee.Participants.SolveTask();
        foreach (var students in organizitingCommittee.Participants.Students)
        {
            ClassicAssert.NotNull(students.Work.Grade);
        }
        Console.WriteLine("Расчет оценок");
        organizitingCommittee.Jury.CreateGradeList(organizitingCommittee.Participants);
        Console.WriteLine("Расчет мест");
        organizitingCommittee.Jury.CalculateGradeListRegular();
        List<Student> grade = organizitingCommittee.Jury.AboveAverageStudents;
        foreach (var student in grade)
        {
            ClassicAssert.NotNull(student.Work.Grade);
        }

    }

    [Test]
    public void HostingLastPhaseOlympiadUseCaseTest()
    {
        string location = "Izhevsk";
        DateTime date = DateTime.Today;
        Console.WriteLine("Назначение даты и места олимпиады");
        OrganizitingCommittee organizitingCommittee = new OrganizitingCommittee(location, date);
        List<Student> list = new List<Student>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(new Student("John"+i, " Doe"));
        }
        Console.WriteLine("Создание списка участников");
        Participants participants = new Participants(list);
        organizitingCommittee.StartOlympiad();
        Console.WriteLine("Получение списка участников");
        organizitingCommittee.TakeListOfParticipants(participants);
        string title = "Math";
        int quantity = 100;
        Console.WriteLine("Создание заданий");
        organizitingCommittee.CentralCommission.CreateTask(title, quantity);
        Console.WriteLine("Раздача заданий");
        organizitingCommittee.GiveTaskToParticipants();
        Console.WriteLine("Решение заданий участниками");
        organizitingCommittee.Participants.SolveTask();
        foreach (var students in organizitingCommittee.Participants.Students)
        {
            ClassicAssert.NotNull(students.Work.Grade);
        }
        Console.WriteLine("Расчет оценок");
        organizitingCommittee.Jury.CreateGradeList(organizitingCommittee.Participants);
        organizitingCommittee.Jury.CalculateGradeListLastPhase();
        List<Student> winners = organizitingCommittee.Jury.winners;
        List<Student> prizeWinners = organizitingCommittee.Jury.prizeWinners;
        Console.WriteLine("Победители");
        foreach (var student in winners)
        {
            ClassicAssert.NotNull(student.Work.Grade);
            Console.WriteLine(student.Name," ", student.Work.Grade);
        }
        Console.WriteLine("Призеры");
        foreach (var student in prizeWinners)
        {
            ClassicAssert.NotNull(student.Work.Grade);
            Console.WriteLine(student.Name," ", student.Work.Grade);
        }
    }
    [Test]
    public void PreparationToOlympicUseCaseTest2()
    {
        Teacher teacher = new Teacher("John", " Doe");
        string planTitle = "Math";
        Console.WriteLine("Создание плана подготовки");
        teacher.CreatePreparationPlan(planTitle, 100);
        List<Student> list = new List<Student>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(new Student("John", " Doe"));
        }
        Console.WriteLine("Создание списка учеников");
        Participants participants = new Participants(list);
        Assert.That(10, Is.EqualTo(participants.Students.Count) );
        Console.WriteLine("Получение задания");
        participants.TakeTask(teacher.PreparationPlan);
        Console.WriteLine("Решение задания");
        participants.SolveTask();
        foreach (var students in participants.Students)
        {
            ClassicAssert.NotNull(students.Work.Grade);
        }
    }
}