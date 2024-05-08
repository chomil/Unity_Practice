using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject card;
    int countX = 4;
    int countY = 4;
    float cardDist = 1.4f;
    List<int> indexList = new List<int>();

    void Start()
    {
        indexList.Clear();
        //index initialize
        for (int y = 0; y < countY; y++)
        {
            for (int x = 0; x < countX; x++)
            {
                indexList.Add((countX * y + x) / 2);
            }
        }
        //index shuffle
        for (int i = 0; i < indexList.Count; i++)
        {
            int randomIndex = Random.Range(0, indexList.Count - 1);

            int temp = indexList[i];
            indexList[i] = indexList[randomIndex];
            indexList[randomIndex] = temp;
        }

        //card spawn
        for (int y = 0; y < countY; y++) 
        {
            for (int x = 0; x < countX; x++)
            {
                Vector3 spawnPos = new Vector3(x * cardDist, y * cardDist);
                spawnPos.x -= countX * cardDist * 0.5f - cardDist * 0.5f;
                spawnPos.y -= countY * cardDist * 0.5f - cardDist * 0.5f;
                GameObject instCard = Instantiate(card, this.transform.position + spawnPos, Quaternion.identity);

                instCard.GetComponent<Card>().Setting(indexList[countX * y + x]);
            }
        }


        GameManager.instance.cardCnt = indexList.Count;
    }

    void Update()
    {
        
    }
}
