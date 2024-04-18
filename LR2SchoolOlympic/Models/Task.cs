namespace LR2SchoolOlimpic.Models
{
    public class Task
    {
        public string Title { set; get; }
        public int QuantityOfQuestions { set; get; }

        public Task(string title, int quantityOfQuestions)
        {
            this.Title = title;
            this.QuantityOfQuestions = quantityOfQuestions;
        }
    }
}