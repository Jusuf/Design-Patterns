using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using WU15.DesignPatterns.ViewModel.Core.DataAccess;
using WU15.DesignPatterns.ViewModel.Core.Domain;
using WU15.DesignPatterns.ViewModel.Web.Models;


namespace WU15.DesignPatterns.ViewModel.Web.Controllers
{
    public class DefaultController : Controller
    {
        private readonly DefaultDataContext db = new DefaultDataContext();

        // GET: Default
        public ActionResult Index()
        {
            var sorted = db.TimeEntries.OrderByDescending(x => x.Date);
            return View(sorted);
        }

        public ActionResult GroupByMonth()
        {
            var grouped = db.TimeEntries
                            .ToList()
                            .GroupBy(k => new DateTime(k.Date.Year, k.Date.Month, 1))
                            .OrderByDescending(k => k.Key)
                            .ToDictionary(k => k.Key, v => v.ToList());

            return View(grouped);
        }

        public ActionResult GroupByProject()
        {
            var grouped = db.TimeEntries
                            .Include(x => x.Project)
                            .ToList()
                            .GroupBy(k => k.Project)
                            .OrderBy(k => k.Key)
                            .ToDictionary(k => k.Key, v => v.ToList());

            return View(grouped);
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                var newTimeEntry = new TimeEntryViewModel(new TimeEntry());
                newTimeEntry.AllProjects = db.Projects.ToList().Select(o => new SelectListItem
                {
                    Text = o.Name,
                    Value = o.Id.ToString()
                });
                return View(newTimeEntry);
            }

            var savedTimeEntry = db.TimeEntries.Include(x => x.Project).FirstOrDefault(x => x.Id == id);
            if (savedTimeEntry == null)
            {
                return HttpNotFound();
            }

            var timeEntry = new TimeEntryViewModel(savedTimeEntry);
            timeEntry.AllProjects = db.Projects.ToList().Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            });

            TempData["CurrentProject"] = timeEntry.Project;

            return View(timeEntry);
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(TimeEntryViewModel timeEntryViewModel)
        {
            if (timeEntryViewModel.Id > 0)
            {
                try
                {
                    //var timeEntyviewModel = new TimeEntryViewModel();

                    var timeEntryToUpdate = db.TimeEntries.First(i => i.Id == timeEntryViewModel.Id);

                    timeEntryToUpdate.Hours = timeEntryViewModel.Hours;
                    timeEntryToUpdate.Description = timeEntryViewModel.Description;
                    timeEntryToUpdate.Date = timeEntryViewModel.Date;
                    timeEntryToUpdate.Project = timeEntryViewModel.Project;

                    db.Entry(timeEntryToUpdate.Project).State = EntityState.Unchanged;
                    db.Entry(timeEntryToUpdate).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");


                }
                catch 
                {
                    return View();
                }
            }
            try
            {
                var timeEntryToSave = new TimeEntry();

                timeEntryToSave.Hours = timeEntryViewModel.Hours;
                timeEntryToSave.Description = timeEntryViewModel.Description;
                timeEntryToSave.Date = timeEntryViewModel.Date;
                timeEntryToSave.Project = timeEntryViewModel.Project;

                db.TimeEntries.Add(timeEntryToSave);
                db.Entry(timeEntryToSave.Project).State = EntityState.Unchanged;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [ChildActionOnly]
        public ActionResult HourSummary()
        {
            var totalHours = db.TimeEntries.Sum(x => x.Hours);
            var totalNumberOfProjects = db.Projects.Count();
            var numberOfProjectsWithoutTimeEntries = db.Projects.Count(x => x.TimeEntries.Count() == 0);

            var hourSummary = new HourSummaryViewModel(
                totalHours,
                totalNumberOfProjects,
                numberOfProjectsWithoutTimeEntries);

            return PartialView("_HourSummary", hourSummary);
        }

        [ChildActionOnly]
        public ActionResult ProjectSummary()
        {
            var currentProject = (Project)TempData["CurrentProject"];

            if (currentProject == null)
            {
                return PartialView("_EmptyProjectSummary", new ProjectSummaryViewModel());
            }

            var projectSummary = new ProjectSummaryViewModel()
            {
                Name = currentProject.Name,
                Description = currentProject.Description
            };

            return PartialView("_ProjectSummary", projectSummary);
        }
    }
}
