using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : ItemPanel
{
    public override void OnClick(int _id)
    {
        GameManager.instance.dragAndDropController.OnClick(inventory.slots[_id]);
        Show();
    }
}
