using System.Collections;
using UnityEngine;

public class GameTiming : MonoBehaviour
{
    public bool gameStart;

    [SerializeField] private float gameStartTimer;
    [SerializeField] private GameObject StartPanel;

    private void Start()
    {
        gameStart = false;
        StartCoroutine(gameTimer());
    }

    IEnumerator gameTimer()
    {
        WaitForSeconds wfs = new WaitForSeconds(gameStartTimer);

        yield return wfs;

        gameStart = true;
    }  
}
