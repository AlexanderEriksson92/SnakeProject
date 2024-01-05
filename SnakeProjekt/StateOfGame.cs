

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
            public int Rows { get;}
            public int Cols { get;}
            public GridValue[,] grid { get; }
            public Direction Dir { get; private set; }
            public int Score { get; set; }
            public int GameOver { get; private set; }

            public string TextScore { get; set; }

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
                Position pos = emptyPositions[random.Next(emptyPositions.Count)];
                grid[pos.X, pos.Y] = GridValue.Food;
				Debug.WriteLine($"Mat placerad på position ({pos.X}, {pos.Y})");
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
				
				if (newHeadPos == TailPosition())
                {
					return GridValue.Empty;
				}
				return grid[newHeadPos.X, newHeadPos.Y];
			}
            public void Move()
            {
                // Flyttar ormen
                Position headPos = HeadPosition();
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
                    Debug.WriteLine("Ormen äter mat");
                    AddHead(newHeadPos);
					Score++;
					Food();
					Debug.WriteLine("Ny mat placerad");
				}
            }
        }

    }
}
