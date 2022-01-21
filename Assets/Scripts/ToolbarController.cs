using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarController : MonoBehaviour
{
    [SerializeField] int toolbarSize = 12;//퀵인벤토리의 수
    int selectedTool;//선택된 도구

    public Action<int> onChange;

    private void Update()
    {
        float delta = Input.mouseScrollDelta.y;//마우스 휠 이벤트(위 = 1, 아래 = -1)
        if(delta != 0)//0~11(toolbarSize-1)사이만 선택되게
        {
            if(delta>0)
            {
                selectedTool += 1;
                selectedTool = (selectedTool >= toolbarSize ? 0 : selectedTool);
            }
            else
            {
                selectedTool -= 1;
                selectedTool = (selectedTool <= 0 ? toolbarSize - 1 : selectedTool);
            }
            onChange?.Invoke(selectedTool);
        }
    }

    internal void Set(int id)
    {
        selectedTool = id;
    }
}
