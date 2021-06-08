using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 15;

    private void Start()
    {
        //GetComponent<Rigidbody2D>().AddForce(transform.forward * bulletSpeed, ForceMode2D.Impulse);
    }

    private void Update()
    {
       transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
