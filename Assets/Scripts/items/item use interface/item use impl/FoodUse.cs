using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodUse : IUse
{
    public void Use_DressedUp()
    {
        throw new System.NotImplementedException();
    }

    public void Use_In_Hands()
    {
        throw new System.NotImplementedException();
    }

    public void Use_On_Player(Stats stats, Item item)
    {
        StatModify.AddValue(stats.Hunger, item.stats.value);
        StatModify.ChangeDuration(stats.Hunger, item.stats.duration, item.stats.time);
    }

    public void Use_To_Drop(Transform prefab, Transform position, Item item)
    {
        
    }

    public void Use_To_Open()
    {
        throw new System.NotImplementedException();
    }

    public void Use_To_TakeOff()
    {
        throw new System.NotImplementedException();
    }

    public void Use_To_Ware()
    {
        throw new System.NotImplementedException();
    }

    public void Use_When_Ware()
    {
        throw new System.NotImplementedException();
    }
}
