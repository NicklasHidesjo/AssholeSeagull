using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    [SerializeField] AudioClip poopOnFoodSound;
    [SerializeField] AudioClip foodSpoiledSound;
    [SerializeField] float velocityThreshold = 0.01f;

    [SerializeField] private float spoilTime;
    [SerializeField] private float selfDestructTime;

    private GameManager gameManager;

    [SerializeField] GameObject spoiledParticles;

    [SerializeField] private float timer;
    [SerializeField] private bool isSpoiled;
    [SerializeField] private bool onPlate;
    [SerializeField] Material spoiledMaterial;

    private bool inHand;

    private bool onSandwich;
    [SerializeField] private bool poopOnFood;
    private bool inPackage;
    private bool buttered;
    bool alreadySpoiled = false;

    [SerializeField] float rayDistance;


    [Header("Score Settings")]
    [SerializeField] int baseScore;
    [SerializeField] int addition;
    [SerializeField] int reduction;
    [SerializeField] int spoilReduction;
    [SerializeField] int poopReduction;

    [Header("FoodType Settings")]
    [SerializeField] LayerMask foodLayer;
    [SerializeField] FoodTypes foodType;

    [SerializeField] FoodTypes foodAbove;
    [SerializeField] FoodTypes perfectAbove;
    [SerializeField] FoodTypes worstAbove;

    [SerializeField] FoodTypes foodBelow;
    [SerializeField] FoodTypes perfectBelow;
    [SerializeField] FoodTypes worstBelow;

    private Rigidbody body;

    public FoodTypes FoodType
    {
        get { return foodType; }
    }

    public bool InHand
    {
        get { return inHand; }
        set { inHand = value; }
    }
    public bool IsSpoiled
    {
        get { return isSpoiled; }
    }

    public bool OnPlate
    {
        get { return onPlate; }
        set { onPlate = value; }
    }

    public bool PoopOnFood
    {
        get { return poopOnFood; }
        set 
        { 
            poopOnFood = value; 

            if(value)
            {
                ChangeMaterial(spoiledMaterial);
            }
        }
    }
    public bool InPackage
    {
        get { return inPackage; }
        set { inPackage = value; }
    }
    public bool Buttered
    {
        get { return buttered; }
        set { buttered = value; }
    }

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
	{
		RaycastFoodLayer();

		if (onSandwich || inHand || inPackage || buttered || onPlate)
		{
			return;
		}

		if (IsMoving())
		{
			return;
		}

		timer += Time.deltaTime;
		isSpoiled = timer > spoilTime;

		if (isSpoiled && !alreadySpoiled && !onPlate)
		{
			SoundSingleton.Instance.FoodSound(foodSpoiledSound);
			ChangeMaterial(spoiledMaterial);
		}

		if (timer > selfDestructTime && !onPlate)
		{
			Destroy(gameObject);
		}
	}

	public bool IsMoving()
	{
		return body.velocity.sqrMagnitude > velocityThreshold;
	}

	void ChangeMaterial(Material material)
    {
        alreadySpoiled = true;
        gameObject.GetComponent<Renderer>().material = material;
        spoiledParticles.SetActive(true);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Poop")
        {
            SoundSingleton.Instance.SeagullFx(poopOnFoodSound);
            GameObject poop = collider.gameObject;

            PoopOnFood = true;

            Destroy(poop);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Plate")
        {
            timer = 0f;
            gameManager.score--;
            onPlate = false;
            Debug.Log("Score: " + gameManager.score);
        }
    }


    public int GetScore()
    {
        int score = baseScore;

        if(foodAbove == perfectAbove)
        {
            score += addition;
        }
        else if(foodAbove == worstAbove)
        {
            score -= reduction;
        }

        if(foodBelow == perfectBelow)
        {
            score += addition;
        }
        else if(foodBelow == worstBelow)
        {
            score -= reduction;
        }

        if(isSpoiled)
        {
            score -= spoilReduction;
        }
        if(PoopOnFood)
        {
            score -= poopReduction;
        }

        return score;
    }

    void RaycastFoodLayer()
    {
        RaycastHit hit;

        Vector3 northSide = new Vector3(0, rayDistance, 0);
        Vector3 southSide = new Vector3(0, -rayDistance, 0);

        Debug.DrawRay(transform.position, northSide, Color.blue);
        Debug.DrawRay(transform.position, southSide, Color.red);

        if(Physics.Linecast(transform.position, transform.position + northSide, out hit, foodLayer))
        {
            FoodItem food = hit.collider.gameObject.GetComponent<FoodItem>();

            if (food == null)
            {
                foodAbove = FoodTypes.None;
                return;
            }

            foodAbove = food.foodType;
        }
        else
        {
            foodAbove = FoodTypes.None;
        }

        if (Physics.Linecast(transform.position, transform.position + southSide, out hit, foodLayer))
        {
            FoodItem food = hit.collider.gameObject.GetComponent<FoodItem>();

            if (food == null)
            {
                foodBelow = FoodTypes.None;
                return;
            }

            foodBelow = food.foodType;
        }
        else
        {
            foodBelow = FoodTypes.None;
        }
    }
}
