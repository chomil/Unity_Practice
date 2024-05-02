using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject square;
    public GameObject endPanel;
    public Text timeText;


    public Text curScore;
    public Text bestScore;

    public Animator animator;

    float curTime = 0f;
    float bestTime = 0f;

    bool isPlay = true;

    string scoreKey = "bestTime";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 1f;
        isPlay = true;

        InvokeRepeating("MakeSquare", 0f, 0.5f);
    }

    void Update()
    {
        if (isPlay)
        {
            curTime += Time.deltaTime;
            timeText.text = curTime.ToString("N2");

        }
    }

    void MakeSquare()
    {
        Instantiate(square);
    }

    public void GameOver()
    {
        isPlay = false;
        animator.SetBool("isPop", true);
        Invoke("TimeStop", 0.5f);

        curScore.text = curTime.ToString("N2");

        if(PlayerPrefs.HasKey(scoreKey))
        {
            bestTime = PlayerPrefs.GetFloat(scoreKey);
        }
        else
        {
            bestTime = 0f;
        }

        if(curTime > bestTime) 
        {
            bestTime = curTime;
            PlayerPrefs.SetFloat(scoreKey, bestTime);
        }
        bestScore.text = bestTime.ToString("N2");

        endPanel.SetActive(true);
    }


    void TimeStop()
    {
        Time.timeScale = 0f;
    }
}
