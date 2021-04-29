using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
	class ListTasks
	{
		private Tasks[] AllTasks { get; set; }
		private int countAdd { get; set; }
		public ListTasks(int max)
		{
			AllTasks = new Tasks[max];
		}
		public Tasks[] GetTasks() 
		{
			Tasks[] AllTasksTemp = new Tasks[AllTasks.Length];
			int countNull = 0;
			for (int i = 0; i < AllTasks.Length; i++)
			{
				if (AllTasks[i] == null)
					countNull++;
				if (AllTasks.Length == countNull) 
				{
					Console.Write("Список пуст: Нажмите Enter для продолжения.\n");
					break;
				}
			}
			for (int i = 0; i < AllTasks.Length; i++)
			{
				if (AllTasks[i] != null)
				{
					AllTasksTemp[i] = AllTasks[i];
					int numberTasks = i + 1;
					Console.WriteLine($"" +
						$"№{numberTasks} " +
						$"Название: {AllTasksTemp[i].NameTasks} " +
						$"Статус: {AllTasksTemp[i].Status} " +
						$"Дата создания {AllTasksTemp[i].DateCreatinonTasks.ToShortDateString():D}");
				}
			}
			Console.WriteLine("***************************************************");
			Console.WriteLine("Нажмите Enter для продолжения.");
			Console.ReadLine();
			Console.Clear();
			return AllTasksTemp;
		}

		public void Add()
		{
			
			if (AllTasks[countAdd] == null)
			{
				Console.Write("Введите название задачи: ");
				string nameTask = Console.ReadLine();
				Tasks newTask = new Tasks()
				{
					NameTasks = nameTask
				};
				AllTasks[countAdd] = newTask;
				Console.Clear();
				return;
			}
			else 
			{
				Add(countAdd++);
			}
		}

		internal void Delete()
		{
			int numberOprations;
			bool isSuccses;
			string inputUser;
			do
			{
				GetTasksForEdit();
				Console.Write("Выберите номер задачи: ");
				inputUser = Console.ReadLine();
				isSuccses = int.TryParse(inputUser, out int SuccsesnumberOprations);
				if (SuccsesnumberOprations - 1 > countAdd || SuccsesnumberOprations == 0)
				{
					isSuccses = false;
				}
				numberOprations = SuccsesnumberOprations - 1;
				Console.Clear();
			} while (isSuccses == false);
			AllTasks[numberOprations].Status = StatusTask.Done;
			Console.WriteLine("Задача удалена из списка");
			AllTasks[numberOprations] = null;
			Console.WriteLine("Нажмите Enter для продолжения.");
			Console.ReadLine();
			Console.Clear();
		}

		internal void Done()
		{
			int numberOprations;
			bool isSuccses;
			string inputUser;
			do
			{
				GetTasksForEdit();
				Console.Write("Выберите номер задачи: ");
				inputUser = Console.ReadLine();
				isSuccses = int.TryParse(inputUser, out int SuccsesnumberOprations);
				if (SuccsesnumberOprations - 1 > countAdd || SuccsesnumberOprations == 0)
				{
					isSuccses = false;
				}
				numberOprations = SuccsesnumberOprations - 1;
				Console.Clear();
			} while (isSuccses == false);
			AllTasks[numberOprations].Status = StatusTask.Done;
			Console.WriteLine("Статус изменен на Выполненно.");
			Console.WriteLine("Нажмите Enter для продолжения.");
			Console.ReadLine();
			Console.Clear();
		}

		internal void Edit()
		{
			int numberOprations;
			bool isSuccses;
			string inputUser;
			do
			{
				GetTasksForEdit();
				Console.Write("Выберите номер задачи: ");
				inputUser = Console.ReadLine();
				isSuccses = int.TryParse(inputUser, out int SuccsesnumberOprations);
				if (SuccsesnumberOprations - 1 > countAdd || SuccsesnumberOprations == 0) 
				{
					isSuccses = false;
				}
				numberOprations = SuccsesnumberOprations - 1;
				Console.Clear();
			} while (isSuccses == false);
			isSuccses = false;
			do
			{
				Console.WriteLine($"Выбрана задача: №{numberOprations + 1} \n" +
				$"Название: {AllTasks[numberOprations].NameTasks}, \n" +
				$"Статус: {AllTasks[numberOprations].Status}, \n" +
				$"Дата создания: {AllTasks[numberOprations].DateCreatinonTasks.ToShortDateString():D}");
				Console.WriteLine("Нажмите R для редактирования \"Названия\"\n" +
								  "Нажмите S для редактирования \"Статуса\"");
				Console.Write("Ожидание ввода от пользователя: ");
				inputUser = Console.ReadLine().ToUpper();
				if (inputUser == "R" || inputUser == "S")
				{
					isSuccses = true;
				}
				else
				{
					Console.WriteLine("Error,try again!");
					Console.ReadLine();
				}
				Console.Clear();
			} while (isSuccses == false);
			if (inputUser == "R") 
			{
				Console.Write("Введите новое имя: ");
				string newName = Console.ReadLine();
				Console.Write($"Имя изменено с {AllTasks[numberOprations].NameTasks} ");
				AllTasks[numberOprations].NameTasks = newName;
				Console.WriteLine($"на {AllTasks[numberOprations].NameTasks}");
			}
			if (inputUser == "S")
			{
				int numberStatus;
				do
				{
					Console.WriteLine("1 - Done");
					Console.WriteLine("2 - InProcess");
					Console.WriteLine("3 - New");
					Console.Write("Введите новый статус: ");
					inputUser = Console.ReadLine();
					isSuccses = int.TryParse(inputUser, out int SuccsesnumberOprations);
					if (SuccsesnumberOprations <= (int)StatusTask.Done || SuccsesnumberOprations > (int)StatusTask.New) 
					{
						isSuccses = false;
					}
					numberStatus = SuccsesnumberOprations - 1;
					Console.Clear();
				} while (isSuccses == false);
				Console.Write($"Статус изменен с {AllTasks[numberOprations].Status} ");
				if (numberStatus == 0)
				{
					AllTasks[numberOprations].Status = StatusTask.Done;
					Console.WriteLine($"на {AllTasks[numberOprations].Status}");
					Console.WriteLine("Статус изменен на Выполненно задача удалена из списка");
					AllTasks[numberOprations] = null;
				}
				if (numberStatus == 1)
				{
					AllTasks[numberOprations].Status = StatusTask.InProcess;
					Console.WriteLine($"на {AllTasks[numberOprations].Status}");
				}
				if (numberStatus == 2)
				{
					AllTasks[numberOprations].Status = StatusTask.New;
					Console.WriteLine($"на {AllTasks[numberOprations].Status}");
				}
				Console.WriteLine("Нажмите Enter для продолжения.");
				Console.ReadLine();
			}
		}

		private void GetTasksForEdit()
		{
			Tasks[] AllTasksTemp = new Tasks[AllTasks.Length];
			for (int i = 0; i < AllTasks.Length; i++)
			{
				if (AllTasks[i] != null)
				{
					AllTasksTemp[i] = AllTasks[i];
					int numberTasks = i + 1;
					Console.WriteLine($"" +
						$"№{numberTasks} " +
						$"Название: {AllTasksTemp[i].NameTasks} " +
						$"Статус: {AllTasksTemp[i].Status} " +
						$"Дата создания {AllTasksTemp[i].DateCreatinonTasks.ToShortDateString():D}");
				}
			}
			Console.WriteLine("***************************************************");
		}

		private void Add(int count)
		{
			Add();
		}
	}
}
