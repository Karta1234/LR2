namespace LR2SchoolOlimpic.Models;

public class OrganizitingCommittee
{
    public enum OrganizitingCommitteeState
    {
        StartedOlympiad,
        NotStarted
    }
    public string Location { get; set; }
    public DateTime StartTime { get; set; }
    public Olympiad Olympiad;
    public CentralCommission CentralCommission;
    public Jury Jury;
    public Participants Participants;
    public OrganizitingCommitteeState State = OrganizitingCommitteeState.NotStarted;

    public OrganizitingCommittee(string location, DateTime date)
    {
        this.Location = location;
        this.StartTime = date;
        Olympiad = new Olympiad();
    }

    public void StartOlympiad()
    {
        if (State == OrganizitingCommitteeState.NotStarted)
        {
            CentralCommission = new CentralCommission();
            Jury = new Jury();
            Olympiad.StartOlympiad();
            State = OrganizitingCommitteeState.StartedOlympiad;
        }
        else throw new WrongStateException("Олимпиада уже начата");
    }

    public void TakeListOfParticipants(Participants participants)
    {
        if (State == OrganizitingCommitteeState.StartedOlympiad)
        {
            this.Participants = participants;
        }
        else throw new WrongStateException("Олимпиада не начата");
    }

    public void GiveTaskToParticipants()
    {
        if (State == OrganizitingCommitteeState.StartedOlympiad)
        {
            Participants.TakeTask(CentralCommission.Task);
        }
        else throw new WrongStateException("Олимпиада не начата");
    }
    public class WrongStateException : Exception
    {
        public WrongStateException(string message) : base(message)
        {
        }
    }
}