using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FoodPackage : MonoBehaviour
{
    [SerializeField] private FoodItem foodItem;
    [SerializeField] private Transform parent;
    [SerializeField] private string foodName;
    [SerializeField] private GameObject poop;
    private bool shitOnPackage;
    private int spoiledFoods = 0;

    public bool ShitOnPackage
    {
        get { return shitOnPackage; }
        set
        {
            shitOnPackage = value;
            poop.SetActive(value);
            
            if (value)
            {
                spoiledFoods = 1;
            }
        }
    }

    public GameObject SpawnFoodItem()
    {
        Debug.Log("Item spawned");
        FoodItem newFoodItem = Instantiate(foodItem);
        newFoodItem.name = foodName;
        newFoodItem.PoopOnFood = shitOnPackage;

        spoiledFoods--;
        spoiledFoods = (int) Mathf.Clamp(spoiledFoods, 0, Mathf.Infinity);
        shitOnPackage = spoiledFoods > 0;
        poop.SetActive(shitOnPackage);

        return newFoodItem.gameObject;
    }
}
