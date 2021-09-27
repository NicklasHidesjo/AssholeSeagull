using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSeagull : MonoBehaviour
{
    [SerializeField] float scareRadius;
    [SerializeField] LayerMask seagullLayer;
    
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
        Vector3 headPos = headTransform.position;

        Vector3 rightHandPos = rightHandTransform.position;

        Vector3 leftHandPos = leftHandTransform.position;


        if (rightHandPos.y > headPos.y)
        {
            rightHandPos.y = 0;
            float velocity = GetSpeed(rightHandPos, oldRightPosition);

            //Debug.Log("Right hand velocity is: " + velocity);

            if(velocity > scareVelocityThreshold)
            {
                Debug.Log("Scaring seagull using right hand");
                ScareSeagulls(rightHandTransform.position);

            }
        }
        if (leftHandPos.y > headPos.y)
        {
            leftHandPos.y = 0;
            float velocity = GetSpeed(leftHandPos, oldLeftPosition);

            //Debug.Log("Left hand velocity is: " + velocity);

            if (velocity > scareVelocityThreshold)
            {
                Debug.Log("Scaring seagull using left hand");
                ScareSeagulls(leftHandTransform.position);
            }
        }

        oldLeftPosition = leftHandPos;
        oldRightPosition = rightHandPos;
    }

    private void ScareSeagulls(Vector3 position)
    {
        Collider[] seagulls = Physics.OverlapSphere(position, scareRadius, seagullLayer);
        foreach (var seagull in seagulls)
        {
            seagull.GetComponent<SeagullMovement>().Scared();
            Debug.Log("Scaring a seagull");
        }
    }

    private float GetSpeed(Vector3 currentPos, Vector3 oldPosition)
    {
        float distanceTraveled = Vector3.Distance(oldPosition, currentPos);
        distanceTraveled = Mathf.Abs(distanceTraveled);
        return distanceTraveled * velocityMultiplier;
    }
}
