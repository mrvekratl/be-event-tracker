using EventTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventTracker.Controllers
{
    public class EventsController : Controller
    {
        private static List<EventModel> eventList = new()
        {
            new EventModel {Id=1, Title="Birthday Party", Description="Best friend's birthday party", Date=DateTime.UtcNow.AddDays(7), Image="Id1.jpg"},
            new EventModel {Id=2, Title="Meeting", Description="Important meeting and presentation", Date = DateTime.UtcNow.AddDays(2), Image="Id2.jpg"},
            new EventModel {Id=3, Title="Cinema", Description="New Film", Date = DateTime.UtcNow.AddDays(5), Image="Id3.jpg"},
            new EventModel {Id=4, Title="Theather", Description="CGHB Comming", Date = DateTime.UtcNow.AddDays(15), Image="Id4.jpg"},
            new EventModel {Id=5, Title="Concert", Description="Tarkan, Ankara", Date = DateTime.UtcNow.AddDays(22), Image="Id5.jpg"},
        };
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List() 
        {
            ViewBag.eventList = eventList;
            return View();
        }
        [HttpGet("{Id}")]
        public IActionResult Details(int id) 
        {
            var eventItem = eventList.FirstOrDefault(e => e.Id == id);
            if (eventItem == null)  
            {
                return BadRequest();
            }

            ViewBag.EventItem = eventItem;
            return View(eventItem);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var eventItem = eventList.FirstOrDefault(e => e.Id == id);
            if (eventItem != null)
            {
                eventList.Remove(eventItem);
            }

            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm]EventModel eventItem) 
        {
            if (ModelState.IsValid)
            {
                eventItem.Id = eventList.Any() ? eventList.Max(e => e.Id) + 1 : 1;
                eventList.Add(eventItem);
                return RedirectToAction("List");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit([FromForm]EventModel eventItem)
        {
            if (ModelState.IsValid)
            {               
                var eventUpdate = eventList.FirstOrDefault(x => x.Id == eventItem.Id);
                if (eventUpdate == null)
                {
                    return  View();
                }
                eventUpdate.Id = eventItem.Id;
                eventUpdate.Title = eventItem.Title;
                eventUpdate.Description = eventItem.Description;
                eventUpdate.Date = eventItem.Date;
                eventUpdate.Image = eventItem.Image;

                return RedirectToAction("List");
            }
            return View();
        }
        
      
        
    }
}
