using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Universial.Core.Extensions;
using Universial.Core.Utilities;
using Universial.Test;
using Universial.Tests.Core.Extensions;

namespace Universial.Tests.Core.Utilities
{
    public class TaskHelperTest
    {
        [Test]
        public async void Test_if_can_cancel_a_task()
        {
            //Arrange
            var token = new CancellationTokenSource();
            var task = new Task(() =>
            {
                while (token.IsCancellationRequested == false)
                {
                    Thread.Sleep(100);
                }
            }, token.Token, TaskCreationOptions.LongRunning);
            task.Start();

            //Act
            TaskHelper.TryToStopTask(task, token);
            //Assert
            Assert.That(() => task.Status, Is.EqualTo(TaskStatus.RanToCompletion));
        }
        [Test]
        public async void Test_throws_a_timeoutexception_if_task_could_not_be_stopped()
        {
            //Arrange
            var stop = false;
            var token = new CancellationTokenSource();
            var task = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    if (stop)
                    {
                        break;
                    }
                    Thread.Sleep(100);
                }
            }, token.Token, TaskCreationOptions.LongRunning);
            task.Start();

            //Act
            Assert.That(() => TaskHelper.TryToStopTask(task, token), Throws.Exception.TypeOf<TimeoutException>());
            stop = true;

            //Assert
            await task;
            Assert.That(() => task.Status, Is.EqualTo(TaskStatus.RanToCompletion));
        }
    }
}
