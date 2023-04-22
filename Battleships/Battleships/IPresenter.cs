using System;
namespace Battleships
{
	public interface IPresenter
	{
        void DrawMainScreen(IBattle myBattleField, IBattle enemyBattleField);
        (int, int) GetInput();
        void GameOver(bool isWin, IBattle myBattleField, IBattle enemyBattleField);
    }
}

