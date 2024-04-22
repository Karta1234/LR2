using System.Diagnostics;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LR2SchoolOlimpic.Models;

[TestFixture]
public class Test
{
    [Test]
    public void CentralCommissionFieldTest()
    {
        CentralCommission centralCommission = new CentralCommission();
        centralCommission.Task = new Task("title", 10);
        Assert.That(centralCommission.Task.Title, Is.EqualTo("title"));
        Assert.That(centralCommission.Task.QuantityOfQuestions, Is.EqualTo(10));
    }

    [Test]
    public void JuryFieldTest()
    {
        Jury jury = new Jury();
        List<Student> list = new List<Student>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(new Student("John", " Doe"));
        }
        jury.GradeList = list;
        Assert.That(jury.GradeList, Is.EqualTo(list));
    }

    [Test]
    public void OlympiadFieldTest()
    {
        Olympiad olympiad = new Olympiad();
        Assert.That(olympiad.State, Is.EqualTo(Olympiad.OlympiadState.NotStarted));
    }

    [Test]
    public void OrganizationCommFieldTest()
    {
        string location = "Izhevsk";
        DateTime date = DateTime.Today;
        OrganizitingCommittee organizitingCommittee = new OrganizitingCommittee(location, date);
        Assert.That(organizitingCommittee.Location, Is.EqualTo(location));
        Assert.That(organizitingCommittee.StartTime, Is.EqualTo(date));
    }

    [Test]
    public void PaticipantsFieldTest()
    {
        List<Student> list = new List<Student>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(new Student("John", " Doe"));
        }

        Participants participants = new Participants(list);
        Assert.That(participants.Students, Is.EqualTo(list));
    }

    [Test]
    public void StudentFieldTest()
    {
        Student student = new Student("John", " Doe");
        Assert.That(student.Name, Is.EqualTo("John"));
        Assert.That(student.Surname, Is.EqualTo(" Doe"));
    }

    [Test]
    public void TaskFieldTest()
    {
        Task task = new Task("Math", 10);
        Assert.That(task.Title, Is.EqualTo("Math"));
        Assert.That(task.QuantityOfQuestions, Is.EqualTo(10));
    }

    [Test]
    public void TeacherFiledTest()
    {
        Teacher teacher = new Teacher("John", " Doe");
        Assert.That(teacher.Name, Is.EqualTo("John"));
        Assert.That(teacher.Surname, Is.EqualTo(" Doe"));
    }

    [Test]
    public void WorkTestField()
    {
        Work work = new Work();
        Assert.That(work.Grade, Is.EqualTo(0));
    }

    [Test]
    public void CentralCommissionMethodTest()
    {
        CentralCommission commission = new CentralCommission();
        commission.CreateTask("title", 10);
        Assert.That(commission.Task.Title, Is.EqualTo("title"));
        Assert.That(commission.Task.QuantityOfQuestions, Is.EqualTo(10));
        Assert.That(commission.State, Is.EqualTo(CentralCommission.CentralCommissionState.PreparingTask));
    }
    public void CentralCommissionMethodTest2()
    {
        CentralCommission commission = new CentralCommission();
        commission.CreateTask("title", 10);
        commission.setStateNotPreparingTask();
        Assert.That(commission.State, Is.EqualTo(CentralCommission.CentralCommissionState.NotPreparingTask));
    }

    [Test]
    public void JuryMethodTest()
    {
        Jury jury = new Jury();
        List<Student> list = new List<Student>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(new Student("John", " Doe"));
        }

        Participants participants = new Participants(list);
        jury.CreateGradeList(participants);
        Assert.That(jury.GradeList, Is.EqualTo(list));
        Assert.That(jury.State, Is.EqualTo(Jury.JuryState.CalculateGradeList));
    }

    [Test]
    public void OlympiadMethodTest()
    {
        Olympiad olympiad = new Olympiad();
        olympiad.StartOlympiad();
        Assert.That(olympiad.State, Is.EqualTo(Olympiad.OlympiadState.Started));
        olympiad.EndOlimpiad();
        Assert.That(olympiad.State, Is.EqualTo(Olympiad.OlympiadState.NotStarted));
    }

    [Test]
    public void ParticipantsMethodTest()
    {
        List<Student> list = new List<Student>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(new Student("John", " Doe"));
        }
        Participants participants = new Participants(list);
        Task task = new Task("title", 10);
        participants.TakeTask(task);
        Assert.That(participants.State, Is.EqualTo(Participants.ParticipantsState.TakeTask));
        participants.SolveTask();
        Assert.That(participants.State, Is.EqualTo(Participants.ParticipantsState.SolveTask));
    }

    [Test]
    public void StudentMethodTest()
    {
        Student student = new Student("John", " Doe");
        Task task = new Task("title", 10);
        student.SolveTask(task);
        Assert.That(student.Stage, Is.EqualTo(Student.SrudentStage.Participant));
        student.SetWinnerStage();
        Assert.That(student.Stage, Is.EqualTo(Student.SrudentStage.Winner));
        student.SetPrizeWinnerStage();
        Assert.That(student.Stage, Is.EqualTo(Student.SrudentStage.prizeWinners));
    }

    [Test]
    public void TeacherMethodTest()
    {
        Teacher teacher = new Teacher("John", " Doe");
        teacher.CreatePreparationPlan("title", 10);
        Assert.That(teacher.State, Is.EqualTo(Teacher.TeacherState.PreparingStudents));
        teacher.CheckStudentsResults();
        Assert.That(teacher.State, Is.EqualTo(Teacher.TeacherState.NotPreparingStudents));
    }

    [Test]
    public void WorkMerhodTest()
    {
        Work work = new Work();
        work.SolveTask(100);
        ClassicAssert.NotNull(work.Grade);
    }
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
    public void FourthPathTest()
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
    public void ThirthPathTest()
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
    public void FirstPathTest()
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
            Assert.That(student.Stage, Is.EqualTo(Student.SrudentStage.Winner));
        }
    }
    [Test]
    public void SecondPathTest()
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
        foreach (var student in prizeWinners)
        {
            ClassicAssert.NotNull(student.Work.Grade);
            Assert.That(student.Stage, Is.EqualTo(Student.SrudentStage.prizeWinners));
        }
    }
}