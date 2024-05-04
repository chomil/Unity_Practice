using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public int type = 0;
    public GameObject hungryCat;
    public GameObject fullCat;

    float speed = 2f;
    float maxExp = 5f;
    float curExp = 0f;

    public RectTransform front;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-9f, 9f), 30f);

        if(type == 0)
        {
            speed = 2f;
            maxExp = 5f;
        }
        else if (type == 1)
        {
            speed = 1f;
            maxExp = 10f;
        }
        else if (type == 2)
        {
            speed = 5f;
            maxExp = 3f;
        }
    }

    void Update()
    {
        if (curExp < maxExp)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            if(transform.position.y < -16f)
            {
                GameManager.Instance.GameOver();
            }
        }
        else
        {
            if(transform.position.x > 0)
            {
                transform.position += Vector3.right * speed * 2f * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.left * speed * 2f * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Food"))
        {
            if (curExp < maxExp)
            {
                curExp += 1f;
                curExp = Mathf.Min(curExp, maxExp);
                front.localScale = new Vector3(curExp / maxExp, 1, 1);
                Destroy(collision.gameObject);

                if(curExp == maxExp)
                {
                    GameManager.Instance.AddScore();
                    hungryCat.SetActive(false);
                    fullCat.SetActive(true);
                    Destroy(gameObject, 5f);
                }
            }
        }
    }
}
