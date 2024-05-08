using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timeText;
    float curTime = 0f;


    void Start()
    {
        
    }


    void Update()
    {
        curTime += Time.deltaTime;
        timeText.text = curTime.ToString("N2");
    }
}
