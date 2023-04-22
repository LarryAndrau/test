namespace Battleships
{
	public class BattleField : IBattle
    {
        private FieldItem[,] Field = new FieldItem[10,10];

        public BattleField()
		{
            Init();
            ShipSetter.SetRandomShips(Field);
        }

        public FieldItem GetFieldItem(int i, int j) => Field[i, j];
        

        public FieldItem Shoot(int i, int j)
        {
            switch (Field[i, j])
            {
                case FieldItem.Empty:
                    Field[i, j] = FieldItem.Miss;
                    break;
                case FieldItem.Battleship:
                    Field[i, j] = FieldItem.BattleshipHit;
                    break;
                case FieldItem.Destroyer:
                    Field[i, j] = FieldItem.DestroyerHit;
                    break;
            }
            return Field[i, j];
        }

        public bool IsAllDestroyed()
        {
            for (int i = 0; i < 10; i++)
            { 
                for (int j = 0; j < 10; j++)
                {
                    if (Field[i, j] == FieldItem.Battleship || Field[i, j] == FieldItem.Destroyer)
                        return false;
                }
            }
            return true;
        }

        private void Init()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Field[i, j] = FieldItem.Empty;
                }
            }
        }
    }
}

