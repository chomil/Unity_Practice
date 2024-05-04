using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;
    public GameObject retryButton;

    public Text levelText;
    public RectTransform scoreFront;

    int level = 0;
    int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Application.targetFrameRate = 60;
        Time.timeScale = 1f;
    }

    void Start()
    {
        InvokeRepeating("MakeCat", 0f, 1.5f);
    }

    void Update()
    {
        
    }

    void MakeCat()
    {
        Instantiate(normalCat);

        if(level >= 1)
        {
            if(Random.Range(0, 5) == 0)
            {
                Instantiate(normalCat);
            }
        }
        if (level >= 3)
        {
            if (Random.Range(0, 3) == 0)
            {
                Instantiate(fatCat);
            }
        }
        if (level >= 5)
        {
            if (Random.Range(0, 2) == 0)
            {
                Instantiate(pirateCat);
            }
        }
    }

    public void GameOver()
    {
        retryButton.SetActive(true);
        Time.timeScale = 0f;
    }
    public void AddScore()
    {
        score++;
        level = score / 5;
        levelText.text = level.ToString();
        scoreFront.localScale = new Vector3((score % 5 / 5f), 1f, 1f);
    }
}
