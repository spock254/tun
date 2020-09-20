using System;

public class Item
{
    public int id;
    public ItemStats stats;
    public string itemName;
    public int itemPrice;

    public Item(ItemStats stats, string itemName, int itemPrice)
    {
        this.id = GenerateId(itemName, stats);
        this.stats = stats;
        this.itemName = itemName;
        this.itemPrice = itemPrice;
    }

    private int GenerateId(string name, ItemStats stats) 
    {

        return name.GetHashCode() + 
            (int)stats.value + 
            (int)stats.playerStats;
    }
}
