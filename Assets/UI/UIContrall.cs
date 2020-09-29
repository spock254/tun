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
        currentHand = left_hand_btn;
        //head_sprite = head_btn.GetComponent<Image>();
        //head_sprite.sprite = itemDB.items[0].itemSprite;
        left_hand_btn.GetComponent<ItemCell>().item = itemDB.items[0];
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.mouseScrollDelta.y > 0) 
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
                        Item item = left_hand_btn.GetComponent<ItemCell>().item;
                        item.itemUseData.use.Use_On_Player();
                    }
                

                }
                //hit.collider.attachedRigidbody.AddForce(Vector2.up);
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
        if (currentHand.GetComponent<ItemCell>().item != null) 
        {
            Item item = currentHand.GetComponent<ItemCell>().item;

            foreach (var item_types in item.itemUseData.itemTypes)
            {
                if (itemType == item_types.ToString()) 
                {
                    Debug.Log("qwe");
                    this.gameObject.GetComponent<ItemCell>().item = item;
                    currentHand.GetComponent<ItemCell>().item = null;

                }

            }
        
        }
    }
}
