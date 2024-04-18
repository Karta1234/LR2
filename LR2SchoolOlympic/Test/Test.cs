using System.Diagnostics;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LR2SchoolOlimpic.Models;

[TestFixture]
public class Test
{
    [Test]
    public void CreatePreparationPlan_ShouldAddNewPlan()
    {
        Teacher teacher = new Teacher("John"," Doe");
        string planTitle = "Math Preparation Plan";
        
        teacher.CreatePreparationPlan(planTitle, 10);
        string teacherplantitle = teacher.PreparationPlan.Title;
        Assert.That(teacherplantitle, Is.EqualTo(planTitle));
    }

    [Test]
    public void CentralCommissionStateTest()
    {
        CentralCommission commission = new CentralCommission();
        ClassicAssert.AreEqual(CentralCommission.CentralCommissionState.NotPreparingTask, commission.State);
        commission.CreateTask("x",10);
        ClassicAssert.AreEqual(CentralCommission.CentralCommissionState.PreparingTask, commission.State);
    }
    
    [Test]
    public void PreparationToOlympicUseCaseTest()
    {
        Teacher teacher = new Teacher("John", " Doe");
        string planTitle = "Math";
        teacher.CreatePreparationPlan(planTitle, 100);
        List<Student> list = new List<Student>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(new Student("John", " Doe"));
        }
        Participants participants = new Participants(list);
        Assert.That(10, Is.EqualTo(participants.Students.Count) );
        participants.TakeTask(teacher.PreparationPlan);
        participants.SolveTask();
        foreach (var students in participants.Students)
        {
            ClassicAssert.NotNull(students.Work.Grade);
        }
    }

    [Test]
    public void HostingRegularOlympiadUseCaseTest()
    {
        string location = "Izhevsk";
        DateTime date = DateTime.Today;
        OrganizitingCommittee organizitingCommittee = new OrganizitingCommittee(location, date);
        List<Student> list = new List<Student>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(new Student("John", " Doe"));
        }
        Participants participants = new Participants(list);
        organizitingCommittee.StartOlympiad();
        organizitingCommittee.TakeListOfParticipants(participants);
        string title = "Math";
        int quantity = 100;
        organizitingCommittee.CentralCommission.CreateTask(title, quantity);
        organizitingCommittee.GiveTaskToParticipants();
        organizitingCommittee.Participants.SolveTask();
        foreach (var students in organizitingCommittee.Participants.Students)
        {
            ClassicAssert.NotNull(students.Work.Grade);
        }
        organizitingCommittee.Jury.CreateGradeList(organizitingCommittee.Participants);
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
        OrganizitingCommittee organizitingCommittee = new OrganizitingCommittee(location, date);
        List<Student> list = new List<Student>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(new Student("John", " Doe"));
        }
        Participants participants = new Participants(list);
        organizitingCommittee.StartOlympiad();
        organizitingCommittee.TakeListOfParticipants(participants);
        string title = "Math";
        int quantity = 100;
        organizitingCommittee.CentralCommission.CreateTask(title, quantity);
        organizitingCommittee.GiveTaskToParticipants();
        organizitingCommittee.Participants.SolveTask();
        foreach (var students in organizitingCommittee.Participants.Students)
        {
            ClassicAssert.NotNull(students.Work.Grade);
        }
        organizitingCommittee.Jury.CreateGradeList(organizitingCommittee.Participants);
        organizitingCommittee.Jury.CalculateGradeListLastPhase();
        List<Student> winners = organizitingCommittee.Jury.winners;
        List<Student> prizeWinners = organizitingCommittee.Jury.prizeWinners;
        foreach (var student in winners)
        {
            ClassicAssert.NotNull(student.Work.Grade);
        }
        foreach (var student in prizeWinners)
        {
            ClassicAssert.NotNull(student.Work.Grade);
        }
    }
}