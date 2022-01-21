using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f; //먹어지는 속도
    [SerializeField] float pickUpDistance = 1.5f;//먹어지는 거리
    [SerializeField] float ttl = 10f;//time to leave

    public Item item;
    public int count = 1;

    private void Awake()
    {
        player = GameManager.instance.player.transform;
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.icon;
    }

    private void Update()
    {
        //안먹으면 아이템 사라지게
        ttl -= Time.deltaTime;
        if(ttl < 0) { Destroy(gameObject); }


        float distance = Vector3.Distance(transform.position, player.position);
        if(distance>pickUpDistance)
        {
            return;
        }

        //플레이어 위치로 이동
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if(distance<0.1f)
        {
            //************** 이 코드는 이곳보다는 특정 컨트롤러를 만들어서 이동해주어야함
            if(GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(item, count);
            }
            else
            {
                Debug.LogWarning("게임 매니져에 인벤토리 컨테이너가 없습니다.");
            }

            Destroy(gameObject);
        }
    }
}
