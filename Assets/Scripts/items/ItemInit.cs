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


    public Sprite sprite_helmet;
    void Awake()
    {
        items = new List<Item>();
        deffaultItems = new Dictionary<string, Item>();

        Item helmet = new Item(new ItemFightStats(0, 5), "helmet", 200,
            new ItemUseData(ItemUseData.ItemSize.Middle, new DummyItemUse(),
                            new ItemUseData.ItemType[] { ItemUseData.ItemType.Head, 
                                                         ItemUseData.ItemType.HandUsable }), 
                            sprite_helmet);

        items.Add(helmet);

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
    }
}
