using System;
using UnityEngine;
[System.Serializable]
public class Item
{
    public int id;
    public Sprite itemSprite;
    public ItemStats stats;
    public ItemFightStats ItemFightStats;
    public string itemName;
    public int itemPrice;
    public ItemUseData itemUseData;

    public Item(ItemStats stats, ItemFightStats itemFightStats, string itemName, 
        int itemPrice, ItemUseData itemUseData, Sprite itemSprite)
    {
        this.id = GenerateId(itemName, stats);
        this.stats = stats;
        this.ItemFightStats = itemFightStats;
        this.itemName = itemName;
        this.itemPrice = itemPrice;
        this.itemUseData = itemUseData;
        this.itemSprite = itemSprite;
    }

    //ctr for non eatable items
    public Item(ItemFightStats itemFightStats, string itemName, int itemPrice, 
        ItemUseData itemUseData, Sprite itemSprite)
    {
        this.stats = new ItemStats(PlayerStats.NONE, 0, 0, 0);
        this.id = GenerateId(itemName, stats);
        this.ItemFightStats = itemFightStats;
        this.itemName = itemName;
        this.itemPrice = itemPrice;
        this.itemUseData = itemUseData;
        this.itemSprite = itemSprite;
    }

    // кстр для пустых ячеек инв
    public Item(string itemName, ItemUseData itemUseData, Sprite sprite) 
    {
        this.itemName = itemName;
        this.itemUseData = itemUseData;
        this.itemSprite = sprite;
    }

    private int GenerateId(string name, ItemStats stats) 
    {

        return name.GetHashCode() + 
            (int)stats.value + 
            (int)stats.playerStats;
    }
}
