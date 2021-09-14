using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopOnFood : MonoBehaviour
{
    FoodPackage foodPackage;

	private void Start()
	{
        foodPackage = GetComponentInParent<FoodPackage>();
	}

	private void OnTriggerEnter(Collider other)
    {
        GameObject hittedPoop = other.gameObject;
        if (other.gameObject.tag == "Poop")
        {
            Destroy(hittedPoop);
            Debug.Log("Poop hit");

            if(foodPackage.ShitOnPackage)
			{
                return;
			}
            foodPackage.ShitOnPackage = true;
        }
    }
}
