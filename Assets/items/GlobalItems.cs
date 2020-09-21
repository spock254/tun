using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalItems
{
    public static Item GetApple() 
    { 
        return new Item(new ItemStats(PlayerStats.HUNGER,
            20f, 3f, 3), "apple", 5);
    }

    public static Item GetCoffe() 
    { 
        return new Item(new ItemStats(PlayerStats.SLEEP,
            30f, 10f, 5), "coffe", 15);
    }
}
