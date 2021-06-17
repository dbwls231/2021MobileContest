using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleItem : MonoBehaviour
{
    private float curX, curY;
    private int hitNum = 0;
    public float bubbleSpeed = 10;
    
    void Start()
    {
        curX = (int)Mathf.Pow(-1, (int)Random.Range(1, 2));
        curY = (int)Mathf.Pow(-1, (int)Random.Range(1, 2));
    }

    void Update()
    {
        if (transform.position.x < -7.8 || transform.position.x > 7.8 && hitNum < 2)
        {
            curX *= -1;
            hitNum++;
        }

        if (transform.position.y < -4.5 || transform.position.y > 4.5 && hitNum < 2)
        {
            curY *= -1;
            hitNum++;
        }

        transform.Translate(new Vector3(curX, curY, transform.position.z) * bubbleSpeed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}




