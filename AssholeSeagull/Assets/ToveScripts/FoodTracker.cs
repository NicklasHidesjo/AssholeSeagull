using System.Collections.Generic;
using UnityEngine;

public class FoodTracker : MonoBehaviour
{
    List<GameObject> foodObjects = new List<GameObject>();
    List<Transform> foodTransformList;

    void Start()
    {
        foodTransformList = new List<Transform>();
        GameObject[] foodArray = GameObject.FindGameObjectsWithTag("Food");

        foreach (GameObject food in foodArray)
        {
            foodTransformList.Add(food.transform);
            Debug.Log("Food transforms: " + food.transform.position);
        }
    }

    public Transform GetRandomTarget()
    {
        int randomFoodTarget = Random.Range(0, foodTransformList.Count);
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
