using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopOnFood : MonoBehaviour
{
    [SerializeField] GameObject poop;
    bool poopedOn = false;
    bool alreadyPoopedOn = false;

    private void Update()
    {
        if(poopedOn == true && alreadyPoopedOn == false)
        {
            poop.SetActive(true);
            alreadyPoopedOn = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hittedPoop = other.gameObject;
        if (other.gameObject.tag == "Poop")
        {
            Destroy(hittedPoop);
            Debug.Log("Poop hit");

            poopedOn = true;
        }
    }
}
