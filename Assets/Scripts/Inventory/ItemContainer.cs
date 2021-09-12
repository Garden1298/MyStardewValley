using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public Item item;
    public int count;
}

[CreateAssetMenu(menuName ="Data/Item Container")]
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots;

    public void Add(Item item, int count = 1)
    {
        if(item.stackable == true)
        {
            //���ٽ� ���, ���Ե� �߿� �������� �̹� �����ϴ��� ã��
            //https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=blessthy&logNo=221341891472
            ItemSlot itemSlot = slots.Find(x => x.item == item);
            if(itemSlot != null)
            {
                itemSlot.count += count;
            }
            else
            {
                //�� ���� ã��
                itemSlot = slots.Find(x => x.item == null);
                //�� ������ ������
                if(itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.count = count;
                }
            }
        }
        else
        {
            //stackable�� �ƴ� �������� ������ �����̳ʿ� �߰�
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            //�� ������ ������
            if (itemSlot != null)
            {
                itemSlot.item = item;
            }
        }
    }

}