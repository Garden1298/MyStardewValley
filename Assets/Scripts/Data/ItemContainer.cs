using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public Item item;
    public int count;

    public void Copy(ItemSlot slot)
    {
        item = slot.item;
        count = slot.count;
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }

    public void Clear()
    {
        item = null;
        count = 0;
    }
}

[CreateAssetMenu(menuName ="Data/Item Container")]
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots;

    public void Add(Item item, int count = 1)
    {
        if(item.stackable == true)
        {
            //람다식 사용, 슬롯들 중에 아이템이 이미 존재하는지 찾기
            //https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=blessthy&logNo=221341891472
            ItemSlot itemSlot = slots.Find(x => x.item == item);
            if(itemSlot != null)
            {
                itemSlot.count += count;
            }
            else
            {
                //빈 슬롯 찾기
                itemSlot = slots.Find(x => x.item == null);
                //빈 슬롯이 없을때
                if(itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.count = count;
                }
            }
        }
        else
        {
            //stackable이 아닌 아이템을 아이템 컨테이너에 추가
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            //빈 슬롯이 없을때
            if (itemSlot != null)
            {
                itemSlot.item = item;
            }
        }
    }

}
