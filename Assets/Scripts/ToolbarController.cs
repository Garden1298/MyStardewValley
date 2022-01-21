using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarController : MonoBehaviour
{
    [SerializeField] int toolbarSize = 12;//���κ��丮�� ��
    int selectedTool;//���õ� ����

    public Action<int> onChange;

    private void Update()
    {
        float delta = Input.mouseScrollDelta.y;//���콺 �� �̺�Ʈ(�� = 1, �Ʒ� = -1)
        if(delta != 0)//0~11(toolbarSize-1)���̸� ���õǰ�
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
