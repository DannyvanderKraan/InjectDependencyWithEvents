using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public interface ISomeClassWithEvents
	{
		event EventHandler SomeEvent;
		void Start();
		void Stop();
	}

	public class SomeClassWithEvents : ISomeClassWithEvents
	{
		private bool _isRunning;
	    public event EventHandler SomeEvent;

	    public SomeClassWithEvents()
	    {
		    _isRunning = true;
			StartLoopingAsync();

	    }

		private async Task StartLoopingAsync()
		{
			await Task.Run(() =>
			{
				while (_isRunning)
				{
					Thread.Sleep(2000);
					OnSomeEvent();
				}
			});
			
		}

		public void Start()
		{
			_isRunning = true;
		}

		public void Stop()
		{
			_isRunning = false;
		}

		protected virtual void OnSomeEvent()
	    {
		    if (SomeEvent != null)
		    {
			    SomeEvent(this, new EventArgs());
		    }
	    }
    }
}
