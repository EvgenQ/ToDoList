using System;

namespace ToDoList
{
	class Program
	{
		private static void PrintList(int countAdd) 
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
				bool isSuccess;
				string userInput;
				do
				{
					PrintList(countAddTasks);
					Console.Write("Введите номер интересующей задачи из списка: ");
					userInput = Console.ReadLine();
					isSuccess = int.TryParse(userInput, out numberOprations);
					Console.Clear();
				} while (isSuccess == false);
				
				switch (numberOprations)
				{
					case NumberOperation.ADD_TASK:
						listTasks.Add();
						countAddTasks++;
						break;

					case NumberOperation.DELETE_TASK:
						listTasks.Delete();
						countAddTasks--;
						break;

					case NumberOperation.DISPLAY_LIST_TASKS:
						PrintList(countAddTasks);
						listTasks.GetTasks();
						break;

					case NumberOperation.EDIT_TASK:
						listTasks.Edit();
						break;

					case NumberOperation.CANCEL_STATUS_TASK:
						listTasks.Done();
						break;

					case NumberOperation.EXIT:
						exit = false;
						break;

					default:
						Console.WriteLine("Ошибка при вводе задачи проверте что вы ввели!");
						Console.WriteLine($"Вы ввели {userInput}");
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
