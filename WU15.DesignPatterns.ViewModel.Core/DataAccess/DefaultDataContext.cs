using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WU15.DesignPatterns.ViewModel.Core.Domain;

namespace WU15.DesignPatterns.ViewModel.Core.DataAccess
{
    public class DefaultDataContext : DbContext
    {
        public DbSet<TimeEntry> TimeEntries { get; set; }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //public System.Data.Entity.DbSet<WU15.DesignPatterns.ViewModel.Web.Models.TimeEntryViewModel> TimeEntryViewModels { get; set; }
    }
}
