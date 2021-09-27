using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSeagull : MonoBehaviour
{
    [SerializeField] Transform headTransform;
    [SerializeField] Transform rightHandTransform;
    [SerializeField] Transform leftHandTransform;
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log("Head y position is: " + headTransform.position.y);
        Debug.Log("Right-hand y position is: " + rightHandTransform.position.y);
        Debug.Log("Left-hand y position is: " + leftHandTransform.position.y);
    }
}
