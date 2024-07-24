using CurtainWall.BackEnd.Data.Communication;
using CurtainWall.BackEnd.Data.Communication.Entity;
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
			List<ScheduleTable> tab = [];
			using (var context = new ScheduleDBContext())
			{
				tab = [.. context.Schedules];
			}
			ScheduleControllerModule.ScheduleController ret = new(tab);
			return ret;
		}
	}
}
