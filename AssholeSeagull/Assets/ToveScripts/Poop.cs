using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    [SerializeField] Animator poopAnimator;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("poop landed");
        poopAnimator.SetTrigger("Splatt");

        if (other.gameObject.CompareTag("Food"))
        {
            Vector3 position = other.transform.position;
            Vector3 myPosition = new Vector3(position.x, position.y + (other.transform.localScale.y / 2), position.z);
            transform.position = myPosition;

            Destroy(GetComponent<Rigidbody>());
            transform.SetParent(other.transform);

            Vector3 rotation = new Vector3(0, 0, transform.rotation.z);
            transform.localRotation = Quaternion.Euler(rotation);
        }
    }
}
