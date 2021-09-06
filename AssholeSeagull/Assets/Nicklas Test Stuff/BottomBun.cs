using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBun : MonoBehaviour
{
    [SerializeField] LayerMask layer;

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity, layer.value ))
        {
            Debug.Log("ray hit something");
            Debug.Log("Ray hit" + hit.transform.name);

            InteractableItem item = hit.transform.gameObject.GetComponent<InteractableItem>();

            if (item.PickeUpBy != null) { return; }
            if (item.Velocity.sqrMagnitude > 0.01) { return; }

            Debug.Log("Sandwich finished");
        }
    }
}
