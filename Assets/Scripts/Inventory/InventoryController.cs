using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject panel;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            //activeInHierarchy : �г��� �θ� �ִٸ� �θ��� Ȱ��ȭ ���¿� ������ ����.
            //�� �θ� ��Ȱ��ȭ�� Ȱ��ȭ ���� ����.
            panel.SetActive(!panel.activeInHierarchy);
        }
    }
}
