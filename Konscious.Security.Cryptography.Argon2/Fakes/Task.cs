#if NET35
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

#pragma warning disable CS1591
namespace Konscious.Security.Cryptography
{
  internal class Task
  {
    private ManualResetEvent waitEvent;
    private Action action;

    private Task(Action action)
    {
      waitEvent = new ManualResetEvent(false);
      this.action = action;
    }

    private void Start()
    {
      Thread thread = new Thread(new ThreadStart(() =>
      {
        if(action != null)
          action();
        waitEvent.Set();
      }));
      thread.IsBackground = true;
      thread.Start();
    }

    private void Wait()
    {
      if(waitEvent != null)
      {
        waitEvent.WaitOne();
        ((IDisposable) waitEvent).Dispose();
        waitEvent = null;
      }
    }

    public static Task Run(Action action)
{
      Task task = new Task(action);
      task.Start();
      return task;
}

    public static void WhenAll(IEnumerable<Task> tasks)
    {
      foreach(var task in tasks)
      {
        task.Wait();
      }
    }
  }
}

#pragma warning restore CS1591
#endif