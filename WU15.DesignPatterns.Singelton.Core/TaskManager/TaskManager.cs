using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.Singelton.Core.TaskManager
{
    public class TaskManager
    {
        private static TaskManager instance;
        private readonly List<ITask> tasks = new List<ITask>();
        private static readonly object SyncLock = new object();
        private ExecutionState taskExecutionState;

        public enum ExecutionState
        {
            Waiting,
            Started
        }

        protected TaskManager()
        {
            tasks.Add(new TestTask("One"));
            tasks.Add(new TestTask("Two"));
            tasks.Add(new ImportRssFeedTask("http://www.dn.se/rss/senaste-nytt/"));
            tasks.Add(new ImportRssFeedTask("http://api.sr.se/api/rss/channel/83?format-1"));
            tasks.Add(new SendEmailTask("Hej", "Hopp", "someone@somwhare.com"));
        }
        
        public static TaskManager GetTaskMenager()
        {
            if (instance == null)
            {
                lock (SyncLock)
                {
                    if (instance == null)
                    {
                        instance = new TaskManager();
                    }
                }
            }
            return instance;
        } 

        public void Start()
        {
            // Toggle tthese lines to enable/disable concurrent execution.
            if (taskExecutionState == ExecutionState.Started)
                return;

            taskExecutionState = ExecutionState.Started;
            foreach (var task in tasks)
            {
                task.Execute();
            }
        }
    }
}
