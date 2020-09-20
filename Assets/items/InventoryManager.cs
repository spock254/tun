using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    public InventoryInit inventory;
    public ItemInit item;
    public StatInit stats;
    public UI ui;
    UnityEvent removeItem;

    private void Start()
    {
        if (removeItem == null) 
        {
            removeItem = new UnityEvent();
        }

        //removeItem.AddListener(RemoveFromList);
        //removeItem.AddListener(UpdateInventory);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            ItemModify.UseItem(ui.choosedItem, stats.stats);
            RemoveFromList(ui.choosedItem.id);
            UpdateInventory();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0)) 
        {
            AddToList(new Item(new ItemStats(PlayerStats.HEALTH, 0, 0.3f, 5),
                    "posion", 200));
            UpdateInventory();
        }
    }

    private void RemoveFromList(int id)
    {
        Item itemToRemove = item.items.FirstOrDefault(i => i.id == id);

        if (itemToRemove == null) 
        {
            Debug.LogError("RemoveFromList itemToRemove == null");
            return;
        }

        item.items.Remove(itemToRemove);
    }

    private void AddToList(Item newItem) 
    {
            item.items.Add(newItem);
    }
    private void UpdateInventory()
    {
        inventory.inventory.Clear();

        foreach (Item item in item.items)
        {
            bool skip = false;
            foreach (var cell in inventory.inventory)
            {
                if (item.id == cell.item.id)
                {
                    cell.count++;
                    skip = true;
                    break;
                }
            }
            if (!skip)
            {
                inventory.inventory.Add(new InventoryCell(item, 1));

            }
        }
    }
}
