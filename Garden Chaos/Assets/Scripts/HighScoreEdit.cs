using System;
using UnityEngine;
using TMPro;

public class HighScoreEdit : MonoBehaviour
{
    public TextMeshProUGUI[] records = new TextMeshProUGUI[4];

    void Start()
    {
        if (PlayerStats.scores.Length >= 1)
        {
            for (int i = 0; i < PlayerStats.scores.Length; i++)
            {
                records[i].text = PlayerStats.scores[i].ToString();

            }
        }
    }

    void Update()
    {
        if(PlayerStats.scores.Length >= 1)
        {
        UpdateBoard();

        }
    }

   public void UpdateBoard()
    {

        Array.Sort(PlayerStats.scores);
        System.Array.Reverse(PlayerStats.scores);

        for (int i = 0; i < PlayerStats.scores.Length; i++)
        {
            records[i].text = PlayerStats.scores[i].ToString();

        }
    }
}
