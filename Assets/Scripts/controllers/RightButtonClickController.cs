using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButtonClickController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rightButtonClick_panel;
    public void RightButtonClick(RaycastHit2D[] hits, Vector2 mousePosition) 
    {
        Debug.Log(mousePosition.x +" "+mousePosition.y);
        rightButtonClick_panel.SetActive(true);
        rightButtonClick_panel.transform.position = SetPanelPosition(mousePosition);

        foreach (var hit in hits)
        {
            Debug.Log(hit.collider.name);
        }
    }

    Vector3 SetPanelPosition(Vector2 mousePosition) 
    {
        RectTransform rt = rightButtonClick_panel.GetComponent<RectTransform>();

        float leftCornerX = rt.rect.width / 2;
        float rightCornerY = rt.rect.height / 2;
        Debug.Log(leftCornerX);
        return new Vector3(mousePosition.x - leftCornerX, mousePosition.y - rightCornerY, rightButtonClick_panel.transform.position.z);
    }
}
