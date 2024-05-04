using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject food;

    void Start()
    {
        InvokeRepeating("MakeFood", 0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = Mathf.Clamp(mousePos.x, -9f, 9f);
        transform.position = new Vector3(x, transform.position.y);
    }

    void MakeFood()
    {
        Instantiate(food, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
    }
}
