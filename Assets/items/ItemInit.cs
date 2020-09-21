using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInit : MonoBehaviour
{
    public List<Item> items;

    void Awake()
    {
        items = new List<Item>();

        Item item_apple1 = new Item(new ItemStats(PlayerStats.HUNGER,
            20f, 3f, 3), "apple", 5);
        Item item_apple2 = new Item(new ItemStats(PlayerStats.HUNGER,
            20f, 3f, 3), "apple", 5);
        Item item_coffe = new Item(new ItemStats(PlayerStats.SLEEP,
            30f, 10f, 5), "coffe", 15);

        items.Add(GlobalItems.GetCoffe());
        items.Add(GlobalItems.GetCoffe());

        items.Add(item_apple1);
        items.Add(item_apple2);
        items.Add(item_coffe);
        items.Add(new Item(new ItemStats(PlayerStats.SLEEP,
            30f, 10f, 5), "coffe", 15));
        items.Add(new Item(new ItemStats(PlayerStats.HAPPINESS,
            30f, 7f, 7), "seed", 3));
        items.Add(new Item(new ItemStats(PlayerStats.HAPPINESS, 15, 5, 5), "sig", 20));
    }
}
