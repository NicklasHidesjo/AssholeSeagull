using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopOnFood : MonoBehaviour
{
    FoodPackage foodPackage;
    [SerializeField] AudioClip poopOnFoodSound;


    private void Start()
	{
        foodPackage = GetComponentInParent<FoodPackage>();
	}

	private void OnTriggerEnter(Collider other)
    {
        GameObject hittedPoop = other.gameObject;
        if (other.gameObject.tag == "Poop")
        {
            SoundSingleton.Instance.SeagullFx(poopOnFoodSound);

            Destroy(hittedPoop);

            if(foodPackage.ShitOnPackage)
			{
                return;
			}
            foodPackage.ShitOnPackage = true;
        }
    }
}
