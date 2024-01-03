

using System.Runtime.CompilerServices;
using System.Windows.Controls.Primitives;

namespace SnakeProjekt
{
    class StateOfGame
    {
        // Håller koll på spelets tillstånd
        public class GameState
        {
            public int Rows { get; set; }
            public int Cols { get; set; }
            public GridValue[,] grid { get; }
            public Direction Dir { get; private set; }
            public int FoodEaten { get; set; }
            public int GameOver { get; private set; }

            private readonly LinkedList<Position> snakePositions = new LinkedList<Position>();


            public GameState(int rows, int cols)
            {
                Rows = rows;
                Cols = cols;
                grid = new GridValue[rows, cols];
                Dir = Direction.Right;
                FoodEaten = 0;
                GameOver = 0;
                AddSnake();
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
                // Returnerar en lista med alla lediga positioner
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
        }
    }
}
