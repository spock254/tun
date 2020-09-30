using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyItemUse : IUse
{

    public void Use_On_Player()
    {
        Debug.Log("Use_On_Player");
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
}
