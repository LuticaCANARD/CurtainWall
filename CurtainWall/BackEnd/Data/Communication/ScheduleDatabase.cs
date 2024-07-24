using CurtainWall.BackEnd.Data.Communication.Entity;
using Microsoft.Data.Sqlite;
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
			SQLitePCL.Batteries_V2.Init();
			Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			var connectionString = new SqliteConnectionStringBuilder() { 
				DataSource = Constants.DatabaseConstants.DatabasePath,
                Mode = (SqliteOpenMode) Constants.DatabaseConstants.Flags
            }.ToString();
            optionsBuilder
            .UseSqlite(connectionString);
            
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
			modelBuilder.Entity<ScheduleTable>();
		}
	}
}
