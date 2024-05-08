using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Card firstCard;
    public Card secondCard;

    public Text timeText;
    public GameObject endText;

    public int cardCnt = 0;

    float curTime = 0f;

    private void Awake()
    {
        if(instance == null)
        {
             instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 1f;
    }


    void Update()
    {
        curTime += Time.deltaTime;
        timeText.text = curTime.ToString("N2");
    }

    public void Matched()
    {
        if(firstCard == null || secondCard==null) 
        { 
            return;
        }

        if(firstCard.index == secondCard.index) 
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCnt -= 2;
            if(cardCnt <= 1)
            {
                Time.timeScale = 0f;
                endText.SetActive(true);
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }

}
