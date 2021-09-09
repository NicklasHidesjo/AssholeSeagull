using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullMovement : MonoBehaviour
{
    public Transform sandwich;
    public Transform flightEnd;
    public SeagullManager seagullManager;

    Pooping pooping;

    Vector3 targetPosition;
    
    [SerializeField] float speed = 10f;

    bool hasPooped = false;


    private void Start()
    {
        pooping = GetComponent<Pooping>();
        targetPosition = new Vector3(sandwich.position.x, transform.position.y, sandwich.position.z);

        transform.LookAt(targetPosition);
    }

    void Update()
    {    
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        if(transform.position == targetPosition && !hasPooped)
        {
            Debug.Log("Pooping");
            pooping.Poop();

            targetPosition = flightEnd.position;
            transform.LookAt(targetPosition);

            hasPooped = true;
        }

        if(transform.position == targetPosition && hasPooped)
        {
            seagullManager.Despawn(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
/*        if (other.name == "Player")
        {
            Debug.Log("Pooping");
            pooping.Poop();
        }*/
    }
}
