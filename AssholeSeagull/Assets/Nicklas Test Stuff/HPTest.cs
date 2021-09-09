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
        }
        else if (leftHandDevices.Count > 1)
        {
            Debug.Log("Found more than one left hand!");
        }

        var rightHandedDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);

        if (rightHandedDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice rightHand = rightHandedDevices[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", rightHand.name, rightHand.characteristics.ToString()));
        }
        else if (leftHandDevices.Count > 1)
        {
            Debug.Log("Found more than one left hand!");
        }
    }
}
