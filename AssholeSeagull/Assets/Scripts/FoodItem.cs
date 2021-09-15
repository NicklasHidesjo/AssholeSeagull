using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    private Rigidbody body;

    [SerializeField] private float spoilTime;
    [SerializeField] private float selfDestructTime;

    [SerializeField] private float timer;
    [SerializeField] private bool isSpoiled;
    private bool inHand;

    private bool onSandwich;
    private bool poopOnFood;
    private bool inPackage;
    private bool buttered;
       
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

        if(timer > selfDestructTime)
		{
            Destroy(gameObject);
		}
    }
}
