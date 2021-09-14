using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FoodPackage : MonoBehaviour
{
    [SerializeField] private FoodItem foodItem;
    [SerializeField] private string foodName;
    [SerializeField] private GameObject poop;

    [SerializeField] Transform spawnPosition;

    private bool shitOnPackage;
    private int spoiledFoods = 0;

    [SerializeField] List<FoodItem> foodInContainer = new List<FoodItem>();

	private void Start()
	{
        SpawnFoodItem();
	}

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

    private void SpawnFoodItem()
    {
        Debug.Log("Item spawned");

        FoodItem newFoodItem = Instantiate(foodItem, spawnPosition.position, foodItem.transform.rotation);


        newFoodItem.name = foodName;
        newFoodItem.PoopOnFood = shitOnPackage;

        spoiledFoods--;
        spoiledFoods = (int) Mathf.Clamp(spoiledFoods, 0, Mathf.Infinity);
        shitOnPackage = spoiledFoods > 0;
        poop.SetActive(shitOnPackage);

        foodInContainer.Add(newFoodItem);
    }

    public void AddFoodToContainer(FoodItem food)
	{
        bool duplicate = false;

		foreach (var foodItem in foodInContainer)
		{
            if(foodItem == food)
			{
                duplicate = true;
			}
		}

        if(duplicate)
		{
            return;
		}

        foodInContainer.Add(food);
	}

    public void RemoveFoodFromContainer(FoodItem food)
	{
        foodInContainer.Remove(food);
        foodInContainer.RemoveAll(food => food == null);
        if(foodInContainer.Count < 1)
		{
            SpawnFoodItem();
		}
    }
}
