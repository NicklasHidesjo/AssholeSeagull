using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullManager : MonoBehaviour
{
    //Food Packages
    [SerializeField] Transform breadPackage;
    [SerializeField] Transform cheesePackage;
    [SerializeField] Transform hamPackage;

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

                seagullMovement.BreadPackage = breadPackage;
                seagullMovement.HamPackage = hamPackage;
                seagullMovement.CheesePackage = cheesePackage;

/*                if (seagullMovement.randomPackage == 0)
                {
                }
                else if (seagullMovement.randomPackage == 1)
                {
                }
                else if (seagullMovement.randomPackage == 2)
                {
                }
                else
                {
                    Debug.LogError("No food was found!");
                }*/

                seagullMovement.flightEnd = endFlight;

                seagullMovement.seagullManager = this;

                currentNumberOfSeagulls++;

                seagullMovement.Init();

                yield return new WaitForSeconds(spawnIntervalls);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
