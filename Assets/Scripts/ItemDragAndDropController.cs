using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDragAndDropController : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] GameObject itemIcon;
    RectTransform iconTransform;
    Image itemIconImage;

    private void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = itemIcon.GetComponent<RectTransform>();
        itemIconImage = itemIcon.GetComponent<Image>();
    }

    private void Update()
    {
        if(itemIcon.activeInHierarchy == true)
        {
            //itemIcon의 위치를 마우스 위치로 지정
            iconTransform.position = Input.mousePosition;

            if(Input.GetMouseButtonDown(0))
            {
                if(EventSystem.current.IsPointerOverGameObject()==false)
                {
                    //마우스 위치를 월드 위치로!
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPosition.z = 0;

                    ItemSpawnManager.instance.SpawnItem(worldPosition, itemSlot.item, itemSlot.count);

                    itemSlot.Clear();
                    itemIcon.SetActive(false);
                }
            }
        }
    }

    //internal : 어샘블리(같은 파일) 내부에서만 접근 가능
    internal void OnClick(ItemSlot itemSlot)
    {
        //인벤토리 슬롯이 비어있다면 데이터를 슬롯에 복사하고 인벤토리 슬롯 정보 지우기
        if(this.itemSlot.item == null)
        {
            this.itemSlot.Copy(itemSlot);
            itemSlot.Clear();
        }
        else
        {
            //인벤토리 슬롯에 아이템이 있다면 슬롯과 인벤토리 슬롯 정보 바꾸기
            Item item = itemSlot.item;
            int count = itemSlot.count;

            itemSlot.Copy(this.itemSlot);
            this.itemSlot.Set(item, count);
        }
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if(itemSlot.item == null)
        {
            itemIcon.SetActive(false);
        }
        else
        {
            itemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.icon;
        }
    }
}
