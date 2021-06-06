using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed;
    private int health;
    public Sprite[] sprites;
    private Transform playerPos;
    SpriteRenderer SpriteRenderer;
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        int enemyNum = Random.Range(0, 7);
        if (enemyNum < 5)
        {
            speed = 1.5f;
            health = 2;
            //���߿� ��������Ʈ �ҷ�����
        }
        else if (enemyNum == 5)
        {
            speed = 3;
            health = 1;
        }
        else
        {
            speed = 0.7f;
            health = 6;
        }
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    private void OnHit()
    {
        health--;
        //SpriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite", 0.1f);

        if (health == 0)
            Destroy(gameObject);
    }

    void ReturnSprite()
    {
        SpriteRenderer.sprite = sprites[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            OnHit();
            Destroy(collision.gameObject);
        }
    }
}
