using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    private Rigidbody body;
    private bool poopOnFood;

    [SerializeField] private float spoilTime;
    [SerializeField] private float spoilTimer;
    [SerializeField] private bool isSpoiled;

    public bool PoopOnFood
    {
        get { return poopOnFood; }
        set { poopOnFood = value; }
    }

    private bool onSandwich;
    private bool inHand;

    public bool InHand
    {
        get { return inHand; }
        set { inHand = value; }
    }

    public bool IsSpoiled
    {
        get { return isSpoiled; }
    }

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (onSandwich || inHand)
        {
            return;
        }

        if (body.velocity.sqrMagnitude > 0.01)
        {
            return;
        }

        spoilTimer += Time.deltaTime;
        isSpoiled = spoilTimer > spoilTime;
    }
}
