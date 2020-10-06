using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInit : MonoBehaviour
{
    public List<Item> items;
    public Dictionary<string, Item> deffaultItems;

    [SerializeField] Sprite head;
    [SerializeField] Sprite face;
    [SerializeField] Sprite body;
    [SerializeField] Sprite arm;
    [SerializeField] Sprite lags;
    [SerializeField] Sprite bag;
    [SerializeField] Sprite left_hand;
    [SerializeField] Sprite right_hand;
    [SerializeField] Sprite left_pack;
    [SerializeField] Sprite right_pack;
    [SerializeField] Sprite card;
    [SerializeField] Sprite bagCell;

    public Sprite sprite_helmet;
    public Sprite sprite_bag;
    public Sprite sprite_bag2;
    public Sprite sprite_chest;
    public Sprite sprite_card;
    void Awake()
    {
        items = new List<Item>();
        deffaultItems = new Dictionary<string, Item>();

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



        Item bag = new Item(new ItemFightStats(0, 0), "bag", 150,
            new ItemUseData(ItemUseData.ItemSize.Big, new DummyItemUse(),
                            new ItemUseData.ItemType[] { ItemUseData.ItemType.Bag,
                                                        ItemUseData.ItemType.Openable}),
                            sprite_bag, 10, new List<Item>() { chest });


        Item card = new Item(new ItemFightStats(0, 0), "card", 200,
                new ItemUseData(ItemUseData.ItemSize.Small, new DummyItemUse(),
                            new ItemUseData.ItemType[] { ItemUseData.ItemType.Card,
                                                         ItemUseData.ItemType.Packet_left,
                                                         ItemUseData.ItemType.Packet_right}),
            sprite_card, 2, null);

        Item bag2 = new Item(new ItemFightStats(0, 0), "bag2", 150,
            new ItemUseData(ItemUseData.ItemSize.Big, new DummyItemUse(),
                    new ItemUseData.ItemType[] { ItemUseData.ItemType.Bag,
                                                 ItemUseData.ItemType.Openable}),
                    sprite_bag2, 10, new List<Item>() { card, card, card });

        items.Add(helmet);
        items.Add(bag);
        items.Add(bag2);
        items.Add(card);

        InitDefaultItems();
    }

    void InitDefaultItems() 
    {
        deffaultItems.Add("head", new Item("head", new ItemUseData(new UseHead()), head));
        deffaultItems.Add("body", new Item("body", new ItemUseData(new UseBody()), body));
        deffaultItems.Add("face", new Item("face", new ItemUseData(new UseFace()), face));
        deffaultItems.Add("arm", new Item("arm", new ItemUseData(new UseArm()), arm));
        deffaultItems.Add("lags", new Item("lags", new ItemUseData(new UseLags()), lags));
        deffaultItems.Add("bag", new Item("bag", new ItemUseData(new UseBag()), bag));
        deffaultItems.Add("left_hand", new Item("left_hand", new ItemUseData(new UseLeftHand()), left_hand));
        deffaultItems.Add("right_hand", new Item("right_hand", new ItemUseData(new UseRightHand()), right_hand));
        deffaultItems.Add("packet_left", new Item("packet_left", new ItemUseData(new UseLeftPack()), left_pack));
        deffaultItems.Add("packet_right", new Item("packet_right", new ItemUseData(new UseRightPack()), right_pack));
        deffaultItems.Add("card", new Item("card", new ItemUseData(new UseCard()), card));

        // инит для слотов сумки
        for (int i = 1; i < 11; i++)
        {
            deffaultItems.Add(i.ToString(), new Item(i.ToString(), new ItemUseData(new UseBagCell()), bagCell));
        }

        for (int i = 1; i < 11; i++)
        {
            deffaultItems.Add(i.ToString() + "c", new Item(i.ToString() + "c", new ItemUseData(new UseBagCell()), bagCell));
        }
    }
}
