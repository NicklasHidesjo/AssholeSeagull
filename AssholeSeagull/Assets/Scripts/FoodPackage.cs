using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    [RequireComponent(typeof(Interactable))]
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

        private void Start()
        {
            ShitOnPackage = true;
            SpawnFoodItem(transform);
            SpawnFoodItem(parent);
        }

        public void SpawnFoodItem(Transform foodParent)
        {
            Debug.Log("Item spawned");
            FoodItem newFoodItem = Instantiate(foodItem, foodParent, true);
            newFoodItem.name = foodName;
            newFoodItem.GetComponent<Rigidbody>().isKinematic = true; //Delete after testing

            newFoodItem.PoopOnFood = shitOnPackage;

            spoiledFoods--;
            spoiledFoods = (int)Mathf.Clamp(spoiledFoods, 0, Mathf.Infinity);
            shitOnPackage = spoiledFoods > 0;
            poop.SetActive(shitOnPackage);
        }
    }
}
