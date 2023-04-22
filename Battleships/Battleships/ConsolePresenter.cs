using System;
namespace Battleships
{
	public class ConsolePresenter : IPresenter
    {         
        public void DrawMainScreen(IBattle myBattleField, IBattle enemyBattleField)
        {
            Console.Clear();
            Console.WriteLine("my ships");
            DrawField(myBattleField, true);

            Console.WriteLine("enemy ships");
            DrawField(enemyBattleField);
        }

        public void GameOver(bool isWin, IBattle myBattleField, IBattle enemyBattleField)
        {
            DrawMainScreen(myBattleField, enemyBattleField);
            Console.WriteLine(isWin ? "You win!" : "You lost!");
        }

        public (int, int) GetInput()
        {
            Console.WriteLine("Enter you shoot (for example C6, or press Ctrl-C for exit):");
            var shoot = Console.ReadLine();

            if(shoot == null || shoot.Length < 2)
                throw new ArgumentOutOfRangeException();

            int y = shoot[0] - 65;
            if (y > 31)
                y -= 32;

            int x = shoot[1] - 48;

            if (x > 9 || y > 9)
                throw new ArgumentOutOfRangeException();

            return (x, y);
        }

        private void DrawField(IBattle battleField, bool showAll = false)
        {
            Console.WriteLine("  A B C D E F G H I J");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i);
                for (int j = 0; j < 10; j++)
                {
                    switch (battleField.GetFieldItem(i, j))
                    {
                        case FieldItem.Empty:
                            Console.Write("  ");
                            break;
                        case FieldItem.Miss:
                            Console.Write(" .");
                            break;
                        case FieldItem.Battleship:
                            Console.Write(showAll ? " 5" : "  ");
                            break;
                        case FieldItem.BattleshipHit:
                            Console.Write(" X");
                            break;
                        case FieldItem.Destroyer:
                            Console.Write(showAll ? " 4" : "  ");
                            break;
                        case FieldItem.DestroyerHit:
                            Console.Write(" X");
                            break;
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}

