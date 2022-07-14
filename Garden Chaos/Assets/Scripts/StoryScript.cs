using System.Collections;
using UnityEngine;

public class StoryScript : MonoBehaviour
{
    [SerializeField] private GameObject[] storyPanels;
    [SerializeField] private float storyPanelTimer;
    [SerializeField] private bool nextStepReady;
    [SerializeField] private GameObject undergroundPanel;
    [SerializeField] private GameObject bugPanel;

    void Start()
    {
        PlayerStats.counter = 0;

        if (PlayerStats.notes[0] == false)
        {
            
        StartCoroutine(storyTimer());

        }
    }

    void Update()
    {
        if(nextStepReady && PlayerStats.playerLevel == 1 && PlayerStats.sinkhole == false)
        {
            StartCoroutine(storyTimer());
            
        }
        if (nextStepReady && PlayerStats.playerLevel > 1 && PlayerStats.bugs == false)
        {
            StartCoroutine(storyTimer());
        }
        if (nextStepReady && PlayerStats.counter < 3 )
        {
            StartCoroutine(storyTimer());

        }

        if (Input.GetButtonDown("Jump"))
        {
            if(PlayerStats.counter < 3)
            {
                Time.timeScale = 1;
                storyPanels[PlayerStats.counter].SetActive(false);

            } else if(undergroundPanel.activeSelf == true)
            {
                Time.timeScale = 1;
                undergroundPanel.SetActive(false);
            } else if(bugPanel.activeSelf == true)
            {
                Time.timeScale = 1;
                bugPanel.SetActive(false);
            }

        }
    }

    IEnumerator storyTimer()
    {
        Debug.Log(PlayerStats.counter);

        if (PlayerStats.counter < 3 && PlayerStats.notes[PlayerStats.counter] == true)
        {
            PlayerStats.counter++;
            nextStepReady = false;
            WaitForSeconds wfs = new WaitForSeconds(storyPanelTimer);

            yield return wfs;

            nextStepReady = true;
            

        } else if(PlayerStats.counter < 3 && PlayerStats.notes[PlayerStats.counter] == false)
        {
            nextStepReady = false;
            WaitForSeconds wfs = new WaitForSeconds(storyPanelTimer);
            ContinueGame();

            yield return wfs;

            PlayerStats.notes[PlayerStats.counter] = true;
            PlayerStats.counter++;
            nextStepReady = true;
        } 
        if(PlayerStats.playerLevel == 1 && PlayerStats.sinkhole == false)
        {
            nextStepReady = false;
            WaitForSeconds wfs = new WaitForSeconds(1f);

            yield return wfs;
            Time.timeScale = 0;
            undergroundPanel.SetActive(true);

            PlayerStats.sinkhole = true;
            nextStepReady = true;
            PlayerStats.sinkhole = true;  
        }
        if(PlayerStats.playerLevel > 1 && PlayerStats.bugs == false)
        {
            nextStepReady = false;
            WaitForSeconds wfs = new WaitForSeconds(1f);

            yield return wfs;
            Time.timeScale = 0;
            bugPanel.SetActive(true);
            PlayerStats.bugs = true;
        }
    }
    
    void ContinueGame()
    {
        Time.timeScale = 0;
        storyPanels[PlayerStats.counter].SetActive(true);
    }
}
