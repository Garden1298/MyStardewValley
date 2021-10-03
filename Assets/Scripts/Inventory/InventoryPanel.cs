using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] ItemContainer inventory;
    [SerializeField] List<InventoryButton> buttons;

    private void Start()
    {
        SetIndex();
        Show();
    }

    //활성화될때마다 호출
    private void OnEnable()
    {
        Show();
    }

    private void SetIndex()
    {
        for(int i = 0; i<inventory.slots.Count;i++)
        {
            buttons[i].SetIndex(i);
        }
    }

    public void Show()
    {
        for(int i = 0;i<inventory.slots.Count;i++)
        {
            if(inventory.slots[i].item == null)
            {
                buttons[i].Clean();
            }
            else
            {
                buttons[i].Set(inventory.slots[i]);
            }
        }
    }
}
