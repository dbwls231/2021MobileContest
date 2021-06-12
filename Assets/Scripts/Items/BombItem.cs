using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItem : MonoBehaviour
{
    SpriteRenderer renderer;

    private void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine("FadeIn");
        Color c = renderer.material.color;
        c.a = 0;
    }

    IEnumerator FadeOut()
    {

        for (int i = 10; i >= 0; i--)
        {
            float f = i / 10.0f;
            Color c = renderer.material.color;
            c.a = f;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }


    IEnumerator FadeIn()
    {
        for(int i = 0; i < 10; i++)
        {
            float f = i / 10.0f;
            Color c = renderer.material.color;
            c.a = f;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
        gameObject.tag = "Bomb";

        StartCoroutine("FadeOut");
    }

}
