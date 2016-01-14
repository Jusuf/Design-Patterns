using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WU15.DesignPatterns.ViewModel.Core.Domain;

namespace WU15.DesignPatterns.ViewModel.Web.Models
{
    public class TimeEntryViewModel
    {
        public TimeEntryViewModel() { }

        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public double Hours { get; set; }

        public Project Project { get; set; }

        public TimeEntryViewModel(TimeEntry timeEntry)
        {
            Id = timeEntry.Id;
            Description = timeEntry.Description;
            Date = timeEntry.Date;
            Hours = timeEntry.Hours;
            Project = timeEntry.Project;
        }

        public IEnumerable<SelectListItem> AllProjects { get; set; }
    }
}