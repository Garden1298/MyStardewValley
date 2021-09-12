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
            //activeInHierarchy : 패널의 부모가 있다면 부모의 활성화 상태에 영향을 받음.
            //즉 부모 비활성화시 활성화 되지 않음.
            panel.SetActive(!panel.activeInHierarchy);
        }
    }
}
