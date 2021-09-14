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

        int randomFoodTarget = Random.Range(0, foodTransformList.Count);

        Debug.Log("food list: " + foodTransformList.Count);

        return foodTransformList[randomFoodTarget];
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
