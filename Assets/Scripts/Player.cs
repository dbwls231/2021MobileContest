using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField]
    private Joystick joystick;
    private float moveSpeed = 10;
    float bulletCoolTime = 0.5f;
    private Vector3 lastDirection = Vector3.up;

    public GameObject bullet;

    float timer = 0;
    

    private void Start()
    {
        
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
        float x = joystick.Horizontal();
        float y = joystick.Vertical();

        if (x != 0 || y != 0)
        {
            transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;
            //ȸ��
            float z = Mathf.Atan2(y,x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, z-90);
        }


        //ȭ�� ������ �� ������
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;

    }


    void Fire()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("EndingScene");
        }
    }
}
