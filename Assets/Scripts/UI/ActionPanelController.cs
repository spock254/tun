using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPanelController : MonoBehaviour
{
    public Transform player;

    //Button currrentHand;
    UIContrall uiContrall;
    void Start()
    {
        uiContrall = GameObject.FindGameObjectWithTag("ui")
                        .GetComponent<UIContrall>();
        //currrentHand = uiContrall.currentHand;
    }


    public void OnDropClick() 
    {
        if (!uiContrall.IsEmpty(uiContrall.currentHand))
        {
            uiContrall.currentHand.GetComponent<ItemCell>().item.itemUseData
                                  .use.Use_To_Drop(player, 
                                  uiContrall.currentHand
                                  .GetComponent<ItemCell>().item);
        }
        else 
        {
            Debug.Log("nothing");
        }
    }
}
