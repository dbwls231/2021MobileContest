using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ScoreManager ScoreManager;
    private float speed;
    private float curSpeed;
    private int health;
    public Sprite[] sprites;
    private Transform playerPos;
    SpriteRenderer SpriteRenderer;
    Rigidbody2D rigid;
    public GameObject item;
    public float ChaseTime = 999;
    private float t = 0;
    private int MonsterAdditionScore = 30;

    private void Awake()
    {
        ScoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
        rigid = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        int enemyNum = Random.Range(0, 7);
        if (enemyNum < 5)
        {
            speed = 1.5f;
            health = 2;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (enemyNum == 5)
        {
            ChaseTime = 3;
            speed = 3;
            health = 1;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else
        {
            speed = 0.7f;
            health = 6;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        curSpeed = speed;
    }

    private void Update()
    {
        t += Time.deltaTime;

        if (t < ChaseTime)
        {
            Vector3 dir = transform.position - playerPos.position;
            float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, z - 90);
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, curSpeed * Time.deltaTime);
        }
        else
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * curSpeed);
    }

    private void OnHit()
    {
        health--;
        //SpriteRenderer.sprite = sprites[1];
        //Invoke("ReturnSprite", 0.1f);

        if (health == 0)
        {
            //if(Random.Range(0,10)>7)
                Instantiate(item, transform.position, transform.rotation);
                Destroy(gameObject);
                ScoreManager.curScore += MonsterAdditionScore;
        }
    }

    void ReturnSprite()
    {
        //SpriteRenderer.sprite = sprites[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            OnHit();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "FreezingArea")
        {
            curSpeed = 0;
            Invoke("ToOriginSpeed", 5f);
        }
        if(collision.gameObject.tag == "Bubble")
        {
            Destroy(gameObject);
            ScoreManager.curScore += MonsterAdditionScore;
        }
        if(collision.gameObject.tag == "Bomb")
        {
            //health=0;
            //if (health == 0)
                Destroy(gameObject);
                ScoreManager.curScore += MonsterAdditionScore;
        }
    }

    public void ToSlow()
    {
        curSpeed *= 0.35f;
        Invoke("ToOriginSpeed", 3f);

    }

    private void ToOriginSpeed()
    {
        curSpeed = speed;
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}