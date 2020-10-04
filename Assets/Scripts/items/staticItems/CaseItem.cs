using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CaseItem : MonoBehaviour
{
    [SerializeReference]
    public List<Item> items;
    [SerializeReference]
    public List<Item> itemsToUnlockCase;

    public int caseCapacity;
    public bool isLocked = false;

    [Header("for testing")]
    public Sprite sprite_chest;
    public Sprite sprite_helmet;
    public Sprite sprite_card;

    private void Awake()
    {
        items = new List<Item>();
        itemsToUnlockCase = new List<Item>();

        Item helmet = new Item(new ItemFightStats(0, 5), "helmet", 200,
                    new ItemUseData(ItemUseData.ItemSize.Middle, new DummyItemUse(),
                    new ItemUseData.ItemType[] { ItemUseData.ItemType.Head,
                                                         ItemUseData.ItemType.HandUsable }),
                    sprite_helmet, Global.Item.MIDDLE_SIZE, null);

        Item chest = new Item(new ItemFightStats(0, 10), "chest", 200,
                    new ItemUseData(ItemUseData.ItemSize.Middle, new DummyItemUse(),
                    new ItemUseData.ItemType[] { ItemUseData.ItemType.Body,
                                                         ItemUseData.ItemType.HandUsable }),
                    sprite_chest, Global.Item.MIDDLE_SIZE, null);

        items.Add(helmet);
        items.Add(chest);


        Item card = new Item(new ItemFightStats(0, 0), "card", 200,
        new ItemUseData(ItemUseData.ItemSize.Small, new DummyItemUse(),
                    new ItemUseData.ItemType[] { ItemUseData.ItemType.Card,
                                                         ItemUseData.ItemType.Packet_left,
                                                         ItemUseData.ItemType.Packet_right}),
                                                         sprite_card, 2, null);

        itemsToUnlockCase.Add(card);
    }

    public int CountInnerCapacity()
    {
        int innerCapacity = 0;

        foreach (var item in items)
        {
            innerCapacity += item.GetItemSize();
        }

        return innerCapacity;
    }
}
