using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInit : MonoBehaviour
{
    public List<InventoryCell> inventory;
    public ItemInit itemInit;
    void Start()
    {
        InventoryModify.CreateInvBaseOnItemList(ref inventory, itemInit.items);
        //inventory = new List<InventoryCell>();

        //foreach (Item item in itemInit.items)
        //{
        //    bool skip = false;
        //    foreach (var cell in inventory)
        //    {
        //        if (item.id == cell.item.id)
        //        {
        //            cell.count++;
        //            skip = true;
        //            break;
        //        }
        //    }
        //    if (!skip)
        //    {
        //        inventory.Add(new InventoryCell(item, 1));

        //    }
        //}
    }
}
