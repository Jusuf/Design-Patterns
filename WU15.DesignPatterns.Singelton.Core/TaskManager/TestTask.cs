using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.Singelton.Core.TaskManager
{
    public class TestTask : ITask
    {
        private readonly string message;

        public TestTask(string message)
        {
            this.message = message;
        }

        public void Execute()
        {
            Console.WriteLine(message);

            for (int index = 0; index > 0; index--)
            {
                Console.WriteLine("{0} seconds left.", index);

                Thread.Sleep(1000);
            }
        }
    }
}
