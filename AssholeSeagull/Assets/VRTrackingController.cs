using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRTrackingController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OpenVR.Chaperone.ResetZeroPose(ETrackingUniverseOrigin.TrackingUniverseSeated);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
