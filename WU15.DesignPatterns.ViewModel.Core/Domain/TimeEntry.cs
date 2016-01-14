using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.ViewModel.Core.Domain
{
    public class TimeEntry
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public double Hours { get; set; }

        public Project Project { get; set; }
    }
}
