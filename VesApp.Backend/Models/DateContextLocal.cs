using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VesApp.Domain;

namespace VesApp.Backend.Models
{
    public class DateContextLocal : DataContext
    {
        public System.Data.Entity.DbSet<VesApp.Domain.Publication> Publications { get; set; }
    }
}