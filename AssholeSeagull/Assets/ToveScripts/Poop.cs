using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
  //  [SerializeField] Animator poopAnimator;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("poop landed");
        //   poopAnimator.SetTrigger("Splatt");

        Destroy(gameObject);

/*        if (other.gameObject.CompareTag("Food"))
        {
            Vector3 position = other.transform.position;
            Vector3 myPosition = new Vector3(position.x, other.transform.position.y, position.z);

            transform.position = myPosition;
            transform.SetParent(other.transform);

            Destroy(GetComponent<Rigidbody>());

            Vector3 rotation = new Vector3(0, 0, transform.rotation.z);
            transform.localRotation = Quaternion.Euler(rotation);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PoopKiller"))
        {
            Debug.Log("Kill poop");
            Destroy(gameObject);
        }
    }
}
