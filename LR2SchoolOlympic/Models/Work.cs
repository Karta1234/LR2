using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2SchoolOlimpic.Models
{
    public class Work
    {
        public int Grade = 0;

        public void SolveTask(int numberOfTask)
        {
            Random random = new Random();
            Grade = random.Next(0, numberOfTask+1);
        }
    }
}
