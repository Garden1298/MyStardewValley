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
            //itemIcon�� ��ġ�� ���콺 ��ġ�� ����
            iconTransform.position = Input.mousePosition;

            if(Input.GetMouseButtonDown(0))
            {
                if(EventSystem.current.IsPointerOverGameObject()==false)
                {
                    //���콺 ��ġ�� ���� ��ġ��!
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPosition.z = 0;

                    ItemSpawnManager.instance.SpawnItem(worldPosition, itemSlot.item, itemSlot.count);

                    itemSlot.Clear();
                    itemIcon.SetActive(false);
                }
            }
        }
    }

    //internal : �����(���� ����) ���ο����� ���� ����
    internal void OnClick(ItemSlot itemSlot)
    {
        //�κ��丮 ������ ����ִٸ� �����͸� ���Կ� �����ϰ� �κ��丮 ���� ���� �����
        if(this.itemSlot.item == null)
        {
            this.itemSlot.Copy(itemSlot);
            itemSlot.Clear();
        }
        else
        {
            //�κ��丮 ���Կ� �������� �ִٸ� ���԰� �κ��丮 ���� ���� �ٲٱ�
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
