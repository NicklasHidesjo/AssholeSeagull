using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRTrackingController : MonoBehaviour
{
 
    [Tooltip("Desired head position of player when seated")]
    [SerializeField] Transform desiredHeadPosition;

    //Assign these variables in the inspector, or find them some other way (eg. in Start() )
    [SerializeField] Transform steamCamera;
    [SerializeField] Transform cameraRig;
    
    // Start is called before the first frame update
    void Start()
    {
        //OpenVR.Chaperone.ResetZeroPose(ETrackingUniverseOrigin.TrackingUniverseSeated);
        //Recenter();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OpenVR.Chaperone.ResetZeroPose(ETrackingUniverseOrigin.TrackingUniverseSeated);
            
            //Recenter();
        }
        if(steamCamera.transform.position.y > 0)
        {
            if(cameraRig.transform.position.y == 0)
            {
                Recenter();
            }
        }
    }

    private void Recenter()
    {
        if (desiredHeadPosition != null)
        {
            ResetSeatedPos(desiredHeadPosition);
        }
        else
        {
            Debug.LogError("Target Transform required. Assign in inspector.", gameObject);
        }
    }

    private void ResetSeatedPos(Transform desiredHeadPos)
    {
        if ((steamCamera != null) && (cameraRig != null))
        {
            //ROTATION
            // Get current head heading in scene (y-only, to avoid tilting the floor)
            float offsetAngle = steamCamera.rotation.eulerAngles.y;
            // Now rotate CameraRig in opposite direction to compensate
            cameraRig.Rotate(0f, -offsetAngle, 0f);

            //POSITION
            // Calculate postional offset between CameraRig and Camera
            Vector3 offsetPos = steamCamera.position - cameraRig.position;
            // Reposition CameraRig to desired position minus offset
            cameraRig.position = (desiredHeadPos.position - offsetPos);

            Debug.Log("Seat recentered!");
        }
        else
        {
            Debug.Log("Error: SteamVR objects not found!");
        }
    }
}

