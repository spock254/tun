using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIContrall : MonoBehaviour //, IPointerClickHandler
{
    public ItemInit itemDB;

    public Button head_btn;
    Image head_sprite;

    public Button face_btn;
    Image face_sprite;

    public Button body_btn;
    Image body_sprite;
    
    public Button arm_btn;
    Image arm_sprite;
    
    public Button lags_btn;
    Image lags_sprite;

    public Button bag_btn;
    Image bag_sprite;

    public Button left_hand_btn;
    Image left_hand_sprite;

    public Button right_hand_btn;
    Image right_hand_sprite;

    public Button left_pack_btn;
    Image left_pack_sprite;

    public Button right_pack_btn;
    Image right_pack_sprite;

    public Button card_btn;
    Image card_sprite;

    public GameObject bag_panel;

    bool isLeftHand = true;
    Button currentHand;

    void Start()
    {
        InitCells();

        currentHand = left_hand_btn;
        //head_sprite = head_btn.GetComponent<Image>();
        //head_sprite.sprite = itemDB.items[0].itemSprite;
        left_hand_btn.GetComponent<ItemCell>().item = itemDB.items[0];
        left_hand_btn.GetComponent<Image>().sprite = itemDB.items[0].itemSprite;
        //    left_hand_btn.GetComponent<ItemCell>().empty_cell_sprite;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.mouseScrollDelta.y != 0) 
        {
            currentHand = SwapActiveHand();
            currentHand.GetComponentInChildren<Text>().text = "*";
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                //Debug.Log(hit.collider.gameObject.tag);
                if (hit.collider.gameObject.tag == "player") 
                { 
                    if (currentHand.GetComponent<ItemCell>() != null)
                    {
                        Item item = currentHand.GetComponent<ItemCell>().item;
                        item.itemUseData.use.Use_On_Player();
                    }
                }
            }
        }
    }

    Button SwapActiveHand() 
    {
        isLeftHand = !isLeftHand;
        currentHand.GetComponentInChildren<Text>().text = " ";
        return isLeftHand ? left_hand_btn : right_hand_btn;
    }

    public void OnInvButtonClick(string itemType) 
    { 
        GameObject cell = GameObject.FindGameObjectWithTag(itemType.ToString()
                                    .ToLower() + "_cell");

        Debug.Log(currentHand.GetComponent<ItemCell>().item);
        Debug.Log(itemDB.deffaultItems[currentHand.name.ToLower()]);
        if (currentHand.GetComponent<ItemCell>().item != itemDB.deffaultItems[currentHand.name.ToLower()])
        {
            Item item = currentHand.GetComponent<ItemCell>().item;

            foreach (var item_types in item.itemUseData.itemTypes)
            {
                if (itemType == item_types.ToString())
                {
                    // 1 func
                    cell.GetComponent<ItemCell>().item = item;
                    cell.GetComponent<Image>().sprite = item.itemSprite;

                    SetDefaultItem(currentHand);

                    item.itemUseData.use.Use_To_Ware();
                    return;
                }

            }
        }
        else 
        {
            Debug.Log("EMPTY");
        }
    }
    //когда не чего не надето
    void SetDefaultItem(Button cell) 
    {
        Item deffaultItem = itemDB.deffaultItems[cell.name.ToLower()];
        cell.GetComponent<ItemCell>().item = deffaultItem;
        cell.GetComponent<Image>().sprite = deffaultItem.itemSprite;
    }

    void InitCells() 
    {
        head_btn.GetComponent<ItemCell>().item = itemDB.deffaultItems["head"];
        face_btn.GetComponent<ItemCell>().item = itemDB.deffaultItems["face"];
        body_btn.GetComponent<ItemCell>().item = itemDB.deffaultItems["body"];
        lags_btn.GetComponent<ItemCell>().item = itemDB.deffaultItems["lags"];
        arm_btn.GetComponent<ItemCell>().item = itemDB.deffaultItems["arm"];
        bag_btn.GetComponent<ItemCell>().item = itemDB.deffaultItems["bag"];
        left_hand_btn.GetComponent<ItemCell>().item = itemDB.deffaultItems["left_hand"];
        right_hand_btn.GetComponent<ItemCell>().item = itemDB.deffaultItems["right_hand"];
        left_pack_btn.GetComponent<ItemCell>().item = itemDB.deffaultItems["packet_left"];
        right_pack_btn.GetComponent<ItemCell>().item = itemDB.deffaultItems["packet_right"];
        card_btn.GetComponent<ItemCell>().item = itemDB.deffaultItems["card"];
    }
}
