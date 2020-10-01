using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPanelController : MonoBehaviour
{
    public Transform player;
    public Transform prefab;
    //Button currrentHand;
    Controller uiContrall;
    void Start()
    {
        uiContrall = GameObject.FindGameObjectWithTag("ui")
                        .GetComponent<Controller>();
        //currrentHand = uiContrall.currentHand;
    }


    public void OnDropClick() 
    {
        if (!uiContrall.IsEmpty(uiContrall.currentHand))
        {
            Item item = uiContrall.currentHand.GetComponent<ItemCell>().item;
            item.itemUseData.use.Use_To_Drop(prefab, player, item);

            DropItem(prefab, player, item);

        }
        else 
        {
            Debug.Log("nothing");
        }
    }

    void DropItem(Transform prefab, Transform player, Item item) 
    {
        prefab.GetComponent<ItemCell>().item = item;
        prefab.GetComponent<SpriteRenderer>().sprite = item.itemSprite;
        prefab.name = Global.DROPED_ITEM_PREFIX + item.itemName;

        Instantiate(prefab, player.position, Quaternion.identity);
        //if (prefab.GetComponent<ItemCell>().item == null) { Debug.Log("null"); }
        uiContrall.SetDefaultItem(uiContrall.currentHand);
    }
}
