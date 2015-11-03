using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace Part2.Models
{
    public class dbContext : DbContext
    {
        public dbContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<ColumnModel> TColumn { get; set; }
        public DbSet<FrameModel> TFrame { get; set; }
        public DbSet<UserModel> TUser { get; set; }
    }
}
