using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp1;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InjectDependencyWithEvents.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index([FromServices]ISomeClassWithEvents someClassWithEvents)
        {
			if(someClassWithEvents == null) throw new ArgumentNullException(nameof(someClassWithEvents));
			someClassWithEvents.SomeEvent += SomeClassWithEvents_SomeEvent;
			someClassWithEvents.Start();
            return View();
        }

		private void SomeClassWithEvents_SomeEvent(object sender, EventArgs e)
		{
			ISomeClassWithEvents someClassWithEvents = sender as ISomeClassWithEvents;
			someClassWithEvents?.Stop();
		}
	}
}
