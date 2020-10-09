using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemCell : MonoBehaviour
{
    [SerializeReference]
    public Item item;
    //public Sprite empty_cell_sprite;
    //private void Update()
    //{
    //    if (item == null)
    //        Debug.Log("ITEM ++ NULL");
    //}
}
