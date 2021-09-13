using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPackage : MonoBehaviour
{
    [SerializeField] private GameObject foodItem;
    [SerializeField] private Transform parent;
    [SerializeField] private string foodName; 
    private bool shitOnPackage;
    void Start()
    {
        SpawnFoodItem(transform);
        SpawnFoodItem(parent);
    }

    private void SpawnFoodItem(Transform foodParent)
    {
        Debug.Log("Item spawned");
        GameObject newFoodItem = Instantiate(foodItem, foodParent, true);
        newFoodItem.name = foodName;
        newFoodItem.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update()
    {

    }
}
