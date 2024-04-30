using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class NewBehaviourScript : MonoBehaviour
{
    Vector3 Speed = new(3.5f, 0, 0);
    float direction = 1f;
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        renderer= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            renderer.flipX = !renderer.flipX;
            direction *= -1;
        }

        if (transform.position.x > 2.6f)
        {
            renderer.flipX = true;
            direction = -1f;
        }
        else if (transform.position.x < -2.6f)
        {
            renderer.flipX = false;
            direction = 1f;
        }
        transform.position += direction * Time.deltaTime * Speed;
    }
}
