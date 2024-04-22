namespace LR2SchoolOlimpic.Models;



public class CentralCommission
{
    public enum CentralCommissionState
    {
        PreparingTask,
        NotPreparingTask
        
    }
    public Task Task;
    public CentralCommissionState State = CentralCommissionState.NotPreparingTask;
    public void CreateTask(string title, int quantityOfQuestions)
    {
        if (State != CentralCommissionState.PreparingTask)
        {
            Task = new Task(title, quantityOfQuestions);
            State = CentralCommissionState.PreparingTask;
        }
        else throw new WrongStateException("Центральная коммиссия уже делает задания");
    }

    public void setStateNotPreparingTask()
    {
        if (State == CentralCommissionState.PreparingTask)
        {
            State = CentralCommissionState.NotPreparingTask;
        }
        else throw new WrongStateException("Центральная коммиссия уже не делает задания");

    }
    public class WrongStateException : Exception
    {
        public WrongStateException(string message) : base(message)
        {
        }
    }
}