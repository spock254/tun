using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUse
{
    void Use_On_Player();
    void Use_To_Ware();
    void Use_To_Open();
    // когда айтем уже одет на играока использование пустой рукой
    void Use_DressedUp();
}
