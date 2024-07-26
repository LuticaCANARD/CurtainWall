using CurtainWall.BackEnd.Data.Communication;
using CurtainWall.BackEnd.Data.Communication.Entity;
using Microsoft.EntityFrameworkCore;
using ScheduleController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainWall.BackEnd.Data.InnerData
{
	internal class ScheduleAdmin
	{
		public static ScheduleControllerModule.ScheduleController MakeScheduleController()
		{
			List<ScheduleItem> tab = [];
			using (var context = new ScheduleDBContext())
			{
				try
				{
                    context.Database.OpenConnection();
                    tab = [.. context.Schedules];
					context.Database.CloseConnection();
                } 
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					
				}
			}
			ScheduleControllerModule.ScheduleController ret = new(tab);
			return ret;
		}
	}
}
