using ScheduleController;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainWall.BackEnd.Data.Communication
{
    public class ScheduleDatabase
    {
        SQLiteAsyncConnection database;
        public ScheduleDatabase()
        {
            Init().Wait();
        }
        public static readonly Lazy<ScheduleDatabase> _instance = new(() => new ScheduleDatabase());
        public static ScheduleDatabase Instance = _instance.Value;
        async Task Init()
        {
            if (database != null)
                return;
            database = new SQLiteAsyncConnection(Constants.DatabaseConstants.DatabasePath, Constants.DatabaseConstants.Flags);
            await database.CreateTableAsync<Schedule>();
        }

        public async Task<List<Schedule>> GetAllSchedules()
        {
            await Init();
            return await database.Table<Schedule>().ToListAsync();
        }




    }
}
