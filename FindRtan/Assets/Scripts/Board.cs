using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject card;
    int countX = 4;
    int countY = 4;
    float cardDist = 1.4f;
    GameObject[] cards;

    void Start()
    {
        for(int y = 0; y < countY; y++) 
        {
            for (int x = 0; x < countX; x++)
            {
                Vector3 spawnPos = new Vector3(x * cardDist, y * cardDist);
                spawnPos.x -= countX * cardDist * 0.5f - cardDist * 0.5f;
                spawnPos.y -= countY * cardDist * 0.5f - cardDist * 0.5f;
                Instantiate(card, this.transform.position + spawnPos, Quaternion.identity);
            }
        }
    }

    void Update()
    {
        
    }
}
