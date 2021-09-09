using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);

        if (leftHandDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice leftHand = leftHandDevices[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", leftHand.name, leftHand.characteristics.ToString()));

            bool triggerValue;
            if (leftHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue))
            {
                Debug.Log("Left trigger button is pressed.");
            }

            var inputFeatures = new List<UnityEngine.XR.InputFeatureUsage>();
            if (leftHand.TryGetFeatureUsages(inputFeatures))
            {
                foreach (var feature in inputFeatures)
                {
                    if (feature.type == typeof(bool))
                    {
                        bool featureValue;
                        if (leftHand.TryGetFeatureValue(feature.As<bool>(), out featureValue))
                        {
                            Debug.Log(string.Format("Bool feature {0}'s value is {1}", feature.name, featureValue.ToString()));
                        }
                    }
                }
            }

        }
        else if (leftHandDevices.Count > 1)
        {
            Debug.Log("Found more than one left hand!");
        }

        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);

        if (rightHandDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice rightHand = rightHandDevices[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", rightHand.name, rightHand.characteristics.ToString()));

            bool triggerValue;
            if (rightHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue))
            {
                Debug.Log("right Trigger button is pressed.");
            }


            var inputFeatures = new List<UnityEngine.XR.InputFeatureUsage>();
            if (rightHand.TryGetFeatureUsages(inputFeatures))
            {
                foreach (var feature in inputFeatures)
                {
                    if (feature.type == typeof(bool))
                    {
                        bool featureValue;
                        if (rightHand.TryGetFeatureValue(feature.As<bool>(), out featureValue))
                        {
                            Debug.Log(string.Format("Bool feature {0}'s value is {1}", feature.name, featureValue.ToString()));
                        }
                    }
                }
            }

        }
        else if (leftHandDevices.Count > 1)
        {
            Debug.Log("Found more than one left hand!");
        }
    }
}
