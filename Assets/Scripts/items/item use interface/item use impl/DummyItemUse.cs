using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyItemUse : IUse
{

    public void Use_When_Ware()
    {
        Debug.Log("Use_When_Ware");
    }
    public void Use_On_Player(Stats stats, Item item)
    {
        Debug.Log("Use_On_Player");
    }
    public void Use_To_TakeOff()
    {
        Debug.Log("Use_To_TakeOff");
    }
    public void Use_To_Open()
    {
        Debug.Log("Use_To_Open");
    }

    public void Use_To_Ware()
    {
        Debug.Log("Use_To_Ware");
    }
    public void Use_DressedUp()
    {
        Debug.Log("Use_DressedUp");
    }

    public void Use_In_Hands()
    {
        Debug.Log("Use_In_Hands");
    }
    public void Use_To_Drop(Transform prefab, Transform position, Item item)
    {
        Debug.Log("Use_To_Drop");
    }
}
