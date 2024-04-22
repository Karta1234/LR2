namespace LR2SchoolOlimpic.Models;

public class Olympiad
{
    public enum OlympiadState
    {
        Started,
        NotStarted
    }
    public OlympiadState State { get; set; } = OlympiadState.NotStarted;
    public void StartOlympiad()
    {
        State = OlympiadState.Started;
    }

    public void EndOlimpiad()
    {
        State = OlympiadState.NotStarted;
    }

}