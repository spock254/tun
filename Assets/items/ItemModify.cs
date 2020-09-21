using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class ItemModify
{
    //public static void RemoveItem(List<InventoryCell> inventory, InventoryCell item) 
    //{
    //    inventory.Remove(item);
    //}

    public static void UseShopItem(Item item, Gold gold) 
    {
        if (gold.GoldAmount >= item.itemPrice) 
        {
            Debug.Log("Buy");
            gold.GoldAmount -= item.itemPrice;
        }
        else 
        {
            Debug.Log("Not enough gold");
        }
    }
    public static void UseItem(Item item, Stats stats) 
    {
        if (item == null) 
        {
            Debug.LogError("UseItem item == null");
            return;
        }
        //item.stats.duration
        if (item.stats.playerStats == PlayerStats.HUNGER) 
        {
            stats.Hunger.value += item.stats.value;
            stats.Hunger.tempDuration += item.stats.duration;
            stats.Hunger.buffTime = item.stats.time;
        }
        else if (item.stats.playerStats == PlayerStats.SLEEP)
        {
            stats.Sleep.value += item.stats.value;
            stats.Sleep.tempDuration += item.stats.duration;
            stats.Sleep.buffTime = item.stats.time;
        }
        else if (item.stats.playerStats == PlayerStats.HAPPINESS)
        {
            stats.Happiness.value += item.stats.value;
            stats.Happiness.tempDuration += item.stats.duration;
            stats.Happiness.buffTime = item.stats.time;
        }
        else if (item.stats.playerStats == PlayerStats.HEALTH)
        {
            stats.Health.value += item.stats.value;
            stats.Health.tempDuration += item.stats.duration;
            stats.Health.buffTime = item.stats.time;
        }

    }
}
