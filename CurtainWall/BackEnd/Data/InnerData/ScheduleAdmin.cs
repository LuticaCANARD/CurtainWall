using CurtainWall.BackEnd.Data.Communication;
using CurtainWall.BackEnd.Data.Communication.Entity;
using CurtainWall.BackEnd.Data.Interface;
using Microsoft.EntityFrameworkCore;
using ScheduleController;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CurtainWall.BackEnd.Data.InnerData
{
	/// <summary>
	/// 
	/// </summary>
	internal class ScheduleAdmin(IEnumerable<ScheduleItem> froms) : ScheduleControllerModule.ScheduleController(froms)
    {
		public static Lazy<ScheduleAdmin> _instance = new (()=>new ScheduleAdmin(MakeScheduleController()));
        public static ScheduleAdmin Instance = _instance.Value;
        public static DbSet<ScheduleItem> MakeScheduleController()
		{
            DbSet<ScheduleItem> tab = null;
			using (var context = new ScheduleDBContext())
			{
				try
				{
					tab = context.Schedules;
					context.Entry(tab).Collection(a=>a).Load();
                } 
				catch (Exception e)
				{
#if DEBUG
					Console.WriteLine(e.Message);
					Debug.WriteLine(e.StackTrace);
#endif
					throw new Exception("ERROR ON Database connection... WHERE: "+nameof(MakeScheduleController));
				}
			}
			return tab;
		}

		public static void UpdateScheduleToDB()
		{
            using var context = new ScheduleDBContext();
            context.SaveChanges();
        }
    }
}
