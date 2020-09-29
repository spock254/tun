using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInit : MonoBehaviour
{
    public List<Item> items;

    public Sprite sprite_helmet;
    void Awake()
    {
        items = new List<Item>();

        Item helmet = new Item(new ItemFightStats(0, 5), "helmet", 200,
            new ItemUseData(ItemUseData.ItemSize.Middle, new DummyItemUse(),
                            new ItemUseData.ItemType[] { ItemUseData.ItemType.Head }), 
                            sprite_helmet);

        items.Add(helmet);
    }
}
