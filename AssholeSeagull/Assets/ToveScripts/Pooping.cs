using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooping : MonoBehaviour
{
    [SerializeField] GameObject poopPrefab;
    [SerializeField] Transform spawnPosition;

 //   string poopClone = "PoopPrefab(Clone)";

    float despawnTimer;

    public void Poop()
    {
        Instantiate(poopPrefab, spawnPosition.transform.position, Quaternion.identity);
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
