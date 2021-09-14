using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullMovement : MonoBehaviour
{
    [SerializeField] Animator seagullAnimator;

    public int randomPackage;
    public Transform flightEnd;

    public SeagullManager seagullManager;

    Pooping pooping;

    Vector3 targetPosition;
    
    [SerializeField] float speed = 44f;

    public bool isPoopingTime = false;
    bool hasPooped = false;
    bool flyingAway = false;
    public bool inDistance = false;
    bool isScared = false;

    float poopingTimer;

    //Food Packages
    [SerializeField] Transform breadPackage;
    public Transform BreadPackage
    {
        get
        {
            return breadPackage;
        }
        set
        {
            breadPackage = value;
        }
    }

    [SerializeField] Transform cheesePackage;
    public Transform CheesePackage
    {
        get
        {
            return cheesePackage;
        }
        set
        {
            cheesePackage = value;
        }
    }

    [SerializeField] Transform hamPackage;
    public Transform HamPackage
    {
        get
        {
            return hamPackage;
        }
        set
        {
            hamPackage = value;
        }
    }


    public void Init()
    {
        randomPackage = Random.Range(0, 3);
        Debug.Log("Random Package: " + randomPackage);

        pooping = GetComponent<Pooping>();

        FoodTarget();

        transform.LookAt(targetPosition);
    }

    void Update()
    {    
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        if(transform.position == targetPosition && !isPoopingTime && !isScared)
        {
            Debug.Log("Pooping");
            seagullAnimator.SetBool("Pooping", true);

            isPoopingTime = true;
        }

        if(isPoopingTime == true)
        {
            poopingTimer += Time.deltaTime;

            if(poopingTimer > 1f && !hasPooped)
            {
                pooping.Poop();
                hasPooped = true;
                seagullAnimator.SetTrigger("FlyAway");
                seagullAnimator.SetBool("Pooping", false);
            }

            if(poopingTimer > 2.8f && !flyingAway)
            {
                targetPosition = flightEnd.position;
                transform.LookAt(targetPosition);

                flyingAway = true;
            }
        }

        if(transform.position == targetPosition && flyingAway)
        {
            seagullManager.Despawn(gameObject);
        }
    }

    public void Scared()
    {
        isScared = true;
        targetPosition = flightEnd.position;
        transform.LookAt(targetPosition);

        flyingAway = true;
    }

    private void FoodTarget()
    {
        if (randomPackage == 0)
        {
            targetPosition = new Vector3(breadPackage.position.x, transform.position.y, breadPackage.position.z);
        }
        else if (randomPackage == 1)
        {
            targetPosition = new Vector3(hamPackage.position.x, transform.position.y, hamPackage.position.z);
        }
        else if (randomPackage == 2)
        {
            targetPosition = new Vector3(cheesePackage.position.x, transform.position.y, cheesePackage.position.z);
        }
        else
        {
            Debug.LogError("No food was found!");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "ScareDistance" && !flyingAway)
        {
            Debug.Log("In distance to be scared");
            inDistance = true;
        }
    }
}
