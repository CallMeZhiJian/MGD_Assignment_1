using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int levels;
    public GameObject[] Hints;

    private bool levelCleared;
    public static bool isActive;

    private void Start()
    {
        levels = 0;
        levelCleared = false;
        GenerateLevel();
    }

    private void Update()
    {
        if(levels < 9)
        {
            if (levelCleared)
            {
                levels++;
                levelCleared = false;
                GenerateLevel();
            }
        }
        else
        {
            return;
        }
        

        for (int i = 0; i < Hints.Length; i++)
        {
            if(Hints[i].activeInHierarchy)
            {
                isActive = true;
            }
        }

        if (!isActive)
        {
            levelCleared = true;
        }
    }

    public void GenerateLevel()
    {
        List<int> checkNum = new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        int index = 0;

        if(levels < 9)
        {
            while (index < levels)
            {
                for (int i = 0; i < levels; i++)
                {
                    if (checkNum[i] == Random.Range(0, 8))
                    {
                        Hints[checkNum[i]].SetActive(true);
                        index++;
                        checkNum[i] = 9;
                    }
                }
            }
        }
        else
        {
            for(int i = 0; i < Hints.Length; i++)
            {
                Hints[i].SetActive(true);
            }
        }
        

        //for (int i = 0; i < levels; i++)
        //{
        //    if(checkNum[i] == Random.Range(0, 8))
        //    {
        //        Hints[checkNum[i]].SetActive(true);
        //    }
        //}

    }
}
