using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
	FoodPackage package;
	private void Start()
	{
		package = GetComponentInParent<FoodPackage>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Food"))
		{
			package.AddFoodToContainer(other.GetComponent<FoodItem>());
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Food"))
		{
			package.RemoveFoodFromContainer(other.GetComponent<FoodItem>());
		}
	}
}
