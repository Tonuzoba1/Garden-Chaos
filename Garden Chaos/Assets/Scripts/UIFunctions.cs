using UnityEngine;
using TMPro;

public class UIFunctions : MonoBehaviour
{
    [SerializeField] private GameObject lvlText;
    [SerializeField] private GameObject scoreText;

    private void Start()
    {
        if(lvlText != null)
        {
        lvlText.GetComponent<TextMeshProUGUI>().text = PlayerStats.playerLevel.ToString();
        scoreText.GetComponent<TextMeshProUGUI>().text = PlayerStats.playerPoints.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lvlText != null)
        {
            lvlText.GetComponent<TextMeshProUGUI>().text = PlayerStats.playerLevel.ToString();
            scoreText.GetComponent<TextMeshProUGUI>().text = PlayerStats.playerPoints.ToString();
        }
    }
}
