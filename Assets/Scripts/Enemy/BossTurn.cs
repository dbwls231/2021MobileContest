using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurn : MonoBehaviour
{

    private Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToRotate()
    {
        Vector3 dir = transform.position - playerPos.position;
        float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z + 90);
    }
}
