

namespace SnakeProjekt
{
    class StateOfGame
    {
        public class GameState
        {
            public int Rows { get; set; }
            public int Cols { get; set; }
            public GridValue[,] grid { get; }
            public Direction Dir{ get; private set; }
            public int FoodEaten { get; set; }
            public int GameOver { get; private set; }
        }
    }
}
