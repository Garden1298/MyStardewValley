using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f; //먹어지는 속도
    [SerializeField] float pickUpDistance = 1.5f;//먹어지는 거리
    [SerializeField] float ttl = 10f;//time to leave


    private void Awake()
    {
        player = GameManager.instance.player.transform;
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
            Destroy(gameObject);
        }
    }
}
