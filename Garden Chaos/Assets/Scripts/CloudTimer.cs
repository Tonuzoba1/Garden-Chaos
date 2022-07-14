using System.Collections;
using UnityEngine;

public class CloudTimer : MonoBehaviour
{
    public bool startHail;
    [SerializeField] private float startHailCountdown;

    void Start()
    {
        startHail = false;

        StartCoroutine(startHaliTimer());
    }

    IEnumerator startHaliTimer()
    {
        WaitForSeconds wfs = new WaitForSeconds(startHailCountdown);

        yield return wfs;
        startHail = true;
    }
}
