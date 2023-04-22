namespace Battleships
{
    /// <summary>
    /// This is helper class which used to randomly set one 5-size ship and two 4-size
    /// ships on the 10x10 field and checks for overlap with other ships
    /// </summary>
	public class ShipSetter
	{
        public static void SetRandomShips(FieldItem[,] Field)
        {
            Random rnd = new Random();
            int BattleshipHorizontal = rnd.Next(0, 2);
            int BattleshipX = rnd.Next(0, 5);
            int BattleshipY = rnd.Next(0, 9);

            if (BattleshipHorizontal == 0)
            {
                for (int j = BattleshipX; j < BattleshipX + 5; j++)
                {
                    Field[BattleshipY, j] = FieldItem.Battleship;
                }
            }
            else
            {
                for (int i = BattleshipX; i < BattleshipX + 5; i++)
                {
                    Field[i, BattleshipY] = FieldItem.Battleship;
                }
            }

            int DestroyerHorizontal1;
            int DestroyerX1;
            int DestroyerY1;
            for (int counter = 0; counter < 2; counter++)
            {
                do
                {
                    DestroyerHorizontal1 = rnd.Next(0, 2);
                    DestroyerX1 = rnd.Next(0, 6);
                    DestroyerY1 = rnd.Next(0, 9);
                }
                while (IsOverlapped(Field, DestroyerHorizontal1, DestroyerX1, DestroyerY1));

                if (DestroyerHorizontal1 == 0)
                {
                    for (int j = DestroyerX1; j < DestroyerX1 + 4; j++)
                    {
                        Field[DestroyerY1, j] = FieldItem.Destroyer;
                    }
                }
                else
                {
                    for (int i = DestroyerX1; i < DestroyerX1 + 4; i++)
                    {
                        Field[i, DestroyerY1] = FieldItem.Destroyer;
                    }
                }
            }
        }

        private static bool IsOverlapped(FieldItem[,] Field,int destroyerHorizontal1, int destroyerX1, int destroyerY1)
        {
            if (destroyerHorizontal1 == 0)
            {
                for (int j = destroyerX1; j < destroyerX1 + 4; j++)
                {
                    if (Field[destroyerY1, j] != FieldItem.Empty)
                        return true;
                }
            }
            else
            {
                for (int i = destroyerX1; i < destroyerX1 + 4; i++)
                {
                    if (Field[i, destroyerY1] != FieldItem.Empty)
                        return true;
                }
            }
            return false;
        }
    }
}

