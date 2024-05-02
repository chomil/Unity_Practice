using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    void Start()
    {
        Vector2 pos = new Vector2(Random.Range(-3f, 3f), Random.Range(5f, 7f));
        transform.position = pos;
        float size = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector2(size, size);
    }

    void Update()
    {
        if(transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }
}
