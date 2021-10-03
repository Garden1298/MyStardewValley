using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f; //�Ծ����� �ӵ�
    [SerializeField] float pickUpDistance = 1.5f;//�Ծ����� �Ÿ�
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
            //************** �� �ڵ�� �̰����ٴ� Ư�� ��Ʈ�ѷ��� ���� �̵����־����
            if(GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(item, count);
            }
            else
            {
                Debug.LogWarning("���� �Ŵ����� �κ��丮 �����̳ʰ� �����ϴ�.");
            }

            Destroy(gameObject);
        }
    }
}
