using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Actions
{
    public void ItemPickUp(GameObject itemGo)
    {
        Item item = itemGo.GetComponent<ItemCell>().item;

        DressCell(currentHand, item);

        Destroy(itemGo);
    }

    //когда не чего не надето
    public void SetDefaultItem(Button cell)
    {
        Item deffaultItem = itemDB.deffaultItems[cell.name.ToLower()];
        DressCell(cell, deffaultItem);
    }

    public void DressCell(Button cellToDress, Item item)
    {
        cellToDress.GetComponent<ItemCell>().item = item;
        cellToDress.GetComponent<Image>().sprite = item.itemSprite;
    }

    void DressOrTakeOff(Button dressOn, Button takeOff, Item item, bool isDressing)
    {
        DressCell(dressOn, item);

        SetDefaultItem(takeOff);

        if (isDressing)
        {
            item.itemUseData.use.Use_To_Ware();
        }
        else
        {
            item.itemUseData.use.Use_To_TakeOff();
        }
    }
    public bool IsEmpty(Button button)
    {
        return button.GetComponent<ItemCell>().item == itemDB.deffaultItems[button.name.ToLower()];
    }
    public Button GetAnotherHand(Button currentHand, Button left_hand_btn, Button right_hand_btn)
    {
        if (currentHand == left_hand_btn)
        {
            return right_hand_btn;
        }

        return left_hand_btn;
    }

    public bool IsInActionRadius(Vector2 mousePos2D, Vector2 objPosition, float radius)
    {
        return Vector2.Distance(mousePos2D, player.position) < actioPlayerRadius;
    }

    public bool IsInActionRadius()
    {
        return Vector2.Distance(mousePos, player.position) < actioPlayerRadius;
    }

    bool isSameTypes(string t1, string t2)
    {
        return t1.ToLower() == t2.ToLower();
    }

    public void CloseOpenContainer(GameObject panel, ref bool isOpen)
    {
        isOpen = !isOpen;
        panel.SetActive(isOpen);
    }
    Button SwapActiveHand()
    {
        isLeftHand = !isLeftHand;
        currentHand.GetComponentInChildren<Text>().text = " ";
        return isLeftHand ? left_hand_btn : right_hand_btn;
    }

    public void ContainerContentInit(List<Item> innerItems, GameObject panel)
    {
        Button[] cells = panel.GetComponentsInChildren<Button>();
        int i = 0;

        for (; i < innerItems.Count; i++)
        {
            DressCell(cells[i], innerItems[i]);
        }

        //if (innerItems.Count < cells.Length) 
        //{
        //    i++;
        //    SetDefaultItem(cells[i]);
        //}

        for (; i < cells.Length; i++)
        {
            SetDefaultItem(cells[i]);
            //cells[i].gameObject.SetActive(false);
        }
        //RectTransform rt = bag_panel.GetComponent<RectTransform>();
        //rt.sizeDelta = new Vector2(rt.sizeDelta.x, 50 * i);
    }

    bool IsItemTypePresent(Item item, ItemUseData.ItemType type_to_find)
    {
        foreach (var item_type in item.itemUseData.itemTypes)
        {
            if (item_type == type_to_find)
            {
                return true;
            }
        }

        return false;
    }

    public Item GetItemInHand(Button hand)
    {
        return hand.GetComponent<ItemCell>().item;
    }
}
