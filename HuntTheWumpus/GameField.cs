using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus
{
	/// <summary>
	/// Игровое поле
	/// </summary>
	class GameField
	{
		public string[,] Field { get; set; }
		/// <summary>
		/// Задает размеры поля
		/// </summary>
		/// <param name="height">Высота поля</param>
		/// <param name="width">Ширина поля</param>
		public GameField(int height, int width)
		{
			Field = new string[height, width];
			Draw(Field);
		}
		/// <summary>
		/// Отрисовка игрового поля
		/// </summary>
		/// <param name="field">Размеры поля</param>
		internal void Draw(string[,] field) 
		{
			for (int i = 0; i < field.GetLength(0); i++)
			{
				Console.WriteLine();
				for (int j = 0; j < field.GetLength(1); j++)
				{
					field[i, j] = "[ ]";
					Console.Write(field[i, j]);
				}
			}
		}
		internal void Draw()
		{
			for (int i = 0; i < Field.GetLength(0); i++)
			{
				Console.WriteLine();
				for (int j = 0; j < Field.GetLength(1); j++)
				{
					Console.Write(Field[i, j]);
				}
			}
		}
	}
}
