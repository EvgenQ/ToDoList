using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
	class Tasks
	{
		public string NameTasks { get; set; }
		public DateTime DateCreatinonTasks { get; set; }
		public StatusTask Status { get; set; }
		public Tasks()
		{
			DateCreatinonTasks = DateTime.Now;
			Status = StatusTask.New;
		}
	}
}
