using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] float rayDistance = 100f;
    [SerializeField] LayerMask foodLayer;
    private List<FoodItem> sandwichPieces = new List<FoodItem>();

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
    }

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
            if(food.FoodType != FoodTypes.Bread)
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
		foreach (var food in sandwichPieces)
		{
            food.OnPlate = false;
		}

        sandwichPieces = new List<FoodItem>();

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.up, rayDistance, foodLayer);

        if(hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                FoodItem food = hits[i].collider.GetComponent<FoodItem>();
                if(food.IsMoving())
				{
                    continue;
				}
                sandwichPieces.Add(food);
                food.OnPlate = true;
            }
        }


        Debug.DrawRay(transform.position, transform.up, Color.blue);
    }

    void FinishSandwich()
    {
		foreach (var food in sandwichPieces)
		{
            if(food.FoodType != FoodTypes.Bread)
			{
                continue;
			}
            if(food.Buttered)
			{
                continue;
			}

            sandwichIsFinished = true;
            FindObjectOfType<GameManager>().CollectScore(sandwichPieces);
		}
    }
}
