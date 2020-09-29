﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUseData
{
    public enum ItemSize { Small, Middle, Big }
    public enum ItemType { Head, Face, Body, Arm, Lags, Bag, Card, 
                           Unwearable, Untakable, Dragable }

    public ItemSize itemSize;
    public IUse use;
    public ItemType[] itemTypes;

    public ItemUseData(ItemSize itemSize, IUse use, ItemType[] itemTypes)
    {
        this.itemSize = itemSize;
        this.use = use;
        this.itemTypes = itemTypes;
    }
}