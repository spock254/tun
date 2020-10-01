﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemUseData
{
    public enum ItemSize { Small, Middle, Big }
    public enum ItemType { Head, Face, Body, Arm, Lags, Bag, Card, 
                           Unwearable, Untakable, Dragable, HandUsable, NONE }

    public ItemSize itemSize;
    [SerializeReference]
    public IUse use;
    [SerializeReference]
    public ItemType[] itemTypes;

    public ItemUseData(ItemSize itemSize, IUse use, ItemType[] itemTypes)
    {
        this.itemSize = itemSize;
        this.use = use;
        this.itemTypes = itemTypes;
    }

    public ItemUseData(IUse use) 
    {
        this.use = use;
        this.itemTypes = new ItemType[] { ItemType.NONE };
    }
}
