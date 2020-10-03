using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasePanelController : MonoBehaviour
{
    public GameObject staticItemPanel;
    CaseItem caseItem;
    public Controller controller;
    public bool caseIsOpen;

    public void ActivateStaticItemPanel(CaseItem caseItem) 
    {
        this.caseItem = caseItem;
        controller.CloseOpenContainer(staticItemPanel, ref caseIsOpen);
        controller.ContainerContentInit(caseItem.items, staticItemPanel);
    }

    public void OnCasePanelClick(string caseCellIndex) 
    {
        //GameObject bagCellGo = GameObject.FindGameObjectWithTag(caseCellIndex);
        //Button bagCellBtn = bagCellGo.GetComponent<Button>();
       // controller.OnBagButtonClick(caseCellIndex);

        GameObject caseCellGo = GameObject.FindGameObjectWithTag(caseCellIndex);
        Button caseCellBtn = caseCellGo.GetComponent<Button>();

        Item caseCellItem = caseCellGo.GetComponent<ItemCell>().item;
        Item handItem = controller.currentHand.GetComponent<ItemCell>().item;
        List<Item> innerItems = caseItem.items;

        if (controller.IsEmpty(controller.currentHand) && !controller.IsEmpty(caseCellBtn))
        {
            innerItems.Remove(caseCellItem);
            controller.DressCell(controller.currentHand, caseCellItem);
            controller.SetDefaultItem(caseCellBtn);
        }
        else if (!controller.IsEmpty(controller.currentHand) && !controller.IsEmpty(caseCellBtn)) //TODO: проверить если достаточно места в сумке 
        {
            // избежание добавления сумки в ту же сумку
            //if (controller.IsEmpty(controller.GetAnotherHand()))
            //{
            //    return;
            //}

            // для свапа айтема между рукой и ячейкой

            // если достаточно места в сумке для свапа
            //if (bag.CountInnerCapacity() - bagItem.GetItemSize() + handItem.GetItemSize() <= bag.capacity)
            //{
            innerItems.Add(handItem);
            innerItems.Remove(caseCellItem);
            controller.DressCell(controller.currentHand, caseCellItem);
            controller.DressCell(caseCellBtn, handItem);
            // }
        }
        else if (!controller.IsEmpty(controller.currentHand) && controller.IsEmpty(caseCellBtn))
        {
            // если достаточно места в сумке для добавления
            //if (bag.CountInnerCapacity() + handItem.GetItemSize() <= bag.capacity)
            //{
            innerItems.Add(handItem);
            controller.DressCell(caseCellBtn, handItem);
            controller.SetDefaultItem(controller.currentHand);
            //}
        }
        

    }
}
