

using System.Runtime.CompilerServices;
using System.Windows.Controls.Primitives;

namespace SnakeProjekt
{
    class StateOfGame
    {
        // Håller koll på spelets tillstånd
        public class GameState
        {
            public int Rows { get;}
            public int Cols { get;}
            public GridValue[,] grid { get; }
            public Direction Dir { get; private set; }
            public int Score { get; set; }
            public int GameOver { get; private set; }

            private readonly LinkedList<Position> snakePositions = new LinkedList<Position>();


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
                int index = random.Next(emptyPositions.Count);
                Position pos = emptyPositions[index];
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
            public void ChangeDirection(Direction dir)
            {
				// Ändrar riktning på ormen
				if (dir != Dir.Opposite())
                {
					Dir = dir;
				}
			}
            private bool IsOutSideGrid(Position pos)
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
				GridValue value = grid[newHeadPos.X, newHeadPos.Y];
				if (value == GridValue.Snake)
                {
					return GridValue.Snake;
				}
				return GridValue.Empty;
			}
            public void Move()
            {
                // Flyttar ormen
                Position headPos = HeadPosition();
                Position newHeadPos = new Position(headPos.X + Dir.X, headPos.Y + Dir.Y);
                GridValue value = GonDie(newHeadPos);
                if (value == GridValue.Empty)
                {
					AddHead(newHeadPos);
					RemoveTail();
				}
				else if (value == GridValue.Food)
                {
					AddHead(newHeadPos);
					Score++;
                    Food();
				}
				else
                {
					GameOver = 1;
				}
            }
        }

    }
}
