using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullManager : MonoBehaviour
{
    [SerializeField] Transform sandwich;
    [SerializeField] Transform endFlight;
    [SerializeField] Transform seagullSpawnPoints;
    [SerializeField] SeagullMovement seagullPrefab;

    string seagullClone = "Seagull_Prefab(Clone)";

    int currentNumberOfSeagulls = 0;
    int maxNumberOfSeagulls = 1;

    [SerializeField] float spawnIntervalls = 5f;

    private void OnEnable()
    {
        StartCoroutine("SpawnSeagull");
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Despawn(GameObject seagull)
    {
        //Skicka till despawnlistan
        Destroy(seagull);
        currentNumberOfSeagulls--;
    }

    IEnumerator SpawnSeagull()
    {
        while(true)
        {
            if(currentNumberOfSeagulls < maxNumberOfSeagulls)
            {
                SeagullMovement seagullMovement = Instantiate(seagullPrefab, seagullSpawnPoints.position, Quaternion.identity);
                seagullMovement.sandwich = sandwich;
                seagullMovement.flightEnd = endFlight;

                seagullMovement.seagullManager = this;

                currentNumberOfSeagulls++;

                yield return new WaitForSeconds(spawnIntervalls);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
