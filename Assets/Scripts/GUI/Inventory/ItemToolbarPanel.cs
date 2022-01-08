using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToolbarPanel : ItemPanel
{
    [SerializeField] ToolbarController toolbarController;
    int currentSelectedTool;

    private void Start()
    {
        Init();
        toolbarController.onChange += Highlight;
        Highlight(0);//ó�� ���۽� 0�� ������ ���� ����
    }

    public override void OnClick(int _id)
    {
        toolbarController.Set(_id);
        Highlight(_id);
    }

    public void Highlight(int _id)
    {
        buttons[currentSelectedTool].Highlight(false);
        currentSelectedTool = _id;
        buttons[currentSelectedTool].Highlight(true);
    }
}
