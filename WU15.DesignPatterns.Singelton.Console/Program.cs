using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WU15.DesignPatterns.Singelton.Core.TaskManager;

namespace WU15.DesignPatterns.Singelton.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // TaskMenager
            var taskManager1 = TaskManager.GetTaskMenager();
            var taskManager2 = TaskManager.GetTaskMenager();

            // Are they the same instance?
            if (taskManager1 == taskManager2)
            {
                System.Console.WriteLine("They are the same instance.\n");
            }

            // Execute the start method on the first task menager.
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                taskManager1.Start();
            }).Start();

            // Execute the start method on the second task menager.
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                taskManager2.Start();
            }).Start();

            // Alternative syntax for threading out an execution.
            Thread t1 = new Thread(taskManager1.Start);
            t1.Start();

            Thread t2 = new Thread(taskManager2.Start);
            t2.Start();

            // Wait for the user 
            System.Console.ReadKey();
        }
    }
}
