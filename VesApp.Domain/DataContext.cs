using System.Data.Entity;

namespace VesApp.Domain
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<VesApp.Domain.Reflexion> Reflexions { get; set; }

        public System.Data.Entity.DbSet<VesApp.Domain.Predication> Predications { get; set; }

        public System.Data.Entity.DbSet<VesApp.Domain.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<VesApp.Domain.Event> Events { get; set; }

        public System.Data.Entity.DbSet<VesApp.Domain.Donation> Donations { get; set; }
    }
}
