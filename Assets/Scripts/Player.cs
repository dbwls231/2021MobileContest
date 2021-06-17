using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField]
    private Joystick joystick;
    private float moveSpeed = 6;
    float bulletCoolTime = 0.2f;
    private Vector3 lastDirection = Vector3.up;
    private Ending ending;

    public GameObject bullet;

    float timer = 0;

    private void Awake()
    {
        ending = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Ending>();
    }

    void Update()
    {
        Move();
        timer += Time.deltaTime;
        
        if (timer > bulletCoolTime)
        {
            Fire();
            timer = 0;
        }
    }

    private void Move()
    {
        float x = joystick.joyVec.x;
        float y = joystick.joyVec.y;

        if (x != 0 || y != 0)
        {
            transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;
            //회전
            float z = Mathf.Atan2(y,x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, z-90);
        }


        //화면 밖으로 못 나가게
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.position += new Vector3(h, v, 0) * moveSpeed * Time.deltaTime;

    }


    void Fire()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !collision.gameObject.GetComponent<Enemy>().isFreezing)
            ending.EndGame();
        else if (collision.gameObject.tag == "Boss")
            ending.EndGame();
    }
}
