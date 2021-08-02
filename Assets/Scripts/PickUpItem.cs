using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f; //�Ծ����� �ӵ�
    [SerializeField] float pickUpDistance = 1.5f;//�Ծ����� �Ÿ�
    [SerializeField] float ttl = 10f;//time to leave


    private void Awake()
    {
        player = GameManager.instance.player.transform;
    }

    private void Update()
    {
        //�ȸ����� ������ �������
        ttl -= Time.deltaTime;
        if(ttl < 0) { Destroy(gameObject); }


        float distance = Vector3.Distance(transform.position, player.position);
        if(distance>pickUpDistance)
        {
            return;
        }

        //�÷��̾� ��ġ�� �̵�
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if(distance<0.1f)
        {
            Destroy(gameObject);
        }
    }
}
