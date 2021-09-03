using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullMovement : MonoBehaviour
{
    Pooping pooping;
    Vector3 direction;
    Vector3 targetPosition = new Vector3(0, 10, 0);

    float speed = 6f;

    private void Start()
    {
        pooping = gameObject.GetComponent<Pooping>();
        direction = (targetPosition - transform.position).normalized;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
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
