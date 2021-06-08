using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowItem : MonoBehaviour
{
    private Vector2 targetPos;
    private float itemSpeed=1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //targetPos = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        //Vector2 dir = new Vector2(targetPos.x - transform.position.y, targetPos.y - transform.position.y);
        //Quaternion rot = Quaternion.LookRotation(dir.normalized);

        //transform.rotation = rot;

        targetPos = new Vector2(transform.position.y, transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, itemSpeed * Time.deltaTime);
        //transform.position += Vector3.forward * itemSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for(int i=0; i< enemies.Length;i++)
                enemies[i].GetComponent<Enemy>().ToSlow();

            Destroy(this.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
