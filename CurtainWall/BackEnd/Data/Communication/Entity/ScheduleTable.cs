using Microsoft.EntityFrameworkCore;
using ScheduleController;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainWall.BackEnd.Data.Communication.Entity
{
	[ Table("tb_schedule") ]
	[ PrimaryKey(nameof(Id)) ]
	[ Index(nameof(StartTime)), Index(nameof(ExpireTime)) ]
	public class ScheduleTable: ISchedule
	{
		[ Column("id") ]
		public int Id { get; set; }
		public string Name { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime ExpireTime { get; set; }

	}
}
