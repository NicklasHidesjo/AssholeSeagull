using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterVelocity : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] float velocityMultiplier;
    public float Velocity
    {
        get { return velocity; }
    }


    Vector3 previousPos;

    void Start()
    {
        previousPos = transform.TransformPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.TransformPoint(transform.position);
        float distanceTraveled = Vector3.Distance(previousPos, currentPos);
        distanceTraveled = Mathf.Abs(distanceTraveled);
        velocity = distanceTraveled * velocityMultiplier;

        Debug.Log("Velocity: " + velocity);
        Debug.Log("Current pos: " + currentPos);
        Debug.Log("Previous pos: " + previousPos);

        previousPos = transform.TransformPoint(transform.position);

    }
}
