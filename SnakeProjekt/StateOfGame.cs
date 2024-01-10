

using System.Runtime.CompilerServices;
using System.Windows.Controls.Primitives;
using System.Diagnostics;

namespace SnakeProjekt
{
	class StateOfGame
	{
		// Håller koll på spelets tillstånd
		public class GameState
		{
			public int Rows { get; }
			public int Cols { get; }
			public GridValue[,] grid { get; }
			public Direction Dir { get; private set; }
			public int Score { get; set; }
			public int GameOver { get; private set; }


			private readonly LinkedList<Position> snakePositions = new LinkedList<Position>();
			private readonly LinkedList<Direction> dirChanges = new LinkedList<Direction>();

			public GameState(int rows, int cols)
			{
				Rows = rows;
				Cols = cols;
				grid = new GridValue[rows, cols];
				Dir = Direction.Right;
				Score = 0;
				GameOver = 0;
				AddSnake();
				Food();
			}

			private void AddSnake()
			{
				// Lägger till ormen i rad 2 i kolumn 0, 1 och 2 med en loop
				int r = Rows / 2;

				for (int c = 0; c < 3; c++)
				{
					grid[r, c] = GridValue.Snake;
					snakePositions.AddFirst(new Position(r, c));
				}
			}

			private IEnumerable<Position> GetEmptyPositions(GameState state)
			{
				// Returnerar en lista med alla lediga positioner i griden
				for (int r = 0; r < state.Rows; r++)
				{
					for (int c = 0; c < state.Cols; c++)
					{
						if (state.grid[r, c] == GridValue.Empty)
						{
							yield return new Position(r, c);
						}
					}
				}
			}
			private void Food()
			{
				List<Position> emptyPositions = GetEmptyPositions(this).ToList();
				Random random = new Random();
				Position pos = emptyPositions[random.Next(emptyPositions.Count)];
				grid[pos.X, pos.Y] = GridValue.Food;
			}
			public Position HeadPosition()
			{
				// Returnerar ormens huvudposition
				return snakePositions.First.Value;
			}
			public Position TailPosition()
			{
				// Returnerar ormens svansposition
				return snakePositions.Last.Value;
			}
			public IEnumerable<Position> SnakePositions()
			{
				// Returnerar en lista med alla ormens positioner
				return snakePositions;
			}
			private void AddHead(Position pos)
			{
				// Lägger till en ny position för ormens huvud
				snakePositions.AddFirst(pos);
				grid[pos.X, pos.Y] = GridValue.Snake;
			}

			private void RemoveTail()
			{
				// Tar bort ormens svansposition 
				Position pos = snakePositions.Last.Value;
				snakePositions.RemoveLast();
				grid[pos.X, pos.Y] = GridValue.Empty;
			}
			
			private Direction GetLastDirection()
			{
				// Returnerar den senaste riktningen som ormen tog. Om 0 så händer inget
				if(dirChanges.Count == 0)
				{
					return Dir;
				}
				return dirChanges.Last.Value;
			}
			public void ChangeDirection(Direction dir)
			{
				if (CanChangeDirection(dir))
				{
					dirChanges.AddLast(dir);
				}
			}
			private bool CanChangeDirection(Direction newDir)
			{
				if (dirChanges.Count == 2)
				{
					return false;
				}
				Direction lastDir = GetLastDirection();
				return newDir != lastDir.Opposite();
			}

			private bool IsOutSideGrid(Position pos)		// Kollar om ormen är utanför griden
			{
				return pos.X < 0 || pos.X >= Rows || pos.Y < 0 || pos.Y >= Cols;
			}
			private GridValue GonDie(Position newHeadPos)
			{
				// Kollar om ormen kommer att dö
				if (IsOutSideGrid(newHeadPos))
				{
					return GridValue.Wall;
				}

				if (newHeadPos == TailPosition())
				{
					return GridValue.Empty;
				}
				return grid[newHeadPos.X, newHeadPos.Y];
			}
			public void Move()
			{
				// Flyttar ormen

				if (dirChanges.Count > 0)
				{
					Dir = dirChanges.First.Value;
					dirChanges.RemoveFirst();
				}
				Position headPos = HeadPosition();
				// Nya positionen för ormens huvud bestäms genom att lägga
				// till ormens riktning till ormens huvudposition
				Position newHeadPos = new Position(headPos.X + Dir.X, headPos.Y + Dir.Y); 
				GridValue value = GonDie(newHeadPos);
				if (value == GridValue.Wall)
				{
					GameOver = 1;
				}
				else if (value == GridValue.Empty)
				{
					RemoveTail();
					AddHead(newHeadPos);
				}
				else if (value == GridValue.Snake)
				{
					GameOver = 1;
				}
				else if (value == GridValue.Food)		
				{
					AddHead(newHeadPos);
					Score++;
					Food();
				}
			}
		}

	}
}
