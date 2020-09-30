using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseBody : IUse
{
    public void Use_DressedUp()
    {
        Debug.Log("Use_DressedUp with out eq");
    }

    public void Use_On_Player()
    {
        throw new System.NotImplementedException();
    }

    public void Use_To_Open()
    {
        throw new System.NotImplementedException();
    }

    public void Use_To_Ware()
    {
        throw new System.NotImplementedException();
    }
}
