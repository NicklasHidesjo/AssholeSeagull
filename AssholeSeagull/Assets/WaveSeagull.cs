using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSeagull : MonoBehaviour
{
    [SerializeField] float velocityMultiplier;
    [SerializeField] float scareVelocityThreshold;
    
    [SerializeField] Transform headTransform;
    [SerializeField] Transform rightHandTransform;
    [SerializeField] Transform leftHandTransform;

    Vector3 oldLeftPosition;
    Vector3 oldRightPosition;

    void Start()
    {
        oldLeftPosition = leftHandTransform.position;
        oldRightPosition = rightHandTransform.position;
    }

    void Update()
    {
        Debug.Log("Head y position is: " + headTransform.position.y);

        Vector3 headPos = headTransform.position;

        Vector3 rightHandPos = rightHandTransform.position;
        Vector3 leftHandPos = leftHandTransform.position;

        Debug.Log("Left-hand y position is: " + leftHandPos.y);
        Debug.Log("Right-hand y position is: " + rightHandPos.y);


        if (rightHandPos.y > headPos.y)
        {
            float velocity = GetSpeed(rightHandPos, oldRightPosition);

            Debug.Log("Right hand velocity is: " + velocity);

            if(velocity > scareVelocityThreshold)
            {
                Debug.Log("Scaring seagull using right hand");
            }
        }
        if (leftHandPos.y > headPos.y)
        {
            float velocity = GetSpeed(leftHandPos, oldLeftPosition);

            Debug.Log("Left hand velocity is: " + velocity);

            if (velocity > scareVelocityThreshold)
            {
                Debug.Log("Scaring seagull using left hand");
            }
        }

        oldLeftPosition = leftHandPos;
        oldRightPosition = rightHandPos;
    }

    private float GetSpeed(Vector3 currentPos, Vector3 oldPosition)
    {
        float distanceTraveled = Vector3.Distance(oldPosition, currentPos);
        distanceTraveled = Mathf.Abs(distanceTraveled);
        return distanceTraveled * velocityMultiplier;
    }
}
