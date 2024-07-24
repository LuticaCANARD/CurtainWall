using CurtainWall.BackEnd.Data.Communication.Entity;
using Microsoft.EntityFrameworkCore;
using ScheduleController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainWall.BackEnd.Data.Communication
{
    public class ScheduleDBContext : DbContext
	{
		public DbSet<ScheduleTable> Schedules { get; set; }
        public ScheduleDBContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
				.UseSqlite(Constants.DatabaseConstants.DatabasePath);

        }
		protected ScheduleDBContext(DbContextOptions contextOptions)
			: base(contextOptions)
		{

		}
		public ScheduleDBContext(DbContextOptions<ScheduleDBContext> contextOptions)
			: base(contextOptions)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ScheduleTable>()
				.Property(x=>x.Id).HasDefaultValue("NEXT VALUE FOR id");
		}
	}
}
