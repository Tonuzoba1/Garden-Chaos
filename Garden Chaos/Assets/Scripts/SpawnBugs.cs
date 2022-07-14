using System.Collections;
using UnityEngine;

public class SpawnBugs : MonoBehaviour
{
    [SerializeField] private Transform spawner1;
    [SerializeField] private Transform spawner2;
    [SerializeField] private GameObject bug;
    [SerializeField] public bool readyToSpawn;
    [SerializeField] private float spawnTime;

    void Update()
    {
        if (readyToSpawn && PlayerStats.playerLevel > 1)
        {
            StartCoroutine(spawnTimer());
        }
    }

    void SpawnTheBugs()
    {
        int dice = Random.Range(0, 2);

        switch (dice)
        {
            case 0:
                {
                    Instantiate(bug, new Vector3(spawner1.position.x, spawner1.position.y, spawner1.position.z), Quaternion.identity);

                    break;
                }
            case 1:
                {
                    Instantiate(bug, new Vector3(spawner2.position.x, spawner2.position.y, spawner2.position.z), Quaternion.identity);

                    break;
                }
        }
    }

    IEnumerator spawnTimer()
    {
        readyToSpawn = false;

        SpawnTheBugs();

        WaitForSeconds wfs = new WaitForSeconds(spawnTime);
        yield return wfs;

        readyToSpawn = true;
    }
}
