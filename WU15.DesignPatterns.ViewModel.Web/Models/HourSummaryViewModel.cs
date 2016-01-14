using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WU15.DesignPatterns.ViewModel.Web.Models
{
    public class HourSummaryViewModel
    {
        public double TotalHours { get; private set; }

        public int TotalNumberOfProjects { get; private set; }

        public int NumberOfProjectsWithoutTimeEntries { get; private set; }

        public HourSummaryViewModel() { }

        public HourSummaryViewModel(
            double totalHours,
            int totalNumberOfProjects,
            int numberOfProjectsWithoutTimeEntries)
        {
            TotalHours = totalHours;
            TotalNumberOfProjects = totalNumberOfProjects;
            NumberOfProjectsWithoutTimeEntries = numberOfProjectsWithoutTimeEntries;
        }
    }
}