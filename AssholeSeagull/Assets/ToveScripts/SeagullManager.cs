using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullManager : MonoBehaviour
{
    [SerializeField] Transform sandwich;
    public Transform seagullSpawnPoints;
    public SeagullMovement seagullPrefab;

    string seagullClone = "Seagull_Prefab(Clone)";

    int currentNumberOfSeagulls = 0;
    int maxNumberOfSeagulls = 1;

    float spawnIntervalls = 5f;

    float despawnTimer;
    float startTimer;

    bool spawningSeagull = false;
    bool firstSeagullSpawned = false;

    private void Update()
    {
        startTimer += Time.deltaTime;

        if(startTimer > 0f && firstSeagullSpawned == false)
        {
            firstSeagullSpawned = true;
            StartCoroutine("SpawnSeagull");
        }

        if(currentNumberOfSeagulls == maxNumberOfSeagulls)
        {
            despawnTimer += Time.deltaTime;

            if(despawnTimer > 20f)
            {
                GameObject clonedSegaull = GameObject.Find(seagullClone);
                Destroy(clonedSegaull);
                currentNumberOfSeagulls--;
                despawnTimer = 0f;
            }
        }
    }

    IEnumerator SpawnSeagull()
    {
        if(currentNumberOfSeagulls < maxNumberOfSeagulls)
        {
            WaitForSeconds wait = new WaitForSeconds(spawnIntervalls);

            //    int seagullIndex = seagullPrefab.Length;
            SeagullMovement seagullMovement = Instantiate(seagullPrefab, seagullSpawnPoints.position, Quaternion.identity);
            seagullMovement.sandwich = sandwich;

            currentNumberOfSeagulls++;

            yield return wait;
        }
    }
}
