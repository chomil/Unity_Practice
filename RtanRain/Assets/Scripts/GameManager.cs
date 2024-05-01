using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject rain;
    public GameObject endPanel;
    public Text totalScoreTxt;
    public Text totalTimeTxt;
    int totalScore = 0;
    float totalTime = 30.0f;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        InvokeRepeating("MakeRain", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(totalTime > 0f)
        {
            totalTime -= Time.deltaTime;
        }
        else
        {
            totalTime = 0;
            Time.timeScale = 0f;
            endPanel.SetActive(true);
        }
        totalTimeTxt.text = totalTime.ToString("N2");
    }

    void MakeRain()
    {
        Instantiate(rain);
    }

    public void AddScore(int score)
    {
        totalScore += score;
        totalScoreTxt.text = totalScore.ToString();
    }
}
