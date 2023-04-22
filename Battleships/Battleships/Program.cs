using Battleships;

IPresenter presenter = new ConsolePresenter();
IBattle myBattleField = new BattleField();
IBattle enemyBattleField = new BattleField();
Random rnd = new();
FieldItem oneShoot;
int x, y;

while (true)
{
    do // Player turn
    {
        presenter.DrawMainScreen(myBattleField, enemyBattleField);

        (x, y) = presenter.GetInput();
        oneShoot = enemyBattleField.Shoot(x,y);
 
        if (enemyBattleField.IsAllDestroyed())
        {
            presenter.GameOver(true, myBattleField, enemyBattleField);
            return;
        }
    }
    while (oneShoot == FieldItem.BattleshipHit || oneShoot == FieldItem.DestroyerHit);

    do  // Computer turn
    {
        presenter.DrawMainScreen(myBattleField, enemyBattleField);

        x = rnd.Next(0, 10);
        y = rnd.Next(0, 10);

        oneShoot = myBattleField.Shoot(x, y);

        if (myBattleField.IsAllDestroyed())
        {
            presenter.GameOver(false, myBattleField, enemyBattleField);
            return;
        }
    }   
    while (oneShoot == FieldItem.BattleshipHit || oneShoot == FieldItem.DestroyerHit);
}


