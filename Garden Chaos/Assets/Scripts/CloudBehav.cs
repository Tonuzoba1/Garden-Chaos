using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehav : MonoBehaviour
{
    [SerializeField] private GameObject ice;
    [SerializeField] private GameObject raindrop;
    public List<GameObject> drops = new List<GameObject>();
    [SerializeField] private Transform cloudTransform;
    [SerializeField] private bool newRaindropOnTheWay;
    [SerializeField] private bool newIceOnTheWay;
    [SerializeField] private CloudTimer cloudTimer;
    [SerializeField] private float rainTimer;
    [SerializeField] private float hailTimer;
    [SerializeField] PlayerBehav playerBehav;

    private void Awake()
    {
        cloudTransform = transform;
        newRaindropOnTheWay = false;
        newIceOnTheWay = false;

        cloudTimer = GetComponent<CloudTimer>();

        Physics2D.IgnoreLayerCollision(9, 10);
    }

    void Update()
    {
        if (playerBehav.resetLevel)
        {

        rainTimer = rainTimer - (playerBehav.levelCounter * 0.01f);
        hailTimer = hailTimer - (playerBehav.levelCounter * 0.03f);

        }

        if(PlayerStats.playerLevel > 0)
        {
            transform.position = new Vector3(transform.position.x, 15, transform.position.z);
        }


        if (!newRaindropOnTheWay)
        {
            StartCoroutine(raining());
        }

        if (cloudTimer.startHail && !newIceOnTheWay)
        {
            StartCoroutine(hail());
        }
    }

    IEnumerator hail()
    {
        newIceOnTheWay = true;

        WaitForSeconds wfs = new WaitForSeconds(hailTimer);

        SpawnNewIcedrop();

        yield return wfs;

        newIceOnTheWay = false;
    }

    IEnumerator raining()
    {
        newRaindropOnTheWay = true;

        WaitForSeconds wfs = new WaitForSeconds(rainTimer);

        SpawnNewRaindrop();

        yield return wfs;

        newRaindropOnTheWay = false;
    }

    void SpawnNewRaindrop()
    {
        float raining = Random.Range(-34f, 34f);

        drops.Add(Instantiate(raindrop,new Vector2(cloudTransform.position.x + raining, cloudTransform.position.y), Quaternion.identity));
    }

    void SpawnNewIcedrop()
    {
        float hail = Random.Range(-34f, 34f);

       drops.Add(Instantiate(ice, new Vector2(cloudTransform.position.x + hail, cloudTransform.position.y), Quaternion.identity));
    }
}
