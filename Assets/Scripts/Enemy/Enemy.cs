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
    public SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    public GameObject item;
    public float ChaseTime = 999;
    private float t = 0;
    private float t2 = 0;
    private int MonsterAdditionScore = 30;
    private int spriteNum;
    public bool isFreezing = false;
    private float freezingTimer = 0;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        ScoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
        rigid = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        int enemyNum = Random.Range(0, 7);
        if (enemyNum < 3)
        {
            speed = 1.5f;
            health = 2;
            spriteRenderer.sprite = sprites[0];
            MonsterAdditionScore = 30;
            spriteNum = 0;
        }
        else if (enemyNum < 5)
        {
            ChaseTime = 3;
            speed = 4;
            health = 1;
            spriteRenderer.sprite = sprites[1];
            spriteNum = 1;
            MonsterAdditionScore = 40;
        }
        else
        {
            speed = 0.7f;
            health = 6;
            spriteRenderer.sprite = sprites[2];
            spriteNum = 2;
            spriteRenderer.flipY = true;
            MonsterAdditionScore = 50;
            transform.localScale = new Vector2(1.5f, 1.5f);
        }
        curSpeed = speed;
    }

    private void Update()
    {
        if (!isFreezing)
        {
            t += Time.deltaTime;
            t2 += Time.deltaTime;

            if (t < ChaseTime)
            {
                Vector3 dir = transform.position - playerPos.position;
                float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, z - 90);
                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, curSpeed * Time.deltaTime);
            }
            else
                transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * curSpeed);

            if (t2 > .5f && spriteNum != 0)
            {
                t2 = 0;
                Vector2 scale = gameObject.transform.localScale;
                gameObject.transform.localScale = new Vector2(-scale.x, scale.y);
            }
        }
        else
        {
            freezingTimer -= Time.deltaTime;
            if (freezingTimer <= 0)
            {
                isFreezing = false;
                ToOriginSpeed();
                ReturnSprite();
            }
        }
    }

    private void OnHit(int n)
    {
        health -= n;

        if (health <= 0 )
        {
            if(Random.Range(0,10)>0)
            Instantiate(item, transform.position, Quaternion.identity);
            Destroy(gameObject);
            ScoreManager.curScore += MonsterAdditionScore;
        }
    }

    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[spriteNum];
        isFreezing = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            OnHit(1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "FreezingArea")
        {
            curSpeed = 0;
            isFreezing = true;
            freezingTimer = 5;
            spriteRenderer.sprite = sprites[spriteNum + 3];
        }
        if (collision.gameObject.tag == "Bubble")
        {
            OnHit(10);
            Destroy(gameObject);
            ScoreManager.curScore += MonsterAdditionScore;
        }
        if (collision.gameObject.tag == "Bomb")
        {
            OnHit(10);
            Destroy(gameObject);
            ScoreManager.curScore += MonsterAdditionScore;
        }
    }

    public void ToSlow()
    {
        curSpeed *= 0.35f;
        Invoke("ToOriginSpeed", 5f);
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