using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullMovement : MonoBehaviour
{
    [SerializeField] Animator seagullAnimator;
    public Transform sandwich;
    public Transform flightEnd;
    public SeagullManager seagullManager;

    Pooping pooping;

    Vector3 targetPosition;
    
    [SerializeField] float speed = 44f;

    bool hasPooped = false;
    bool flyingAway = false;

    float poopingTimer;


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
            seagullAnimator.SetBool("Pooping", true);

            hasPooped = true;
        }

        if(hasPooped == true)
        {
            poopingTimer += Time.deltaTime;

            if(poopingTimer > 1f && !flyingAway)
            {
                seagullAnimator.SetBool("Pooping", false);
                seagullAnimator.SetTrigger("FlyAway");

                targetPosition = flightEnd.position;
                transform.LookAt(targetPosition);

                flyingAway = true;
            }
        }

        if(transform.position == targetPosition && hasPooped && flyingAway)
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
