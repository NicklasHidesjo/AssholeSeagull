using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] float rayDistance = 100f;
    [SerializeField] LayerMask foodLayer;
    private FoodItem[] foodObject;

    bool sandwichIsFinished;


    private void Update()
    {
        if (sandwichIsFinished)
        {
            Debug.Log("Sandwich is Finished!");
            return;
        }

        if (!FirstFoodOnPlate())
        {
            return;
        }

        AddFoodToList();
        FinishSandwich();

        if (Input.GetKeyDown(KeyCode.I))
        {
            for (int i = 0; i < foodObject.Length; i++)
            {
                Debug.Log("Plate List: " + foodObject[i]);
            }
        }
    }

    //bool isButteredBread
    //Linecast
    // if is butter false -> return
    //if is buttered true -> Raycast
    //raycast collide no butter bread -> Game done, Sandwich Done

    bool FirstFoodOnPlate()
    {
        Vector3 plateVector = new Vector3(0, rayDistance, 0);
        RaycastHit hit;

        if (Physics.Linecast(transform.position, transform.position + plateVector, out hit, foodLayer))
        {
            FoodItem food = hit.collider.gameObject.GetComponent<FoodItem>();
            if(food == null)
            {
                return false;
            }
            if(food.FoodType != FoodItem.FoodTypes.Bread)
            {
                return false;
            }          
            if(food.Buttered)
            {
                return true;
            }
        }

        return false;
    }

    void AddFoodToList()
    {
        RaycastHit[] hits;
        Debug.DrawRay(transform.position, transform.up, Color.blue);

        hits = Physics.RaycastAll(transform.position, transform.up, rayDistance, foodLayer);

        if(hits.Length > 0)
        {
            foodObject = new FoodItem[hits.Length];

            for (int i = 0; i < hits.Length; i++)
            {
                foodObject[i] = hits[i].collider.GetComponent<FoodItem>();
            }
        }
    }

    void FinishSandwich()
    {
        for (int i = 0; i < foodObject.Length; i++)
        {
            if(foodObject[i].FoodType != FoodItem.FoodTypes.Bread)
            {
                continue;
            }

            if(!foodObject[i].Buttered)
            {
                sandwichIsFinished = true;
                FindObjectOfType<GameManager>().CollectScore(foodObject);
            }
        }
    }
}
