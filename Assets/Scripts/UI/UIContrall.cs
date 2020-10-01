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
    bool isBagOpen = false; 

    bool isLeftHand = true;
    public Button currentHand;

    [Header("Player data")]
    public float actioPlayerRadius;
    public Transform player;

    void Start()
    {
        InitCells();

        currentHand = left_hand_btn;
        //head_sprite = head_btn.GetComponent<Image>();
        //head_sprite.sprite = itemDB.items[0].itemSprite;
        //left_hand_btn.GetComponent<ItemCell>().item = itemDB.items[0];
        //left_hand_btn.GetComponent<Image>().sprite = itemDB.items[0].itemSprite;
        DressCell(head_btn, itemDB.items[0]);
        DressCell(right_hand_btn, itemDB.items[1]);
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
            //Debug.Log(hit.collider.name);
                if (hit.collider.gameObject.tag == "player") 
                { 
                    Item item = currentHand.GetComponent<ItemCell>().item;
                    item.itemUseData.use.Use_On_Player();
                }

                //TODO: создать радиус подбора дропа
                // ели на полу айтем и в руках не чего нет
                if (hit.collider.name.Contains(Global.DROPED_ITEM_PREFIX) 
                                      && IsEmpty(currentHand) 
                                      && IsInActionRadius(mousePos, player.position, actioPlayerRadius)) 
                {
                        Debug.Log("in");
                        GameObject itemGo = hit.collider.gameObject;
                        Item item = itemGo.GetComponent<ItemCell>().item;

                        DressCell(currentHand, item);

                        Destroy(itemGo);
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
        GameObject cellGo = GameObject.FindGameObjectWithTag(itemType.ToString()
                                    .ToLower() + "_cell");
        Button cell = cellGo.GetComponent<Button>();

        if (!IsEmpty(currentHand)) //если в руке что то есть
        {
            Item itemInHand = currentHand.GetComponent<ItemCell>().item;

            if (IsEmpty(cell))  //если не чего не надето
            {
                foreach (var item_types in itemInHand.itemUseData.itemTypes)
                {
                    if (isSameTypes(itemType, item_types.ToString()))
                    {
                        DressOrTakeOff(cell, currentHand, itemInHand, true);
                        return;
                    }
                }
            }
            else //если одето 
            { 
            
            }
        }
        else //если в руках не чего нет
        {
            Item itemInCell = cell.GetComponent<ItemCell>().item;

            if (cell == GetAnotherHand()) // если взаимодействуем со второй рукой
            {
                if (!IsEmpty(GetAnotherHand())) // если вторая рука занята
                {
                    foreach (var item_type in itemInCell.itemUseData.itemTypes)
                    {
                        if (item_type == ItemUseData.ItemType.HandUsable)
                        {
                            itemInCell.itemUseData.use.Use_In_Hands();
                            return;
                        }
                        else if (item_type == ItemUseData.ItemType.Openable) 
                        {
                            if (!isBagOpen) 
                            { 
                                itemInCell.itemUseData.use.Use_To_Open();
                            }

                            CloseOpenBag();
                            return;
                        }
                    }
                }
                else // если вторая рука пустая
                {

                }
                return;
            }

            if (!IsEmpty(cell)) //если одето
            {
                DressOrTakeOff(currentHand, cell, itemInCell, false);
            }
            else 
            {
                itemInCell.itemUseData.use.Use_When_Ware();
            }
        }
    }

    //когда не чего не надето
    public void SetDefaultItem(Button cell) 
    {
        Item deffaultItem = itemDB.deffaultItems[cell.name.ToLower()];
        DressCell(cell, deffaultItem);
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

    void DressCell(Button cellToDress, Item item) 
    {
        cellToDress.GetComponent<ItemCell>().item = item;
        cellToDress.GetComponent<Image>().sprite = item.itemSprite;
    }

    void DressOrTakeOff(Button dressOn, Button takeOff, Item item, bool isDressing) 
    {
        //dressOn.GetComponent<ItemCell>().item = item;
        //dressOn.GetComponent<Image>().sprite = item.itemSprite;
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
    Button GetAnotherHand() 
    {
        if (currentHand == left_hand_btn) 
        {
            return right_hand_btn;
        }

        return left_hand_btn;
    }

    bool IsInActionRadius(Vector2 mousePos2D, Vector2 objPosition, float radius) 
    {
        return Vector2.Distance(mousePos2D, player.position) < actioPlayerRadius;
    }

    bool isSameTypes(string t1, string t2) 
    {
        return t1.ToLower() == t2.ToLower();
    }

    void CloseOpenBag() 
    {
        isBagOpen = !isBagOpen;
        bag_panel.SetActive(isBagOpen);
    }
}
