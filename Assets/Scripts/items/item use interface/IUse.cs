using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUse
{
    void Use_On_Player();
    void Use_When_Ware();
    void Use_In_Hands();
    void Use_To_Ware();
    void Use_To_TakeOff();
    void Use_To_Open();
    // когда айтем уже одет на играока использование пустой рукой
    void Use_DressedUp();
}
