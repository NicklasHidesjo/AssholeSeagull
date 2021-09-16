using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterVelocity : MonoBehaviour
{
    [SerializeField] float velocity;
    public float Velocity
    {
        get { return velocity; }
    }


    Vector3 previousPos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;

        float distanceTraveled = Vector3.Distance(previousPos, currentPos);
        distanceTraveled = Mathf.Abs(distanceTraveled);
        Debug.Log(distanceTraveled);

        previousPos = transform.position;
    }
}
