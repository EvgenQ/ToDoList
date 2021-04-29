using System;

namespace ToDoList
{
	class Program
	{
		static void PrintList(int countAdd) 
		{
			Console.WriteLine("1 - Вывести список задач");
			Console.WriteLine("2 - Добавить задачу");
			Console.WriteLine("3 - Удалить задачу");
			Console.WriteLine("4 - Редактировать задачу");
			Console.WriteLine("5 - Отметить задачу как выполненую");
			Console.WriteLine("6 - Выход");
			Console.WriteLine($"Добавленно задач: {countAdd}");
			Console.WriteLine("***************************************************");
		}
		static void Main(string[] args)
		{
			bool exit = true;
			ListTasks listTasks = new ListTasks(100);
			int countAddTasks = 0;
			while (exit)
			{
				int numberOprations;
				bool isSuccses = false;
				string inputUser;
				do
				{
					PrintList(countAddTasks);
					Console.Write("Введите номер интересующей задачи из списка: ");
					inputUser = Console.ReadLine();
					isSuccses = int.TryParse(inputUser, out int SuccsesnumberOprations);
					numberOprations = SuccsesnumberOprations;
					Console.Clear();
				} while (isSuccses==false);
				
				switch (numberOprations)
				{
					case EnterNumberOperation.ADD_TASK:
						listTasks.Add();
						countAddTasks++;
						break;

					case EnterNumberOperation.DELETE_TASK:
						listTasks.Delete();
						countAddTasks--;
						break;

					case EnterNumberOperation.DISPLAY_LIST_TASKS:
						PrintList(countAddTasks);
						listTasks.GetTasks();
						break;

					case EnterNumberOperation.EDIT_TASK:
						listTasks.Edit();
						break;

					case EnterNumberOperation.CANCEL_STATUS_TASK:
						listTasks.Done();
						break;

					case EnterNumberOperation.EXIT:
						exit = false;
						break;

					default:
						Console.WriteLine("Ошибка при вводе задачи проверте что вы ввели!");
						Console.WriteLine($"Вы ввели {inputUser}");
						break;
				}
			}
			string buy = "Пока и спасибо за рыбу))))))";
			Console.SetCursorPosition((Console.WindowWidth / 2) - buy.Length, Console.WindowHeight / 2);
			Console.WriteLine(buy);
			Console.ReadLine();
		}
	}
}
