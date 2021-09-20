using System.Collections.Generic;
using UnityEngine;

public class FoodTracker : MonoBehaviour
{
    [SerializeField] List<Transform> foodTransformList;

    public Transform GetRandomTarget()
    {
        foodTransformList = new List<Transform>();
        GameObject[] foodArray = GameObject.FindGameObjectsWithTag("Food");

        foreach (GameObject food in foodArray)
        {
            foodTransformList.Add(food.transform);
        }

        int randomFoodTarget;
        int currentIteration = 0;
        int maxIterations = 5;

        bool noTargetFound = false;

        do
        {
            randomFoodTarget = Random.Range(0, foodTransformList.Count);
            currentIteration++;

            if(currentIteration >= maxIterations)
            {
                noTargetFound = true;
            }
        }
        while (GetValidTarget(randomFoodTarget) && !noTargetFound);
        
        if(noTargetFound)
        {
            return null;
        }

        return foodTransformList[randomFoodTarget];
    }

    private bool GetValidTarget(int randomFoodTarget)
    {
        return foodTransformList[randomFoodTarget].GetComponent<FoodItem>().OnPlate;
    }

    public void AddFoodTransform(Transform foodTransform)
    {
        foodTransformList.Add(foodTransform);
    }

    public void RemoveFoodTransform(Transform foodTransform)
    {
        foodTransformList.Remove(foodTransform);
    }
}
