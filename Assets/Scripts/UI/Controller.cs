using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Controller : MonoBehaviour //, IPointerClickHandler
{
    public ItemInit itemDB;

    public Button head_btn;

    public Button face_btn;

    public Button body_btn;
    
    public Button arm_btn;
    
    public Button lags_btn;

    public Button bag_btn;

    public Button left_hand_btn;

    public Button right_hand_btn;

    public Button left_pack_btn;

    public Button right_pack_btn;

    public Button card_btn;

    [Header("Bag cells")]
    public Button bagCell1;
    public Button bagCell2;
    public Button bagCell3;
    public Button bagCell4;
    public Button bagCell5;

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
                        GameObject itemGo = hit.collider.gameObject;
                        Item item = itemGo.GetComponent<ItemCell>().item;

                        DressCell(currentHand, item);

                        Destroy(itemGo);
                }
            }
        }
    }

    public void OnBagButtonClick(string bagCellIndex) 
    {
        GameObject bagCellGo = GameObject.FindGameObjectWithTag(bagCellIndex);
        Button bagCellBtn = bagCellGo.GetComponent<Button>();
        Item bagItem = bagCellGo.GetComponent<ItemCell>().item;
        Item handItem = currentHand.GetComponent<ItemCell>().item;


        if (IsEmpty(currentHand))
        {
            DressCell(currentHand, bagItem);
            SetDefaultItem(bagCellBtn);
        }
        else //TODO: проверить если достаточно места в сумке 
        {
            DressCell(bagCellBtn, handItem);
            SetDefaultItem(currentHand);
        }
        
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
                // если сумка открыта, тогда закрыть
                foreach (var item_types in itemInHand.itemUseData.itemTypes)
                {
                    Debug.Log("close");
                    if (item_types == ItemUseData.ItemType.Openable && isBagOpen)
                    {
                        CloseOpenBag();
                    }
                }

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
                            // TODO:  
                            if (!isBagOpen) 
                            { 
                                itemInCell.itemUseData.use.Use_To_Open();
                            }

                            CloseOpenBag();

                            if (isBagOpen) 
                            {
                                BagContentInit(itemInCell);
                                Debug.Log("bag init");
                            }

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

        bagCell1.GetComponent<ItemCell>().item = itemDB.deffaultItems["1"];
        bagCell2.GetComponent<ItemCell>().item = itemDB.deffaultItems["2"];
        bagCell3.GetComponent<ItemCell>().item = itemDB.deffaultItems["3"];
        bagCell4.GetComponent<ItemCell>().item = itemDB.deffaultItems["4"];
        bagCell5.GetComponent<ItemCell>().item = itemDB.deffaultItems["5"];
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
    Button SwapActiveHand() 
    {
        isLeftHand = !isLeftHand;
        currentHand.GetComponentInChildren<Text>().text = " ";
        return isLeftHand ? left_hand_btn : right_hand_btn;
    }

    void BagContentInit(Item bag) 
    {
        Button[] cells = bag_panel.GetComponentsInChildren<Button>();
        for (int i = 0; i < bag.innerItems.Count; i++)
        {
            // img[i].sprite = bag.innerItems[i].itemSprite;
            DressCell(cells[i], bag.innerItems[i]);
        }
    }
}
