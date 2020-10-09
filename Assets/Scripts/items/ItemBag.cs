using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemBag : Item
{
    public int maxBagSize;
    public List<Item> items;

    public ItemBag(ItemFightStats itemFightStats, string itemName, int itemPrice,
        ItemUseData itemUseData, Sprite itemSprite, int maxBagSize, List<Item> items) 
        : base(itemFightStats, itemName, itemPrice, itemUseData, itemSprite)
    {
        this.maxBagSize = maxBagSize;
        this.items = items;
    }
}
