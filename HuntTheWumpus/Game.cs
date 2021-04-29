using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus
{
	class Game
	{
		public GameField Field;
		public NPC Players;
		public void Start()
		{
			int coordMoveUser;
			Console.WriteLine("Введите размер игрового поля");
			Console.Write("Введите ширину: ");
			int widthField = int.Parse(Console.ReadLine());
			Console.Write("Введите высоту: ");
			int heightField = int.Parse(Console.ReadLine());
			Console.Write("Количество летучих мышей на поле: ");
			int numberOfBatOnField = int.Parse(Console.ReadLine());
			Field = new GameField(heightField, widthField);
			int percentPitOnField = 5;
			percentPitOnField = (percentPitOnField * Field.Field.Length) / 100;
			Players = new NPC();
			PositionUserOnField(Players.Player);
			PositionBatOnField(Players.Bat, numberOfBatOnField);
			PositionPitOnField(Players.DeathPit, percentPitOnField);
			Console.Clear();
			Field.Draw();
			MovePlayer();
		}

		private GameField PositionPitOnField(string pit, int percentPit)
		{
			if (percentPit == 0) 
			{
				return Field;
			}
			for (int i = 0; i < percentPit; i++)
			{
				Random rnd = new Random();
				int positionAxisX = rnd.Next(0, Field.Field.GetLength(0));
				int positionAxisY = rnd.Next(0, Field.Field.GetLength(1));
				if (Field.Field[positionAxisX, positionAxisY] == Players.Player ||
					Field.Field[positionAxisX, positionAxisY] == Players.Bat    ||
					Field.Field[positionAxisX, positionAxisY] == Players.Wampus ||
					Field.Field[positionAxisX, positionAxisY] == Players.DeathPit)
				{
					positionAxisX = rnd.Next(0, Field.Field.GetLength(0));
					positionAxisY = rnd.Next(0, Field.Field.GetLength(1));
				}
				Field.Field[positionAxisX, positionAxisY] = pit;
			}
			return Field;
		}

		public GameField PositionUserOnField(string user)
		{
			Random rnd = new Random();
			int positionAxisX = rnd.Next(0, Field.Field.GetLength(0));
			int positionAxisY = rnd.Next(0, Field.Field.GetLength(1));
			Field.Field[positionAxisX, positionAxisY] = user;
			return Field;
		}
		public GameField PositionBatOnField(string bat,int batOnField)
		{
			if (batOnField == 0)
			{
				return Field;
			}
			for (int i = 0; i < batOnField; i++)
			{
				Random rnd = new Random();
				int positionAxisX = rnd.Next(0, Field.Field.GetLength(0));
				int positionAxisY = rnd.Next(0, Field.Field.GetLength(0));
				if (Field.Field[positionAxisX, positionAxisY] == Players.Player ||
					Field.Field[positionAxisX, positionAxisY] == Players.Bat    ||
					Field.Field[positionAxisX, positionAxisY] == Players.Wampus ||
					Field.Field[positionAxisX, positionAxisY] == Players.DeathPit) 
				{
					positionAxisX = rnd.Next(0, Field.Field.GetLength(0));
					positionAxisY = rnd.Next(0, Field.Field.GetLength(1));
				}
				Field.Field[positionAxisX, positionAxisY] = bat;
			}
			
			return Field;
		}
		public void MovePlayer()
		{

			(int row, int column) coordMoveUser = (0,0);
			for (int i = 0; i < Field.Field.GetLength(0); i++)
			{
				for (int j = 0; j < Field.Field.GetLength(1); j++)
				{
					if (Field.Field[i, j] == Players.Player) 
					{
						coordMoveUser = (i,j);
					}
				}
			}
			GetControlUser(coordMoveUser);
			ConsoleKeyInfo control = new();
			do 
			{
				control = Console.ReadKey();
				if (control.Key == ConsoleKey.UpArrow)
				{
					Field.Field[coordMoveUser.column, coordMoveUser.row] = "[ ]";
					coordMoveUser.row--;
					Field.Field[coordMoveUser.column, coordMoveUser.row] = Players.Player;
				}
				if (control.Key == ConsoleKey.DownArrow)
				{

				}
				if (control.Key == ConsoleKey.LeftArrow)
				{

				}
				if (control.Key == ConsoleKey.RightArrow)
				{

				}
			}
			while (control.Key != ConsoleKey.Escape);
		}
		public void ShootPlayer()
		{
			ConsoleKeyInfo ShootControl = new ConsoleKeyInfo();
			while (ShootControl.Key == ConsoleKey.W ||
					ShootControl.Key == ConsoleKey.S ||
					ShootControl.Key == ConsoleKey.A ||
					ShootControl.Key == ConsoleKey.D)
			{
				if (ShootControl.Key == ConsoleKey.W)
				{

				}
				if (ShootControl.Key == ConsoleKey.S)
				{

				}
				if (ShootControl.Key == ConsoleKey.A)
				{

				}
				if (ShootControl.Key == ConsoleKey.D)
				{

				}
			}
		}
		public void GetControlUser((int row,int column) coord) 
		{
			Console.SetCursorPosition(coord.column*3+1, coord.row+1);
		}
	}
}
