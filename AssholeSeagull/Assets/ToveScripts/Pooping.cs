using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooping : MonoBehaviour
{
    GameObject poopPrefab;
    Transform spawnPosition;

    string poopClone = "PoopPrefab(Clone)";

    float despawnTimer;

    public void Poop()
    {
        GameObject spawnPosition = GameObject.Find("PoopSpawnPoint");
        poopPrefab = Instantiate(Resources.Load("Prefabs/PoopPrefab") as GameObject, spawnPosition.transform.position, Quaternion.identity);
    }

    private void Update()
    {
/*        despawnTimer += Time.deltaTime;

        if (despawnTimer > 10f)
        {
            Debug.Log("Despawn poop");
            GameObject clonedPoop = GameObject.Find(poopClone);
            Destroy(clonedPoop);
        }*/
    }
}
