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
        for (int j = 0; j < spawnPoint.transform.childCount; j++)
        {
            GameObject.Destroy(spawnPoint.transform.GetChild(j).gameObject);
        }

        Debug.Log(mousePosition.x +" "+mousePosition.y);
        rightButtonClick_panel.SetActive(true);
        rightButtonClick_panel.transform.position = SetPanelPosition(mousePosition);

        int i = 0;

        foreach (var hit in hits)
        {
            float spawnY = i * 15;
            Debug.Log(hit.collider.name);
            Vector3 pos = new Vector3(spawnPoint.transform.position.x, spawnY,
                                        spawnPoint.transform.position.z);
            GameObject spawnedItem = (GameObject)Instantiate(item, pos, spawnPoint.transform.rotation);
            
            spawnedItem.transform.SetParent(spawnPoint.transform, false);

            i++;
            //Debug.Log("hit");
        }
    }

    Vector3 SetPanelPosition(Vector2 mousePosition) 
    {
        RectTransform rt = rightButtonClick_panel.GetComponent<RectTransform>();
        //Vector2 viewportPoint = Camera.main.WorldToViewportPoint(mousePosition);

        float leftCornerX = -1;//rt.rect.width / 2;
        float rightCornerY = -2f;//rt.rect.height / 2;
        //Debug.Log(rt.rect.x + " " + rt.rect.y);
        Debug.Log(mousePosition);
        return new Vector3(mousePosition.x - leftCornerX, mousePosition.y - rightCornerY, rightButtonClick_panel.transform.position.z);

    }
}
