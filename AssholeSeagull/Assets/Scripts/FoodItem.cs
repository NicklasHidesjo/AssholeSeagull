using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    private Rigidbody body;

    [SerializeField] private float spoilTime;
    [SerializeField] private float selfDestructTime;

    private GameManager gameManager;

    [SerializeField] private float timer;
    [SerializeField] private bool isSpoiled;
    private bool inHand;

    private bool onSandwich;
    private bool poopOnFood;
    private bool inPackage;
    private bool buttered;
    private bool onPlate;
       
    public bool InHand
    {
        get { return inHand; }
        set { inHand = value; }
    }
    public bool IsSpoiled
    {
        get { return isSpoiled; }
    }
    public bool PoopOnFood
    {
        get { return poopOnFood; }
        set { poopOnFood = value; }
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
        if (onSandwich || inHand || inPackage || buttered)
        {
            return;
        }

        if (body.velocity.sqrMagnitude > 0.01)
        {
            return;
        }

        timer += Time.deltaTime;
        isSpoiled = timer > spoilTime;

        if(timer > selfDestructTime && !onPlate)
		{
            Destroy(gameObject);
		}
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Plate")
        {
            gameManager.score++;
            onPlate = true;
            Debug.Log("Score: " + gameManager.score);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Plate")
        {
            gameManager.score--;
            onPlate = false;
            Debug.Log("Score: " + gameManager.score);
        }
    }
}
