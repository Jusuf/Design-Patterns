using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.ViewModel.Core.Domain
{
    public class Project : IComparable<Project>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<TimeEntry> TimeEntries { get; set; }

        public int CompareTo(Project other)
        {
            return string.CompareOrdinal(this.Name, other.Name);
        }
    }
}
