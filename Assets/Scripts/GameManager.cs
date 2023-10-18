using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int levels;
    public TextMeshProUGUI levelText;
    public GameObject[] Hints;

    private bool levelCleared;
    public static bool isActive;

    public GameObject endingScreen;

    private void Start()
    {
        levels = 0;
        levelCleared = true;
        GenerateLevel();
    }

    private void Update()
    {
        if(levels <= 9)
        {
            if (levelCleared)
            {
                levels++;
                levelCleared = false;
                levelText.text = "Level " + levels.ToString();
                GenerateLevel();
            }
        }
        else
        {
            endingScreen.SetActive(true);
            Time.timeScale = 0f;
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
        Shuffle(checkNum);

        for (int i = 0; i < levels; i++)
        {
            Hints[checkNum[i]].SetActive(true);
        }
    }

    void Shuffle<T>(List<T> shuffleNum)
    {
        for(int i = 0; i < shuffleNum.Count - 1; i++)
        {
            T temp = shuffleNum[i];
            int rand = Random.Range(i, shuffleNum.Count);
            shuffleNum[i] = shuffleNum[rand];
            shuffleNum[rand] = temp;
        }      
    }
}
