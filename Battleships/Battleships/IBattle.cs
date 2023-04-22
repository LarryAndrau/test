using System;
namespace Battleships
{
	public interface IBattle
	{
        FieldItem GetFieldItem(int i, int j);
        FieldItem Shoot(int i, int j);
        bool IsAllDestroyed();
    }
}

