using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    [HideInInspector]
    public StaticCaseItemEvent OnStaticCaseItemEvent;
    
    public CasePanelController casePanelController;
    void Awake()
    {
        OnStaticCaseItemEvent = new StaticCaseItemEvent();
        OnStaticCaseItemEvent.AddListener(casePanelController.ActivateStaticItemPanel);
    }

}
