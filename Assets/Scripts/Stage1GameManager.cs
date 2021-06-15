using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1GameManager : MonoBehaviour
{
    public int bossPhase = 1;
    public int bossHealth;
    public float bossScale;
    public GameObject stage1Boss;
    public float bossBulletScale = 1;

    private void Awake()
    {
        bossHealth = 10;
        bossScale = 3;
    }


    public void CreateBoss(int n, Transform trans)
    {
        if (n == 1)
        {
            bossPhase = 2;
            bossHealth = 7;
            bossScale = 2.5f;
            bossBulletScale = 0.8f;
            Instantiate(stage1Boss, trans.position, trans.rotation);
            Instantiate(stage1Boss, trans.position+new Vector3(3,0,trans.position.z), trans.rotation);
        }
        else if (n == 2)
        {
            bossPhase = 3;
            bossHealth = 5;
            bossScale = 2;
            bossBulletScale = 0.65f;
            Instantiate(stage1Boss, trans.position, trans.rotation);
            Instantiate(stage1Boss, trans.position + new Vector3(1, 0, trans.position.z), trans.rotation);
        }
        else if (n == 3)
        {
            bossPhase = 4;
            bossHealth = 3;
            bossScale = 1.5f;
            bossBulletScale = 0.5f;
            Instantiate(stage1Boss, trans.position, trans.rotation);
            Instantiate(stage1Boss, trans.position + new Vector3(1, 0, trans.position.z), trans.rotation);
        }
        else
        {
            bossPhase = 5;
            bossHealth = 2;
            bossScale = 1;
            bossBulletScale = 0.35f;

        }
    }
    public int GetHealth()
    {
        return bossHealth;
    }
    public float GetScale()
    {
        return bossScale;
    }
    public int GetPhase()
    {
        return bossPhase;
    }
    
    public float GetBulletScale()
    {
        return bossBulletScale;
    }
}
