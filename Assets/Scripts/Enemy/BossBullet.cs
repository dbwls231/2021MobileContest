using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public GameObject gameMg;

    private void Start()
    {
        gameMg = GameObject.FindGameObjectWithTag("GameManager");
        float scale = gameMg.GetComponent<Stage1GameManager>().GetBulletScale();
        transform.localScale = new Vector3(scale, scale, 1);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, 1000 * Time.deltaTime);

    }
}
