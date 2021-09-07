using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullMovement : MonoBehaviour
{
    public Transform sandwich;

    Pooping pooping;

    Vector3 targetPosition;

    [SerializeField] float speed = 10f;


    private void Start()
    {
        pooping = gameObject.GetComponent<Pooping>();
        targetPosition = new Vector3(sandwich.position.x, transform.position.y, sandwich.position.z);

        transform.LookAt(targetPosition);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Pooping");
            pooping.Poop();
        }
    }
}
