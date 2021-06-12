using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float itemSpeed=1.5f;
    private int curX, curY;
    private int hitNum = 0;
    public GameObject freezingArea;
    public GameObject bubble;
    public GameObject bomb;

   
    void Start()
    {
        curX = (int)Mathf.Pow(-1, (int)Random.Range(1, 2));
        curY = (int)Mathf.Pow(-1, (int)Random.Range(1, 2));

    }

    void Update()
    {
        if (transform.position.x < -8.7 || transform.position.x > 8.7 && hitNum<3)
        {
            curX *= -1;
            hitNum++;
        }

        if (transform.position.y < -5.3 || transform.position.y > 5.3 && hitNum<3)
        {
            curY *= -1;
            hitNum++;
        }

        transform.Translate(new Vector3(curX, curY, transform.position.z) * itemSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int n = (int)Random.Range(0, 4);
            if (n == 1) //slow
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < enemies.Length; i++)
                    enemies[i].GetComponent<Enemy>().ToSlow();

                Debug.Log("slow");
                Destroy(this.gameObject);
            }
            else if (n == 2) //freeze
            {
                freezingArea.SetActive(true);
                Debug.Log("freeze");
                Invoke("FreezingItem", 0.3f);
            }
            else if (n == 3) //bubble
            {
                Instantiate(bubble, transform.position, transform.rotation);
                Debug.Log("bubble");
                Destroy(this.gameObject);
            }
            else //bomb
            {
                Instantiate(bomb, new Vector2(Random.Range(-8, 8), Random.Range(-4, 4)), transform.rotation);
                Debug.Log("bomb");
                Destroy(this.gameObject);
            }
           
        }
    }
    

    void freezingItem()
    {
        freezingArea.SetActive(true);
        Destroy(this.gameObject);
    }

    void ActiveBomb()
    {
        Instantiate(bomb, new Vector2(Random.Range(-8, 8), Random.Range(-4, 4)), transform.rotation);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
