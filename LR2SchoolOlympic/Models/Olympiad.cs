namespace LR2SchoolOlimpic.Models;

public class Olympiad
{
    public enum OlimpiadState
    {
        Started,
        NotStarted
    }
    public OlimpiadState State { get; set; } = OlimpiadState.NotStarted;
    public void StartOlympiad()
    {
        State = OlimpiadState.Started;
    }

    public void EndOlimpiad()
    {
        State = OlimpiadState.NotStarted;
    }

}