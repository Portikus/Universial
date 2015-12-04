using System;
using System.Threading;
using System.Threading.Tasks;

namespace Universial.Core.Utilities
{
    public static class TaskHelper
    {
        public static void TryToStopTask(Task task, CancellationTokenSource cancellationTokenSource, int amountofTries = 10)
        {
            var counter = 0;
            while (task.Status == TaskStatus.Running)
            {
                if (counter > amountofTries)
                {
                    throw new TimeoutException($"Could not stop the Task after {amountofTries} times.");
                }
                cancellationTokenSource.Cancel();
                Thread.Sleep((int)Math.Pow(2, counter));
                counter++;
            }
        }
    }
}
