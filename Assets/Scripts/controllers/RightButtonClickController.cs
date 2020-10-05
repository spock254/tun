using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightButtonClickController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rightButtonClick_panel;
    public GameObject spawnPoint;
    public GameObject item;
    public void RightButtonClick(RaycastHit2D[] hits, Vector2 mousePosition) 
    {
        DestroyItems();

        Debug.Log(mousePosition.x +" "+mousePosition.y);
        rightButtonClick_panel.SetActive(true);
        rightButtonClick_panel.transform.position = SetPanelPosition(mousePosition);

        float step = GetItemHeight();

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.name.Contains("item")) 
            { 
                float spawnY = i * step;
                Vector3 pos = new Vector3(spawnPoint.transform.position.x, spawnY,
                                            spawnPoint.transform.position.z);
                GameObject spawnedItem = (GameObject)Instantiate(item, pos, spawnPoint.transform.rotation);
                
                SetItemName(spawnedItem, hits[i].collider.name);

                spawnedItem.transform.SetParent(spawnPoint.transform, false);
            }
            

        }

    }

    Vector3 SetPanelPosition(Vector2 mousePosition) 
    {
        RectTransform rt = rightButtonClick_panel.GetComponent<RectTransform>();
        //Vector2 viewportPoint = Camera.main.WorldToViewportPoint(mousePosition);

        float leftCornerX = 0;//rt.rect.width / 2;
        float rightCornerY = 0;//rt.rect.height / 2;
        //Debug.Log(rt.rect.x + " " + rt.rect.y);
        return new Vector3(mousePosition.x - leftCornerX, mousePosition.y - rightCornerY, rightButtonClick_panel.transform.position.z);

    }

    void DestroyItems() 
    {
        for (int j = 0; j < spawnPoint.transform.childCount; j++)
        {
            GameObject.Destroy(spawnPoint.transform.GetChild(j).gameObject);
        }
    }

    float GetItemHeight() 
    {
        return item.GetComponent<RectTransform>().rect.height;
    }

    void SetItemName(GameObject spawnedItem, string name) 
    {
        spawnedItem.transform.GetChild(0).GetComponent<Text>().text = name;
    }
}
