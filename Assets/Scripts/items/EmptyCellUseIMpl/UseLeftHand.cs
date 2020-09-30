using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseLeftHand : IUse
{
    public void Use_In_Hands()
    {
        Debug.Log("Use_In_Hands");
    }
    public void Use_When_Ware()
    {
        Debug.Log("Use_When_Ware");
    }
    public void Use_DressedUp()
    {
        Debug.Log("Use_DressedUp with out eq");
    }
    public void Use_To_TakeOff()
    {
        Debug.Log("Use_To_TakeOff");
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